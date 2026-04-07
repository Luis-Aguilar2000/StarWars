using Microsoft.EntityFrameworkCore;
using RestLibrary.Interfaces;
using StarWars.Data;
using StarWars.Dtos;
using StarWars.Helper;
using StarWars.Models;

namespace StarWars.Services
{
    public class PlanetaService : IPlanetaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRestApi _restApi;

        public PlanetaService(ApplicationDbContext context, IRestApi restApi)
        {
            _context = context;
            _restApi = restApi;
        }

        public async Task<List<Planeta>> ObtenerPlanetas()
        {
            return await _context.Planetas
                .AsNoTracking()
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        private async Task<List<PlanetaJsonModel>> ObtenerTodosLosPlanetasApi()
        {
            var todosLosPlanetas = new List<PlanetaJsonModel>();
            string endpoint = "planets/";

            while (!string.IsNullOrEmpty(endpoint))
            {
                var result = await _restApi.Get<PeopleResponse<PlanetaJsonModel>>(
                    "https://swapi.dev/api/",
                    endpoint
                );

                if (result?.Results != null && result.Results.Any())
                {
                    todosLosPlanetas.AddRange(result.Results);
                }

                if (string.IsNullOrEmpty(result?.Next))
                {
                    endpoint = null;
                }
                else
                {
                    endpoint = result.Next.Replace("https://swapi.dev/api/", "");
                }
            }

            return todosLosPlanetas;
        }

        public async Task SincronizarPlanetas()
        {
            var planetasApi = await ObtenerTodosLosPlanetasApi();

            if (planetasApi == null || !planetasApi.Any())
                return;

            var urlsApi = planetasApi
                .Select(x => x.Url)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            var urlsExistentes = await _context.Planetas
                .Where(p => urlsApi.Contains(p.Url))
                .Select(p => p.Url)
                .ToListAsync();

            var nuevosPlanetas = planetasApi
                .Where(item => !urlsExistentes.Contains(item.Url))
                .Select(item => new Planeta
                {
                    Nombre = item.Name,
                    PeriodoDeRotación = item.RotationPeriod,
                    PeriodoOrbital = item.OrbitalPeriod,
                    Diametro = item.Diameter,
                    Clima = item.Climate,
                    Gravedad = item.Gravity,
                    Terreno = item.Terrain,
                    AguaSuperficial = item.SurfaceWater,
                    Poblacion = item.Population,
                    Url = item.Url
                })
                .ToList();

            if (nuevosPlanetas.Any())
            {
                await _context.Planetas.AddRangeAsync(nuevosPlanetas);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CrearPlaneta(Planeta planeta)
        {
            if (planeta == null) return;

            _context.Planetas.Add(planeta);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarPlaneta(Planeta planeta)
        {
            if (planeta == null) return;

            var planetaExistente = await _context.Planetas
                .FirstOrDefaultAsync(p => p.Id == planeta.Id);

            if (planetaExistente == null) return;

            planetaExistente.Nombre = planeta.Nombre;
            planetaExistente.PeriodoDeRotación = planeta.PeriodoDeRotación;
            planetaExistente.PeriodoOrbital = planeta.PeriodoOrbital;
            planetaExistente.Diametro = planeta.Diametro;
            planetaExistente.Clima = planeta.Clima;
            planetaExistente.Gravedad = planeta.Gravedad;
            planetaExistente.Terreno = planeta.Terreno;
            planetaExistente.AguaSuperficial = planeta.AguaSuperficial;
            planetaExistente.Poblacion = planeta.Poblacion;
            planetaExistente.Picture = planeta.Picture;
            planetaExistente.Url = planeta.Url;

            await _context.SaveChangesAsync();
        }

        public async Task EliminarPlaneta(int id)
        {
            var planeta = await _context.Planetas
                .FirstOrDefaultAsync(p => p.Id == id);

            if (planeta == null) return;

            _context.Planetas.Remove(planeta);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Planeta>> BuscarAsync(string filtro)
        {
            var lista = await _context.Planetas.ToListAsync();

            if (string.IsNullOrWhiteSpace(filtro))
                return lista;

            var palabras = filtro
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var palabra in palabras)
            {
                var p = palabra;

                lista = lista.Where(x =>
                    (x.Nombre ?? "").ToLower().Contains(p) ||
                    (x.PeriodoDeRotación ?? "").ToLower().Contains(p) ||
                    (x.PeriodoOrbital ?? "").ToLower().Contains(p) ||
                    (x.Diametro ?? "").ToLower().Contains(p) ||
                    (x.Clima ?? "").ToLower().Contains(p) ||
                    (x.Gravedad ?? "").ToLower().Contains(p) ||
                    (x.Terreno ?? "").ToLower().Contains(p) ||
                    (x.AguaSuperficial ?? "").ToLower().Contains(p) ||
                    (x.Poblacion ?? "").ToLower().Contains(p)
                ).ToList();
            }

            return lista;
        }
    }
}