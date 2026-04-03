using Microsoft.EntityFrameworkCore;
using RestLibrary.Interfaces;
using StarWars.Data;
using StarWars.Dtos;
using StarWars.Models;

namespace StarWars.Services
{
    public class TransporteService : ITransporteService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRestApi _restApi;

        public TransporteService(ApplicationDbContext context, IRestApi restApi)
        {
            _context = context;
            _restApi = restApi;
        }

        public async Task InicializarTiposAsync()
        {
            if (!await _context.TipoTransporte.AnyAsync())
            {
                _context.TipoTransporte.Add(new TipoTransporte { Nombre = "Nave" });
                _context.TipoTransporte.Add(new TipoTransporte { Nombre = "Vehículo" });

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Transporte>> ObtenerTransportesAsync()
        {
            await InicializarTiposAsync();

            var tipoNave = await _context.TipoTransporte
                .FirstOrDefaultAsync(t => t.Nombre == "Nave");

            var tipoVehiculo = await _context.TipoTransporte
                .FirstOrDefaultAsync(t => t.Nombre == "Vehículo");

            if (tipoNave == null || tipoVehiculo == null)
            {
                return await _context.Transportes
                    .Include(t => t.TipoTransporte)
                    .ToListAsync();
            }

            var transportesGuardados = await _context.Transportes.ToListAsync();

            // 🔹 NAVES
            var naves = await _restApi.Get<PeopleResponse<TransporteJsonModel>>(
                "https://swapi.dev/api/",
                "starships/"
            );

            if (naves?.Results != null && naves.Results.Any())
            {
                foreach (var item in naves.Results)
                {
                    bool existe = transportesGuardados.Any(t => t.Url == item.Url);

                    if (!existe)
                    {
                        var transporte = new Transporte
                        {
                            Nombre = item.Name ?? "",
                            Modelo = item.Model ?? "",
                            Fabricante = item.Manufacturer ?? "",
                            CostoEnCreditos = item.Cost ?? "",
                            Longitud = item.Length ?? "",
                            VelocidadMaximaAtmosfera = item.MaxAtmospheringSpeed ?? "",
                            Tripulacion = item.Crew ?? "",
                            Pasajeros = item.Passengers ?? "",
                            CapacidadCarga = item.CargoCapacity ?? "",
                            Consumibles = item.Consumables ?? "",
                            MGLT = item.MGLT ?? "",
                            Clase = item.StarshipClass ?? "",
                            Picture = "",
                            Url = item.Url ?? "",
                            TipoTransporteId = tipoNave.Id
                        };

                        _context.Transportes.Add(transporte);
                        transportesGuardados.Add(transporte);
                    }
                }
            }

            // 🔹 VEHÍCULOS
            var vehiculos = await _restApi.Get<PeopleResponse<TransporteJsonModel>>(
                "https://swapi.dev/api/",
                "vehicles/"
            );

            if (vehiculos?.Results != null && vehiculos.Results.Any())
            {
                foreach (var item in vehiculos.Results)
                {
                    bool existe = transportesGuardados.Any(t => t.Url == item.Url);

                    if (!existe)
                    {
                        var transporte = new Transporte
                        {
                            Nombre = item.Name ?? "",
                            Modelo = item.Model ?? "",
                            Fabricante = item.Manufacturer ?? "",
                            CostoEnCreditos = item.Cost ?? "",
                            Longitud = item.Length ?? "",
                            VelocidadMaximaAtmosfera = item.MaxAtmospheringSpeed ?? "",
                            Tripulacion = item.Crew ?? "",
                            Pasajeros = item.Passengers ?? "",
                            CapacidadCarga = item.CargoCapacity ?? "",
                            Consumibles = item.Consumables ?? "",
                            MGLT = item.MGLT ?? "",
                            Clase = item.VehicleClass ?? "",
                            Picture = "",
                            Url = item.Url ?? "",
                            TipoTransporteId = tipoVehiculo.Id
                        };

                        _context.Transportes.Add(transporte);
                        transportesGuardados.Add(transporte);
                    }
                }
            }

            await _context.SaveChangesAsync();

            return await _context.Transportes
                .Include(t => t.TipoTransporte)
                .ToListAsync();
        }

        public async Task CrearTransporteAsync(Transporte transporte)
        {
            _context.Transportes.Add(transporte);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarTransporteAsync(Transporte transporte)
        {
            var transporteBD = await _context.Transportes.FindAsync(transporte.Id);

            if (transporteBD != null)
            {
                transporteBD.Nombre = transporte.Nombre;
                transporteBD.Modelo = transporte.Modelo;
                transporteBD.Fabricante = transporte.Fabricante;
                transporteBD.CostoEnCreditos = transporte.CostoEnCreditos;
                transporteBD.Longitud = transporte.Longitud;
                transporteBD.VelocidadMaximaAtmosfera = transporte.VelocidadMaximaAtmosfera;
                transporteBD.Tripulacion = transporte.Tripulacion;
                transporteBD.Pasajeros = transporte.Pasajeros;
                transporteBD.CapacidadCarga = transporte.CapacidadCarga;
                transporteBD.Consumibles = transporte.Consumibles;
                transporteBD.MGLT = transporte.MGLT;
                transporteBD.Clase = transporte.Clase;
                transporteBD.Picture = transporte.Picture;
                transporteBD.Url = transporte.Url;
                transporteBD.TipoTransporteId = transporte.TipoTransporteId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarTransporteAsync(int id)
        {
            var transporte = await _context.Transportes.FindAsync(id);

            if (transporte != null)
            {
                _context.Transportes.Remove(transporte);
                await _context.SaveChangesAsync();
            }
        }
    }
}