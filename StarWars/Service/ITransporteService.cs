using StarWars.Models;

public interface ITransporteService
{
    Task<List<Transporte>> ObtenerTransportes();
    Task<List<TipoTransporte>> ObtenerTiposTransporte();
    Task SincronizarTransportes();
    Task CrearTransporte(Transporte transporte);
    Task ActualizarTransporte(Transporte transporte);
    Task EliminarTransporte(int id);
    Task InicializarTipos();
}