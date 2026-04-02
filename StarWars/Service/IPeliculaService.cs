using StarWars.Models;

namespace StarWars.Services
{
    public interface IPeliculaService
    {
        Task<List<Pelicula>> ObtenerPeliculasAsync();
        Task CrearPeliculaAsync(Pelicula pelicula);
        Task ActualizarPeliculaAsync(Pelicula pelicula);
        Task EliminarPeliculaAsync(int id);
    }
}