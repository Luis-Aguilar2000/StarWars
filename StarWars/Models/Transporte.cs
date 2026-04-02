using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Models
{
    public class Transporte
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Fabricante { get; set; } = string.Empty;
        public string CostoEnCreditos { get; set; } = string.Empty;
        public string Longitud { get; set; } = string.Empty;
        public string VelocidadMaximaAtmosfera { get; set; } = string.Empty;
        public string Tripulacion { get; set; } = string.Empty;
        public string Pasajeros { get; set; } = string.Empty;
        public string CapacidadCarga { get; set; } = string.Empty;
        public string Consumibles { get; set; } = string.Empty;
        public string MGLT { get; set; } = string.Empty;
        public string Clase { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string? Picture { get; set; }

        public int TipoTransporteId { get; set; }
        public TipoTransporte TipoTransporte { get; set; } = null!;

        public List<Persona> Personas { get; set; } = new();
        public List<Pelicula> Peliculas { get; set; } = new();
    }
}