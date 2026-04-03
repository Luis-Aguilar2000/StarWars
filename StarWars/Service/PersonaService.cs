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
            {
                return await _context.Personas
                    .Include(p => p.Peliculas)
                    .Include(p => p.Planeta)
                    .Include(p => p.Especie)
                    .Include(p => p.Transportes)
                    .ToListAsync();
            }

            // Cargar todo primero una sola vez
            var personasDB = await _context.Personas
                .Include(p => p.Peliculas)
                .Include(p => p.Planeta)
                .Include(p => p.Especie)
                .Include(p => p.Transportes)
                .ToListAsync();

            var peliculasDB = await _context.Peliculas.ToListAsync();
            var planetasDB = await _context.Planetas.ToListAsync();
            var especiesDB = await _context.Especies.ToListAsync();
            var transportesDB = await _context.Transportes.ToListAsync();

            foreach (var item in result.Results)
            {
                var persona = personasDB.FirstOrDefault(p => p.Nombre == item.Name);

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
                        Picture = "",
                        Peliculas = new List<Pelicula>(),
                        Especie = new List<Especie>(),
                        Transportes = new List<Transporte>()
                    };

                    _context.Personas.Add(persona);
                    personasDB.Add(persona);
                }
                else
                {
                    persona.Nombre = item.Name ?? "";
                    persona.Altura = item.Height ?? "";
                    persona.Masa = item.Mass ?? "";
                    persona.ColorDePiel = item.SkinColor ?? "";
                    persona.ColorDeOjos = item.EyeColor ?? "";
                    persona.ColorDePelo = item.HairColor ?? "";
                    persona.Cumpleaños = item.BirthYear ?? "";
                    persona.Genero = item.Gender ?? "";
                }

                // Películas
                persona.Peliculas.Clear();

                if (item.Films != null && item.Films.Any())
                {
                    var peliculas = peliculasDB
                        .Where(p => !string.IsNullOrEmpty(p.Url) && item.Films.Contains(p.Url))
                        .ToList();

                    foreach (var pelicula in peliculas)
                    {
                        persona.Peliculas.Add(pelicula);
                    }
                }

                // Planeta
                persona.Planeta = null;

                if (!string.IsNullOrEmpty(item.Homeworld))
                {
                    var planeta = planetasDB.FirstOrDefault(p => p.Url == item.Homeworld);
                    persona.Planeta = planeta;
                }

                // Especies
                persona.Especie.Clear();

                if (item.Species != null && item.Species.Any())
                {
                    var especies = especiesDB
                        .Where(e => !string.IsNullOrEmpty(e.Url) && item.Species.Contains(e.Url))
                        .ToList();

                    foreach (var especie in especies)
                    {
                        persona.Especie.Add(especie);
                    }
                }

                // Transportes
                persona.Transportes.Clear();

                var urlsTransportes = new List<string>();

                if (item.Vehicles != null && item.Vehicles.Any())
                    urlsTransportes.AddRange(item.Vehicles);

                if (item.Starships != null && item.Starships.Any())
                    urlsTransportes.AddRange(item.Starships);

                if (urlsTransportes.Any())
                {
                    var transportes = transportesDB
                        .Where(t => !string.IsNullOrEmpty(t.Url) && urlsTransportes.Contains(t.Url))
                        .ToList();

                    foreach (var transporte in transportes)
                    {
                        persona.Transportes.Add(transporte);
                    }
                }
            }

            await _context.SaveChangesAsync();

            return await _context.Personas
                .Include(p => p.Peliculas)
                .Include(p => p.Planeta)
                .Include(p => p.Especie)
                .Include(p => p.Transportes)
                .ToListAsync();
        }

        public async Task CrearPersonaAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarPersonaAsync(Persona persona)
        {
            if (persona == null)
                throw new Exception("La persona viene null");

            var existente = await _context.Personas.FindAsync(persona.Id);

            if (existente == null) return;

            existente.Nombre = persona.Nombre;
            existente.Altura = persona.Altura;
            existente.Masa = persona.Masa;
            existente.ColorDePiel = persona.ColorDePiel;
            existente.ColorDeOjos = persona.ColorDeOjos;
            existente.ColorDePelo = persona.ColorDePelo;
            existente.Cumpleaños = persona.Cumpleaños;
            existente.Genero = persona.Genero;
            existente.Picture = persona.Picture;

            await _context.SaveChangesAsync();
        }

        public async Task EliminarPersonaAsync(int id)
        {
            var persona = await _context.Personas.FindAsync(id);

            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }
    }
}