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

        public async Task<List<Planeta>> ObtenerPlanetasAsync()
        {
            var result = await _restApi.Get<PeopleResponse<PlanetaJsonModel>>(
                "https://swapi.dev/api/",
                "planets/"
            );

            if (result?.Results == null || !result.Results.Any())
                return await _context.Planetas.ToListAsync();

            var planetasGuardados = await _context.Planetas.ToListAsync();

            foreach (var item in result.Results)
            {
                bool existe = planetasGuardados.Any(p => p.Url == item.Url);

                if (!existe)
                {
                    var planeta = new Planeta
                    {
                        Nombre = item.Name ?? "",
                        PeriodoDeRotación = item.RotationPeriod ?? "",
                        PeriodoOrbital = item.OrbitalPeriod ?? "",
                        Diametro = item.Diameter ?? "",
                        Clima = item.Climate ?? "",
                        Gravedad = item.Gravity ?? "",
                        Terreno = item.Terrain ?? "",
                        AguaSuperficial = item.SurfaceWater ?? "",
                        Poblacion = item.Population ?? "",
                        Picture = "",
                        Url = item.Url ?? ""
                    };

                    _context.Planetas.Add(planeta);
                    planetasGuardados.Add(planeta);
                }
            }

            await _context.SaveChangesAsync();

            return await _context.Planetas.ToListAsync();
        }

        public async Task CrearPlanetaAsync(Planeta planeta)
        {
            _context.Planetas.Add(planeta);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarPlanetaAsync(Planeta planeta)
        {
            var planetaBD = await _context.Planetas.FindAsync(planeta.Id);

            if (planetaBD != null)
            {
                planetaBD.Nombre = planeta.Nombre;
                planetaBD.PeriodoDeRotación = planeta.PeriodoDeRotación;
                planetaBD.PeriodoOrbital = planeta.PeriodoOrbital;
                planetaBD.Diametro = planeta.Diametro;
                planetaBD.Clima = planeta.Clima;
                planetaBD.Gravedad = planeta.Gravedad;
                planetaBD.Terreno = planeta.Terreno;
                planetaBD.AguaSuperficial = planeta.AguaSuperficial;
                planetaBD.Poblacion = planeta.Poblacion;
                planetaBD.Picture = planeta.Picture;
                planetaBD.Url = planeta.Url;

                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarPlanetaAsync(int id)
        {
            var planeta = await _context.Planetas.FindAsync(id);

            if (planeta != null)
            {
                _context.Planetas.Remove(planeta);
                await _context.SaveChangesAsync();
            }
        }
    }
}