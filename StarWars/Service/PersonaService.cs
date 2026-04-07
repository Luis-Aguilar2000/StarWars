using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using RestLibrary.Interfaces;
using StarWars.Data;
using StarWars.Dtos;
using StarWars.Helper;
using StarWars.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        private async Task<List<PersonajeJsonModel>> ObtenerTodasLasPersonasApi()
        {
            var todasLasPersonas = new List<PersonajeJsonModel>();
            string endpoint = "people/";

            while (!string.IsNullOrEmpty(endpoint))
            {
                var result = await _restApi.Get<PeopleResponse<PersonajeJsonModel>>(
                    "https://swapi.dev/api/",
                    endpoint
                );

                if (result?.Results != null && result.Results.Any())
                {
                    todasLasPersonas.AddRange(result.Results);
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

            return todasLasPersonas;
        }

        public async Task SincronizarPersonas()
        {
            var personasApi = await ObtenerTodasLasPersonasApi();

            if (personasApi == null || !personasApi.Any())
                return;

            var nombresApi = personasApi
                .Select(x => x.Name)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            var nombresExistentes = await _context.Personas
                .Where(p => nombresApi.Contains(p.Nombre))
                .Select(p => p.Nombre)
                .ToListAsync();

            var nuevasPersonas = personasApi
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
        public async Task<List<Persona>> BuscarAsync(string filtro)
        {
            var lista = await _context.Personas
                .Include(p => p.Planeta)
                .Include(p => p.Especie)
                .Include(p => p.Peliculas)
                .Include(p => p.Transportes)
                .ToListAsync();

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
                    (x.Altura ?? "").ToLower().Contains(p) ||
                    (x.Masa ?? "").ToLower().Contains(p) ||
                    (x.ColorDeOjos ?? "").ToLower().Contains(p) ||
                    (x.ColorDePiel ?? "").ToLower().Contains(p) ||
                    (x.ColorDePelo ?? "").ToLower().Contains(p) ||
                    (x.Genero ?? "").ToLower().Contains(p) ||
                    (x.Planeta != null && (x.Planeta.Nombre ?? "").ToLower().Contains(p)) ||
                    x.Especie.Any(e => (e.Nombre ?? "").ToLower().Contains(p)) ||
                    x.Peliculas.Any(pe => (pe.Titulo ?? "").ToLower().Contains(p)) ||
                    x.Transportes.Any(t => (t.Nombre ?? "").ToLower().Contains(p))
                ).ToList();
            }

            return lista;
        }

        public async Task RelacionarPersonasAsync()
        {
            var personasApi = await ObtenerTodasLasPersonasApi();

            if (personasApi == null || !personasApi.Any())
                return;

            var personasBd = await _context.Personas
                .Include(p => p.Planeta)
                .Include(p => p.Peliculas)
                .Include(p => p.Especie)
                .Include(p => p.Transportes)
                .ToListAsync();

            foreach (var item in personasApi)
            {
                if (string.IsNullOrWhiteSpace(item.Name))
                    continue;

                var personaBd = personasBd.FirstOrDefault(p => p.Nombre == item.Name);

                if (personaBd == null)
                    continue;

                // PLANETA
                if (!string.IsNullOrWhiteSpace(item.Homeworld))
                {
                    var planeta = await _context.Planetas
                        .FirstOrDefaultAsync(p => p.Url == item.Homeworld);

                    if (planeta != null)
                    {
                        personaBd.PlanetaId = planeta.Id;
                    }
                }

                // PELÍCULAS
                if (item.Films != null && item.Films.Any())
                {
                    var peliculas = await _context.Peliculas
                        .Where(p => item.Films.Contains(p.Url))
                        .ToListAsync();

                    personaBd.Peliculas.Clear();

                    foreach (var pelicula in peliculas)
                    {
                        personaBd.Peliculas.Add(pelicula);
                    }
                }

                // ESPECIES
                if (item.Species != null && item.Species.Any())
                {
                    var especies = await _context.Especies
                        .Where(e => item.Species.Contains(e.Url))
                        .ToListAsync();

                    personaBd.Especie.Clear();

                    foreach (var especie in especies)
                    {
                        personaBd.Especie.Add(especie);
                    }
                }

                // TRANSPORTES
                var urlsTransportes = new List<string>();

                if (item.Vehicles != null && item.Vehicles.Any())
                    urlsTransportes.AddRange(item.Vehicles);

                if (item.Starships != null && item.Starships.Any())
                    urlsTransportes.AddRange(item.Starships);

                if (urlsTransportes.Any())
                {
                    var transportes = await _context.Transportes
                        .Where(t => urlsTransportes.Contains(t.Url))
                        .ToListAsync();

                    personaBd.Transportes.Clear();

                    foreach (var transporte in transportes)
                    {
                        personaBd.Transportes.Add(transporte);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}