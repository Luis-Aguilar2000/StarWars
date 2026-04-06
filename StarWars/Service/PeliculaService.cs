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

        public async Task SincronizarPeliculas()
        {
            var result = await _restApi.Get<PeopleResponse<PeliculaJsonModel>>(
                "https://swapi.dev/api/",
                "films/"
            );

            if (result?.Results == null || !result.Results.Any())
                return;

            var titulosApi = result.Results
                .Select(x => x.Title)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            var titulosExistentes = await _context.Peliculas
                .Where(p => titulosApi.Contains(p.Titulo))
                .Select(p => p.Titulo)
                .ToListAsync();

            var nuevasPeliculas = result.Results
                .Where(item => !titulosExistentes.Contains(item.Title))
                .Select(item => new Pelicula
                {
                    Titulo = item.Title,
                    Episode_id = item.EpisodeId,
                    Avance = item.OpeningCrawl,
                    Director = item.Director,
                    Productor = item.Producer,
                    FechaDeLanzamiento = item.ReleaseDate,
                    Picture = "",
                    Url = item.Url
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
            var query = _context.Peliculas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var palabras = BuscarHelper.ObtenerPalabras(filtro.ToLower());

                foreach (var palabra in palabras)
                {
                    var p1 = palabra;

                    query = query.Where(p =>
                        (p.Titulo != null && p.Titulo.ToLower().Contains(p1)) ||
                        (p.Director != null && p.Director.ToLower().Contains(p1)) ||
                        (p.Productor != null && p.Productor.ToLower().Contains(p1))
                    );
                }
            }

            return await query.ToListAsync();
        }


    }
}