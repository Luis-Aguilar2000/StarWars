using StarWars.Models;

public interface ITransporteService
{
    Task<List<Transporte>> ObtenerTransportes();
    Task SincronizarTransportes();
    Task CrearTransporte(Transporte transporte);
    Task ActualizarTransporte(Transporte transporte);
    Task EliminarTransporte(int id);
    Task InicializarTipos();
}