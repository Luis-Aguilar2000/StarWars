using Microsoft.VisualBasic.ApplicationServices;
using StarWars.Models;
namespace StarWars.Services
{
    public interface IPersonaService
    {
        Task<List<Persona>> ObtenerPersonas();
        Task SincronizarPersonas();

        Task CrearPersona(Persona persona, int? especieId, List<int> peliculasIds, List<int> transportesIds);
        Task ActualizarPersona(Persona persona, int? especieId, List<int> peliculasIds, List<int> transportesIds);
        Task EliminarPersona(int id);

        Task<List<Persona>> BuscarAsync(string filtro);
        Task RelacionarPersonasAsync();
    }
}
