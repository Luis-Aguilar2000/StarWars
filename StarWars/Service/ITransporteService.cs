using StarWars.Models;

public interface ITransporteService
{
    Task<List<Transporte>> ObtenerTransportesAsync();
    Task CrearTransporteAsync(Transporte transporte);
    Task ActualizarTransporteAsync(Transporte transporte);
    Task EliminarTransporteAsync(int id);
    Task InicializarTiposAsync();
}