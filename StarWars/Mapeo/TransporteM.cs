using StarWars.Models;
using StarWars.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Mapeo
{
    public class TransporteM
    {
        public static Transporte FromVehicle(Vehiculo api)
        {
            return new Transporte
            {
                Nombre = api.name,
                Modelo = api.model,
                Fabricante = api.manufacturer,
                Longitud = api.length,
                CostoEnCreditos = ParseInt(api.cost_in_credits),
                Velocidad = ParseInt(api.max_atmosphering_speed),
                Tripulacion = api.crew,
                Pasajeros = api.passengers,
                Capacidad = api.cargo_capacity,
                Comsumible = api.consumables,

                // No vienen en vehicles
                MGLT = null,
                Potencia = null,

                TipoTransporte = new TipoTransporte
                {
                    Nombre = "Vehículo"
                }
            };
        }

        public static Transporte FromStarship(NaveSW api)
        {
            return new Transporte
            {
                Nombre = api.name,
                Modelo = api.model,
                Fabricante = api.manufacturer,
                Longitud = api.length,
                CostoEnCreditos = ParseInt(api.cost_in_credits),
                Velocidad = ParseInt(api.max_atmosphering_speed),
                Tripulacion = api.crew,
                Pasajeros = api.passengers,
                Capacidad = api.cargo_capacity,
                Comsumible = api.consumables,

                MGLT = api.MGLT,
                Potencia = api.hyperdrive_rating,

                TipoTransporte = new TipoTransporte
                {
                    Nombre = "Nave"
                }
            };
        }

        private static int ParseInt(string value)
        {
            return int.TryParse(value, out int result) ? result : 0;
        }
    }
}

