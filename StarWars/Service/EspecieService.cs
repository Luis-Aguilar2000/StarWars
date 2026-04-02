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

            foreach (var item in result.Results)
            {
                bool existe = await _context.Especies
                    .AnyAsync(e => e.Nombre == item.Name);

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

        // Implementación de métodos para agregar, actualizar y eliminar especies

        public async Task EliminarEspecieAsync(int id)
        {
            var persona = await _context.Personas.FindAsync(id);

            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }

        public Task CrearEspecieAsync(Especie especie)
        {
            throw new NotImplementedException();
        }

        public Task ActualizarEspecieAsync(Especie especie)
        {
            throw new NotImplementedException();
        }
    }
}