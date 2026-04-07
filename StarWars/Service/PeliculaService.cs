using Microsoft.EntityFrameworkCore;
using RestLibrary.Interfaces;
using StarWars.Data;
using StarWars.Dtos;
using StarWars.Helper;
using StarWars.Models;

namespace StarWars.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRestApi _restApi;

        public PeliculaService(ApplicationDbContext context, IRestApi restApi)
        {
            _context = context;
            _restApi = restApi;
        }

        public async Task<List<Pelicula>> ObtenerPeliculas()
        {
            return await _context.Peliculas
                .AsNoTracking()
                .OrderBy(p => p.Titulo)
                .ToListAsync();
        }

        private async Task<List<PeliculaJsonModel>> ObtenerTodasLasPeliculasApi()
        {
            var todasLasPeliculas = new List<PeliculaJsonModel>();
            string endpoint = "films/";

            while (!string.IsNullOrEmpty(endpoint))
            {
                var result = await _restApi.Get<PeopleResponse<PeliculaJsonModel>>(
                    "https://swapi.dev/api/",
                    endpoint
                );

                if (result?.Results != null && result.Results.Any())
                {
                    todasLasPeliculas.AddRange(result.Results);
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

            return todasLasPeliculas;
        }

        public async Task SincronizarPeliculas()
        {
            var peliculasApi = await ObtenerTodasLasPeliculasApi();

            if (peliculasApi == null || !peliculasApi.Any())
                return;

            var urlsApi = peliculasApi
                .Select(x => x.Url)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            var urlsExistentes = await _context.Peliculas
                .Where(p => urlsApi.Contains(p.Url))
                .Select(p => p.Url)
                .ToListAsync();

            var nuevasPeliculas = peliculasApi
                .Where(item => !urlsExistentes.Contains(item.Url))
                .Select(item => new Pelicula
                {
                    Titulo = item.Title,
                    Episode_id = item.EpisodeId,
                    Avance = item.OpeningCrawl,
                    Director = item.Director,
                    Productor = item.Producer,
                    FechaDeLanzamiento = item.ReleaseDate,
                    Url = item.Url,
                    Picture = ""
                })
                .ToList();

            if (nuevasPeliculas.Any())
            {
                await _context.Peliculas.AddRangeAsync(nuevasPeliculas);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CrearPelicula(Pelicula pelicula)
        {
            if (pelicula == null) return;

            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarPelicula(Pelicula pelicula)
        {
            if (pelicula == null) return;

            var peliculaExistente = await _context.Peliculas
                .FirstOrDefaultAsync(p => p.Id == pelicula.Id);

            if (peliculaExistente == null) return;

            peliculaExistente.Titulo = pelicula.Titulo;
            peliculaExistente.Episode_id = pelicula.Episode_id;
            peliculaExistente.Avance = pelicula.Avance;
            peliculaExistente.Director = pelicula.Director;
            peliculaExistente.Productor = pelicula.Productor;
            peliculaExistente.FechaDeLanzamiento = pelicula.FechaDeLanzamiento;
            peliculaExistente.Picture = pelicula.Picture;
            peliculaExistente.Url = pelicula.Url;

            await _context.SaveChangesAsync();
        }

        public async Task EliminarPelicula(int id)
        {
            var pelicula = await _context.Peliculas
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula == null) return;

            _context.Peliculas.Remove(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pelicula>> BuscarAsync(string filtro)
        {
            var lista = await _context.Peliculas.ToListAsync();

            if (string.IsNullOrWhiteSpace(filtro))
                return lista;

            var palabras = filtro
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var palabra in palabras)
            {
                var p = palabra;

                lista = lista.Where(x =>
                    (x.Titulo ?? "").ToLower().Contains(p) ||
                    x.Episode_id.ToString().Contains(p) ||
                    (x.Director ?? "").ToLower().Contains(p) ||
                    (x.Productor ?? "").ToLower().Contains(p) ||
                    (x.FechaDeLanzamiento ?? "").ToLower().Contains(p) ||
                    (x.Avance ?? "").ToLower().Contains(p)
                ).ToList();
            }

            return lista;
        }


    }
}