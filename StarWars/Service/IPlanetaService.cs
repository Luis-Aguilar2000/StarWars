using StarWars.Models;

namespace StarWars.Services
{
    public interface IPlanetaService
    {
        Task<List<Planeta>> ObtenerPlanetas();
        Task SincronizarPlanetas();
        Task CrearPlaneta(Planeta planeta);
        Task ActualizarPlaneta(Planeta planeta);
        Task EliminarPlaneta(int id);

        Task<List<Planeta>> BuscarAsync(string filtro);
    }
}