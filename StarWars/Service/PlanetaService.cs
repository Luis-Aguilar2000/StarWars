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

        public async Task SincronizarPlanetas()
        {
            var result = await _restApi.Get<PeopleResponse<PlanetaJsonModel>>(
                "https://swapi.dev/api/",
                "planets/"
            );

            if (result?.Results == null || !result.Results.Any())
                return;

            var nombresApi = result.Results
                .Select(x => x.Name)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            var nombresExistentes = await _context.Planetas
                .Where(p => nombresApi.Contains(p.Nombre))
                .Select(p => p.Nombre)
                .ToListAsync();

            var nuevosPlanetas = result.Results
                .Where(item => !nombresExistentes.Contains(item.Name))
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
                    Picture = "",
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
            var query = _context.Planetas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var palabras = BuscarHelper.ObtenerPalabras(filtro.ToLower());

                foreach (var palabra in palabras)
                {
                    var p1 = palabra;

                    query = query.Where(p =>
                        (p.Nombre != null && p.Nombre.ToLower().Contains(p1)) ||
                        (p.Clima != null && p.Clima.ToLower().Contains(p1)) ||
                        (p.Terreno != null && p.Terreno.ToLower().Contains(p1)) ||
                        (p.Poblacion != null && p.Poblacion.Contains(p1))
                    );
                }
            }

            return await query.ToListAsync();
        }
    }
}