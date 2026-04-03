using Microsoft.EntityFrameworkCore;
using RestLibrary.Interfaces;
using StarWars.Data;
using StarWars.Dtos;
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

            var nuevasPeliculas = new List<Pelicula>();

            foreach (var item in result.Results)
            {
                bool existe = await _context.Peliculas
                    .AnyAsync(p => p.Titulo == item.Title);

                if (!existe)
                {
                    var pelicula = new Pelicula
                    {
                        Titulo = item.Title,
                        Episode_id = item.EpisodeId,
                        Avance = item.OpeningCrawl,
                        Director = item.Director,
                        Productor = item.Producer,
                        FechaDeLanzamiento = item.ReleaseDate,
                        Picture = "",
                        Url = item.Url
                    };

                    nuevasPeliculas.Add(pelicula);
                }
            }

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
    }
}