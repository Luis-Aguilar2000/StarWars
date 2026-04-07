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

        private async Task<List<EspecieJsonModel>> ObtenerTodasLasEspeciesApi()
        {
            var todasLasEspecies = new List<EspecieJsonModel>();
            string endpoint = "species/";

            while (!string.IsNullOrEmpty(endpoint))
            {
                var result = await _restApi.Get<PeopleResponse<EspecieJsonModel>>(
                    "https://swapi.dev/api/",
                    endpoint
                );

                if (result?.Results != null && result.Results.Any())
                {
                    todasLasEspecies.AddRange(result.Results);
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

            return todasLasEspecies;
        }

        public async Task SincronizarEspecies()
        {
            var especiesApi = await ObtenerTodasLasEspeciesApi();

            if (especiesApi == null || !especiesApi.Any())
                return;

            var urlsApi = especiesApi
                .Select(x => x.Url)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            var urlsExistentes = await _context.Especies
                .Where(e => urlsApi.Contains(e.Url))
                .Select(e => e.Url)
                .ToListAsync();

            var nuevasEspecies = especiesApi
                .Where(item => !urlsExistentes.Contains(item.Url))
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
            var lista = await _context.Especies.ToListAsync();

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
                    (x.Clasificacion ?? "").ToLower().Contains(p) ||
                    (x.Designacion ?? "").ToLower().Contains(p) ||
                    (x.AlturaPromedio ?? "").ToLower().Contains(p) ||
                    (x.ColoresDePiel ?? "").ToLower().Contains(p) ||
                    (x.ColoresDePelo ?? "").ToLower().Contains(p) ||
                    (x.ColoresDeOjos ?? "").ToLower().Contains(p) ||
                    (x.EsperanzaDeVida ?? "").ToLower().Contains(p) ||
                    (x.Idioma ?? "").ToLower().Contains(p)
                ).ToList();
            }

            return lista;
        }
    }
}