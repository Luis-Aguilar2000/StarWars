using StarWars.Models;

namespace StarWars.Services
{
    public interface IEspecieService
    {
        Task<List<Especie>> ObtenerEspeciesAsync();
    }
}