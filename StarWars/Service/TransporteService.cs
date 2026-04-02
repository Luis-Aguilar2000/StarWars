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

        public Task ActualizarTransporteAsync(Transporte transporte)
        {
            throw new NotImplementedException();
        }

        public Task CrearTransporteAsync(Transporte transporte)
        {
            throw new NotImplementedException();
        }

        public Task EliminarTransporteAsync(int id)
        {
            throw new NotImplementedException();
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

            var naves = await _restApi.Get<PeopleResponse<TransporteJsonModel>>(
                "https://swapi.dev/api/",
                "starships/"
            );

            if (naves?.Results == null || !naves.Results.Any())
            {
                return await _context.Transportes
                    .Include(t => t.TipoTransporte)
                    .ToListAsync();
            }

            foreach (var item in naves.Results)
            {
                bool existe = await _context.Transportes
                    .AnyAsync(t => t.Url == item.Url);

                if (!existe)
                {
                    _context.Transportes.Add(new Transporte
                    {
                        Nombre = item.Name,
                        Modelo = item.Model,
                        Fabricante = item.Manufacturer,
                        CostoEnCreditos = item.Cost,
                        Longitud = item.Length,
                        VelocidadMaximaAtmosfera = item.MaxAtmospheringSpeed,
                        Tripulacion = item.Crew,
                        Pasajeros = item.Passengers,
                        CapacidadCarga = item.CargoCapacity,
                        Consumibles = item.Consumables,
                        MGLT = item.MGLT ?? "",
                        Clase = item.StarshipClass ?? "",
                        Picture = "",
                        Url = item.Url,
                        TipoTransporteId = tipoNave.Id
                    });
                }
            }

            var vehiculos = await _restApi.Get<PeopleResponse<TransporteJsonModel>>(
                "https://swapi.dev/api/",
                "vehicles/"
            );

            if (vehiculos?.Results != null && vehiculos.Results.Any())
            {
                foreach (var item in vehiculos.Results)
                {
                    bool existe = await _context.Transportes
                        .AnyAsync(t => t.Url == item.Url);

                    if (!existe)
                    {
                        _context.Transportes.Add(new Transporte
                        {
                            Nombre = item.Name,
                            Modelo = item.Model,
                            Fabricante = item.Manufacturer,
                            CostoEnCreditos = item.Cost,
                            Longitud = item.Length,
                            VelocidadMaximaAtmosfera = item.MaxAtmospheringSpeed,
                            Tripulacion = item.Crew,
                            Pasajeros = item.Passengers,
                            CapacidadCarga = item.CargoCapacity,
                            Consumibles = item.Consumables,
                            MGLT = item.MGLT ?? "",
                            Clase = item.VehicleClass ?? "",
                            Picture = "",
                            Url = item.Url,
                            TipoTransporteId = tipoVehiculo.Id
                        });
                    }
                }
            }

            await _context.SaveChangesAsync();

            return await _context.Transportes
                .Include(t => t.TipoTransporte)
                .ToListAsync();
        }
    }
}