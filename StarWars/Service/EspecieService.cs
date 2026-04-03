using Microsoft.EntityFrameworkCore;
using RestLibrary.Interfaces;
using StarWars.Data;
using StarWars.Dtos;
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

        public async Task<List<Especie>> ObtenerEspeciesAsync()
        {
            var result = await _restApi.Get<PeopleResponse<EspecieJsonModel>>(
                "https://swapi.dev/api/",
                "species/"
            );

            if (result?.Results == null || !result.Results.Any())
                return await _context.Especies.ToListAsync();

            // Traer una sola vez las especies guardadas
            var especiesGuardadas = await _context.Especies.ToListAsync();

            foreach (var item in result.Results)
            {
                bool existe = especiesGuardadas.Any(e => e.Nombre == item.Name);

                if (!existe)
                {
                    var especie = new Especie
                    {
                        Nombre = item.Name ?? "",
                        Clasificacion = item.Classification ?? "",
                        Designacion = item.Designation ?? "",
                        AlturaPromedio = item.AverageHeight ?? "",
                        ColoresDePiel = item.SkinColors ?? "",
                        ColoresDePelo = item.HairColors ?? "",
                        ColoresDeOjos = item.EyeColors ?? "",
                        EsperanzaDeVida = item.AverageLifespan ?? "",
                        Idioma = item.Language ?? "",
                        Picture = "",
                        Url = item.Url ?? ""
                    };

                    _context.Especies.Add(especie);
                }
            }

            await _context.SaveChangesAsync();

            return await _context.Especies.ToListAsync();
        }

        public async Task CrearEspecieAsync(Especie especie)
        {
            _context.Especies.Add(especie);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarEspecieAsync(Especie especie)
        {
            var especieBD = await _context.Especies.FindAsync(especie.Id);

            if (especieBD != null)
            {
                especieBD.Nombre = especie.Nombre;
                especieBD.Clasificacion = especie.Clasificacion;
                especieBD.Designacion = especie.Designacion;
                especieBD.AlturaPromedio = especie.AlturaPromedio;
                especieBD.ColoresDePiel = especie.ColoresDePiel;
                especieBD.ColoresDePelo = especie.ColoresDePelo;
                especieBD.ColoresDeOjos = especie.ColoresDeOjos;
                especieBD.EsperanzaDeVida = especie.EsperanzaDeVida;
                especieBD.Idioma = especie.Idioma;
                especieBD.Picture = especie.Picture;
                especieBD.Url = especie.Url;

                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarEspecieAsync(int id)
        {
            var especie = await _context.Especies.FindAsync(id);

            if (especie != null)
            {
                _context.Especies.Remove(especie);
                await _context.SaveChangesAsync();
            }
        }
    }
}