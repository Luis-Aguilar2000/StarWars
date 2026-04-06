using StarWars.Models;

namespace StarWars.Services
{
    public interface IEspecieService
    {
        Task<List<Especie>> ObtenerEspecies();
        Task SincronizarEspecies();
        Task CrearEspecie(Especie especie);
        Task ActualizarEspecie(Especie especie);
        Task EliminarEspecie(int id);

        Task<List<Especie>> BuscarAsync(string filtro);
    }
}