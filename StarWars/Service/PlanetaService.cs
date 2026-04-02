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

        public Task ActualizarPlanetaAsync(Planeta planeta)
        {
            throw new NotImplementedException();
        }

        public Task CrearPlanetaAsync(Planeta planeta)
        {
            throw new NotImplementedException();
        }

        public Task EliminarPlanetaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Planeta>> ObtenerPlanetasAsync()
        {

            var result = await _restApi.Get<PeopleResponse<PlanetaJsonModel>>(
                "https://swapi.dev/api/",
                "planets/"
            );

            if (result?.Results == null || !result.Results.Any())
                return await _context.Planetas.ToListAsync();

            foreach (var item in result.Results)
            {
                bool existe = await _context.Planetas
                    .AnyAsync(p => p.Url == item.Url);

                if (!existe)
                {
                    _context.Planetas.Add(new Planeta
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
                    });
                }
            }

            await _context.SaveChangesAsync();

            return await _context.Planetas.ToListAsync();
        }
    }
}