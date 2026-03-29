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
                return await _context.Personas
                    .Include(p => p.Peliculas)
                    .Include(p => p.Planeta)
                    .Include(p => p.Especie)
                    .ToListAsync();

            foreach (var item in result.Results)
            {
                var persona = await _context.Personas
                    .Include(p => p.Peliculas)
                    .Include(p => p.Planeta)
                    .Include(p => p.Especie)
                    .FirstOrDefaultAsync(p => p.Nombre == item.Name);

                if (persona == null)
                {
                    persona = new Persona
                    {
                        Nombre = item.Name ?? "",
                        Altura = item.Height ?? "",
                        Masa = item.Mass ?? "",
                        ColorDePiel = item.SkinColor ?? "",
                        ColorDeOjos = item.EyeColor ?? "",
                        ColorDePelo = item.HairColor ?? "",
                        Cumpleaños = item.BirthYear ?? "",
                        Genero = item.Gender ?? "",
                        Picture = ""
                    };

                    _context.Personas.Add(persona);
                }

                var peliculas = await _context.Peliculas
                    .Where(p => item.Films.Contains(p.Url))
                    .ToListAsync();

                persona.Peliculas.Clear();

                foreach (var pelicula in peliculas)
                {
                    persona.Peliculas.Add(pelicula);
                }

                var planeta = await _context.Planetas
                    .FirstOrDefaultAsync(p => p.Url == item.Homeworld);

                persona.Planeta = planeta;

                // AGREGADO: relacionar especies
                var especies = await _context.Especies
                    .Where(e => item.Species.Contains(e.Url))
                    .ToListAsync();

                persona.Especie.Clear();

                foreach (var especie in especies)
                {
                    persona.Especie.Add(especie);
                }
            }

            await _context.SaveChangesAsync();

            return await _context.Personas
                .Include(p => p.Peliculas)
                .Include(p => p.Planeta)
                .Include(e => e.Especie)
                .ToListAsync();
        }
    }
}