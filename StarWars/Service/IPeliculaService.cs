using StarWars.Models;

namespace StarWars.Services
{
    public interface IPeliculaService
    {
        Task<List<Pelicula>> ObtenerPeliculas();
        Task SincronizarPeliculas();
        Task CrearPelicula(Pelicula pelicula);
        Task ActualizarPelicula(Pelicula pelicula);
        Task EliminarPelicula(int id);
    }
}