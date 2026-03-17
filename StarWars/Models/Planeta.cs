using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Models
{
    public class Planeta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PeriodoDeRotación { get; set; }
        public string PeriodoOrbital { get; set; }
        public string Diametro { get; set; }
        public string Clima { get; set; }
        public string Gravedad {  get; set; }
        public string Terreno { get; set; }
        public string AguaSuperficial { get; set; }
        public string Poblacion {  get; set; }
    }
}
