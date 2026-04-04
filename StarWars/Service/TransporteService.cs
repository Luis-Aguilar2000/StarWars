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

        public async Task InicializarTipos()
        {
            if (!await _context.TipoTransporte.AnyAsync())
            {
                _context.TipoTransporte.Add(new TipoTransporte { Nombre = "Nave" });
                _context.TipoTransporte.Add(new TipoTransporte { Nombre = "Vehículo" });

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Transporte>> ObtenerTransportes()
        {
            return await _context.Transportes
                .Include(t => t.TipoTransporte)
                .AsNoTracking()
                .OrderBy(t => t.Nombre)
                .ToListAsync();
        }

        public async Task SincronizarTransportes()
        {
            await InicializarTipos();

            var tipos = await _context.TipoTransporte.ToListAsync();

            var tipoNave = tipos.FirstOrDefault(t => t.Nombre == "Nave");
            var tipoVehiculo = tipos.FirstOrDefault(t => t.Nombre == "Vehículo");

            if (tipoNave == null || tipoVehiculo == null)
                return;

            var urlsGuardadas = await _context.Transportes
                .Where(t => !string.IsNullOrWhiteSpace(t.Url))
                .Select(t => t.Url)
                .ToListAsync();

            var setUrls = new HashSet<string>(urlsGuardadas);

            var nuevosTransportes = new List<Transporte>();

            // NAVES
            var naves = await _restApi.Get<PeopleResponse<TransporteJsonModel>>(
                "https://swapi.dev/api/",
                "starships/"
            );

            if (naves?.Results != null && naves.Results.Any())
            {
                foreach (var item in naves.Results)
                {
                    string url = item.Url ?? "";

                    if (!string.IsNullOrWhiteSpace(url) && !setUrls.Contains(url))
                    {
                        nuevosTransportes.Add(new Transporte
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
                            Url = url,
                            TipoTransporteId = tipoNave.Id
                        });

                        setUrls.Add(url);
                    }
                }
            }

            // VEHÍCULOS
            var vehiculos = await _restApi.Get<PeopleResponse<TransporteJsonModel>>(
                "https://swapi.dev/api/",
                "vehicles/"
            );

            if (vehiculos?.Results != null && vehiculos.Results.Any())
            {
                foreach (var item in vehiculos.Results)
                {
                    string url = item.Url ?? "";

                    if (!string.IsNullOrWhiteSpace(url) && !setUrls.Contains(url))
                    {
                        nuevosTransportes.Add(new Transporte
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
                            Url = url,
                            TipoTransporteId = tipoVehiculo.Id
                        });

                        setUrls.Add(url);
                    }
                }
            }

            if (nuevosTransportes.Any())
            {
                await _context.Transportes.AddRangeAsync(nuevosTransportes);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CrearTransporte(Transporte transporte)
        {
            if (transporte == null) return;

            _context.Transportes.Add(transporte);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarTransporte(Transporte transporte)
        {
            if (transporte == null) return;

            var transporteBD = await _context.Transportes.FindAsync(transporte.Id);

            if (transporteBD == null) return;

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

        public async Task EliminarTransporte(int id)
        {
            var transporte = await _context.Transportes.FindAsync(id);

            if (transporte == null) return;

            _context.Transportes.Remove(transporte);
            await _context.SaveChangesAsync();
        }
        public async Task<List<TipoTransporte>> ObtenerTiposTransporte()
        {
            return await _context.TipoTransporte.ToListAsync();
        }
    }
}