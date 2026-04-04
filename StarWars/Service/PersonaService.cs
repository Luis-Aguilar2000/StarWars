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

        public async Task<List<Persona>> ObtenerPersonas()
        {
            return await _context.Personas
                .Include(p => p.Planeta)
                .Include(p => p.Peliculas)
                .Include(p => p.Especie)
                .Include(p => p.Transportes)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task SincronizarPersonas()
        {
            var result = await _restApi.Get<PeopleResponse<PersonajeJsonModel>>(
                "https://swapi.dev/api/",
                "people/"
            );

            if (result?.Results == null || !result.Results.Any())
                return;

            var nombresApi = result.Results
                .Select(x => x.Name)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            var nombresExistentes = await _context.Personas
                .Where(p => nombresApi.Contains(p.Nombre))
                .Select(p => p.Nombre)
                .ToListAsync();

            var nuevasPersonas = result.Results
                .Where(item => !nombresExistentes.Contains(item.Name))
                .Select(item => new Persona
                {
                    Nombre = item.Name,
                    Altura = item.Height,
                    Masa = item.Mass,
                    ColorDePiel = item.SkinColor,
                    ColorDeOjos = item.EyeColor,
                    ColorDePelo = item.HairColor,
                    Cumpleaños = item.BirthYear,
                    Genero = item.Gender,
                    Picture = ""
                })
                .ToList();

            if (nuevasPersonas.Any())
            {
                await _context.Personas.AddRangeAsync(nuevasPersonas);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CrearPersona(Persona persona, int? especieId, List<int> peliculasIds, List<int> transportesIds)
        {
            if (persona == null) return;

            if (especieId.HasValue)
            {
                var especie = await _context.Especies.FindAsync(especieId.Value);
                if (especie != null)
                {
                    persona.Especie = new List<Especie> { especie };
                }
            }

            if (peliculasIds != null && peliculasIds.Any())
            {
                var peliculas = await _context.Peliculas
                    .Where(p => peliculasIds.Contains(p.Id))
                    .ToListAsync();

                persona.Peliculas = peliculas;
            }

            if (transportesIds != null && transportesIds.Any())
            {
                var transportes = await _context.Transportes
                    .Where(t => transportesIds.Contains(t.Id))
                    .ToListAsync();

                persona.Transportes = transportes;
            }

            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarPersona(Persona persona, int? especieId, List<int> peliculasIds, List<int> transportesIds)
        {
            var personaBD = await _context.Personas
                .Include(p => p.Especie)
                .Include(p => p.Peliculas)
                .Include(p => p.Transportes)
                .FirstOrDefaultAsync(p => p.Id == persona.Id);

            if (personaBD == null) return;

            personaBD.Nombre = persona.Nombre;
            personaBD.Altura = persona.Altura;
            personaBD.Masa = persona.Masa;
            personaBD.ColorDePiel = persona.ColorDePiel;
            personaBD.ColorDeOjos = persona.ColorDeOjos;
            personaBD.ColorDePelo = persona.ColorDePelo;
            personaBD.Cumpleaños = persona.Cumpleaños;
            personaBD.Genero = persona.Genero;
            personaBD.Picture = persona.Picture;
            personaBD.PlanetaId = persona.PlanetaId;

            personaBD.Especie.Clear();
            personaBD.Peliculas.Clear();
            personaBD.Transportes.Clear();

            if (especieId.HasValue)
            {
                var especie = await _context.Especies.FindAsync(especieId.Value);
                if (especie != null)
                    personaBD.Especie.Add(especie);
            }

            if (peliculasIds != null && peliculasIds.Any())
            {
                var peliculas = await _context.Peliculas
                    .Where(p => peliculasIds.Contains(p.Id))
                    .ToListAsync();

                foreach (var pelicula in peliculas)
                    personaBD.Peliculas.Add(pelicula);
            }

            if (transportesIds != null && transportesIds.Any())
            {
                var transportes = await _context.Transportes
                    .Where(t => transportesIds.Contains(t.Id))
                    .ToListAsync();

                foreach (var transporte in transportes)
                    personaBD.Transportes.Add(transporte);
            }

            await _context.SaveChangesAsync();
        }
        public async Task EliminarPersona(int id)
        {
            var persona = await _context.Personas
                .FirstOrDefaultAsync(p => p.Id == id);

            if (persona == null) return;

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
        }
    }
}