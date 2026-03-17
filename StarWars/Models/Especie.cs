using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Models
{
    public class Especie
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clasificacion { get; set; }
        public string Designacion { get; set; }
        public string EsperanzaDeVida {  get; set; }
    }
}
