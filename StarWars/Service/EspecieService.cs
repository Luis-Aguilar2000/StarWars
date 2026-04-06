using Microsoft.EntityFrameworkCore;
using RestLibrary.Interfaces;
using StarWars.Data;
using StarWars.Dtos;
using StarWars.Helper;
using StarWars.Models;

namespace StarWars.Services
{
    public class EspecieService : IEspecieService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRestApi _restApi;

        public EspecieService(ApplicationDbContext context, IRestApi restApi)
        {
            _context = context;
            _restApi = restApi;
        }

        public async Task<List<Especie>> ObtenerEspecies()
        {
            return await _context.Especies
                .AsNoTracking()
                .OrderBy(e => e.Nombre)
                .ToListAsync();
        }

        public async Task SincronizarEspecies()
        {
            var result = await _restApi.Get<PeopleResponse<EspecieJsonModel>>(
                "https://swapi.dev/api/",
                "species/"
            );

            if (result?.Results == null || !result.Results.Any())
                return;

            var nombresApi = result.Results
                .Select(x => x.Name)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            var nombresExistentes = await _context.Especies
                .Where(e => nombresApi.Contains(e.Nombre))
                .Select(e => e.Nombre)
                .ToListAsync();

            var nuevasEspecies = result.Results
                .Where(item => !nombresExistentes.Contains(item.Name))
                .Select(item => new Especie
                {
                    Nombre = item.Name,
                    Clasificacion = item.Classification,
                    Designacion = item.Designation,
                    AlturaPromedio = item.AverageHeight,
                    ColoresDePiel = item.SkinColors,
                    ColoresDePelo = item.HairColors,
                    ColoresDeOjos = item.EyeColors,
                    EsperanzaDeVida = item.AverageLifespan,
                    Idioma = item.Language,
                    Picture = "",
                    Url = item.Url
                })
                .ToList();

            if (nuevasEspecies.Any())
            {
                await _context.Especies.AddRangeAsync(nuevasEspecies);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CrearEspecie(Especie especie)
        {
            if (especie == null) return;

            _context.Especies.Add(especie);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarEspecie(Especie especie)
        {
            if (especie == null) return;

            var especieExistente = await _context.Especies
                .FirstOrDefaultAsync(e => e.Id == especie.Id);

            if (especieExistente == null) return;

            especieExistente.Nombre = especie.Nombre;
            especieExistente.Clasificacion = especie.Clasificacion;
            especieExistente.Designacion = especie.Designacion;
            especieExistente.AlturaPromedio = especie.AlturaPromedio;
            especieExistente.ColoresDePiel = especie.ColoresDePiel;
            especieExistente.ColoresDePelo = especie.ColoresDePelo;
            especieExistente.ColoresDeOjos = especie.ColoresDeOjos;
            especieExistente.EsperanzaDeVida = especie.EsperanzaDeVida;
            especieExistente.Idioma = especie.Idioma;
            especieExistente.Picture = especie.Picture;
            especieExistente.Url = especie.Url;

            await _context.SaveChangesAsync();
        }

        public async Task EliminarEspecie(int id)
        {
            var especie = await _context.Especies
                .FirstOrDefaultAsync(e => e.Id == id);

            if (especie == null) return;

            _context.Especies.Remove(especie);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Especie>> BuscarAsync(string filtro)
        {
            var query = _context.Especies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var palabras = BuscarHelper.ObtenerPalabras(filtro.ToLower());

                foreach (var palabra in palabras)
                {
                    var p1 = palabra;

                    query = query.Where(e =>
                        (e.Nombre != null && e.Nombre.ToLower().Contains(p1)) ||
                        (e.Clasificacion != null && e.Clasificacion.ToLower().Contains(p1)) ||
                        (e.Designacion != null && e.Designacion.ToLower().Contains(p1)) ||
                        (e.AlturaPromedio != null && e.AlturaPromedio.Contains(p1)) ||
                        (e.ColoresDePelo != null && e.ColoresDePelo.ToLower().Contains(p1)) ||
                        (e.ColoresDePiel != null && e.ColoresDePiel.ToLower().Contains(p1)) ||
                        (e.ColoresDeOjos != null && e.ColoresDeOjos.ToLower().Contains(p1)) ||
                        (e.EsperanzaDeVida != null && e.EsperanzaDeVida.Contains(p1)) ||
                        (e.Idioma != null && e.Idioma.ToLower().Contains(p1))
                    );
                }
            }

            return await query.ToListAsync();
        }
    }
}