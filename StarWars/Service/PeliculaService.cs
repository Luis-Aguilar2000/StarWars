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
                        FechaDeLanzamiento = item.ReleaseDate
                    };

                    _context.Peliculas.Add(pelicula);
                }
            }

            await _context.SaveChangesAsync();

            return await _context.Peliculas.ToListAsync();
        }
    }
}