using StarWars.Models;
namespace StarWars.Services
{
    public interface IPersonaService
    {
        Task<List<Persona>> ObtenerPersonasAsync();

        Task CrearPersonaAsync(Persona persona);
        Task ActualizarPersonaAsync(Persona persona);
        Task EliminarPersonaAsync(int id);
    }
}
