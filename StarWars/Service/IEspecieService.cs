using StarWars.Models;

namespace StarWars.Services
{
    public interface IEspecieService
    {
        Task<List<Especie>> ObtenerEspeciesAsync();
        Task CrearEspecieAsync(Especie especie);
        Task ActualizarEspecieAsync(Especie especie);
        Task EliminarEspecieAsync(int id);
    }
}