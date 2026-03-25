using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Models
{
    public class Transporte
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Modelo { get; set; }
        public string Fabricante {  get; set; }
        public string Longitud { get; set; }
        public int CostoEnCreditos { get; set; }
        public int Velocidad { get; set; }
        public string Tripulacion {  get; set; }
        public string Pasajeros {  get; set; }
        public string Capacidad { get; set; } 
        public string Comsumible { get; set; }
        public string MGLT { get; set; }
        public string Potencia { get; set; }
        public List<TipoTransporte> TipoTransporte { get; set; }

        public List<Persona> Personas { get; set; }
    }
}
