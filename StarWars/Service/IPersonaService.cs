using StarWars.Models;
namespace StarWars.Services
{
    public interface IPersonaService
    {
        Task<List<Persona>> ObtenerPersonasAsync();
    }
}