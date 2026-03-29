using StarWars.Models;

namespace StarWars.Services
{
    public interface IPeliculaService
    {
        Task<List<Pelicula>> ObtenerPeliculasAsync();
    }
}