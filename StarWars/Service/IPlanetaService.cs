using StarWars.Models;

namespace StarWars.Services
{
    public interface IPlanetaService
    {
        Task<List<Planeta>> ObtenerPlanetasAsync();
        Task CrearPlanetaAsync(Planeta planeta);
        Task ActualizarPlanetaAsync(Planeta planeta);
        Task EliminarPlanetaAsync(int id);
    }
}