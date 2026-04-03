using Microsoft.EntityFrameworkCore;
using RestLibrary.Interfaces;
using StarWars.Data;
using StarWars.Dtos;
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

            var nuevosPlanetas = new List<Planeta>();

            foreach (var item in result.Results)
            {
                bool existe = await _context.Planetas
                    .AnyAsync(p => p.Nombre == item.Name);

                if (!existe)
                {
                    var planeta = new Planeta
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
                    };

                    nuevosPlanetas.Add(planeta);
                }
            }

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
    }
}