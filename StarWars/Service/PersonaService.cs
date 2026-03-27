using Microsoft.EntityFrameworkCore;
using RestLibrary.Interfaces;
using StarWars.Data;
using StarWars.Dtos;
using StarWars.Models;

namespace StarWars.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRestApi _restApi;

        public PersonaService(ApplicationDbContext context, IRestApi restApi)
        {
            _context = context;
            _restApi = restApi;
        }

        public async Task<List<Persona>> ObtenerPersonasAsync()
        {
            var result = await _restApi.Get<PeopleResponse<PersonajeJsonModel>>(
                "https://swapi.dev/api/",
                "people/"
            );

            if (result?.Results == null || !result.Results.Any())
                return await _context.Personas.ToListAsync();

            foreach (var item in result.Results)
            {
                bool existe = await _context.Personas
                    .AnyAsync(p => p.Nombre == item.Name);

                if (!existe)
                {
                    var persona = new Persona
                    {
                        Nombre = item.Name,
                        Altura = item.Height,
                        Masa = item.Mass,
                        ColorDePiel = item.SkinColor,
                        ColorDeOjos = item.EyeColor,
                        ColorDePelo = item.HairColor,
                        Cumpleaños = item.BirthYear,
                        Genero = item.Gender
                    };

                    _context.Personas.Add(persona);
                }
            }

            await _context.SaveChangesAsync();

            return await _context.Personas.ToListAsync();
        }
    }
}