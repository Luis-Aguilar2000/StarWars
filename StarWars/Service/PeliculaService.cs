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

        public async Task<List<Pelicula>> ObtenerPeliculasAsync()
        {
            var result = await _restApi.Get<PeopleResponse<PeliculaJsonModel>>(
                "https://swapi.dev/api/",
                "films/"
            );

            if (result?.Results == null || !result.Results.Any())
                return await _context.Peliculas.ToListAsync();

            var peliculasGuardadas = await _context.Peliculas.ToListAsync();

            foreach (var item in result.Results)
            {
                bool existe = peliculasGuardadas.Any(p => p.Titulo == item.Title);

                if (!existe)
                {
                    var pelicula = new Pelicula
                    {
                        Titulo = item.Title ?? "",
                        Episode_id = item.EpisodeId,
                        Avance = item.OpeningCrawl ?? "",
                        Director = item.Director ?? "",
                        Productor = item.Producer ?? "",
                        FechaDeLanzamiento = item.ReleaseDate ?? "",
                        Picture = "",
                        Url = item.Url ?? ""
                    };

                    _context.Peliculas.Add(pelicula);
                }
            }

            await _context.SaveChangesAsync();

            return await _context.Peliculas.ToListAsync();
        }

        public async Task CrearPeliculaAsync(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarPeliculaAsync(Pelicula pelicula)
        {
            var peliculaBD = await _context.Peliculas.FindAsync(pelicula.Id);

            if (peliculaBD != null)
            {
                peliculaBD.Titulo = pelicula.Titulo;
                peliculaBD.Episode_id = pelicula.Episode_id;
                peliculaBD.Avance = pelicula.Avance;
                peliculaBD.Director = pelicula.Director;
                peliculaBD.Productor = pelicula.Productor;
                peliculaBD.FechaDeLanzamiento = pelicula.FechaDeLanzamiento;
                peliculaBD.Picture = pelicula.Picture;
                peliculaBD.Url = pelicula.Url;

                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarPeliculaAsync(int id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);

            if (pelicula != null)
            {
                _context.Peliculas.Remove(pelicula);
                await _context.SaveChangesAsync();
            }
        }
    }
}