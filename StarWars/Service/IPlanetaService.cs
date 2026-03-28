using StarWars.Models;

namespace StarWars.Services
{
    public interface IPlanetaService
    {
        Task<List<Planeta>> ObtenerPlanetasAsync();
    }
}