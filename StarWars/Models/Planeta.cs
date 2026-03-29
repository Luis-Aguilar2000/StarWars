using System.Collections.Generic;

namespace StarWars.Models
{
    public class Planeta
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string PeriodoDeRotación { get; set; } = string.Empty;
        public string PeriodoOrbital { get; set; } = string.Empty;
        public string Diametro { get; set; } = string.Empty;
        public string Clima { get; set; } = string.Empty;
        public string Gravedad { get; set; } = string.Empty;
        public string Terreno { get; set; } = string.Empty;
        public string AguaSuperficial { get; set; } = string.Empty;
        public string Poblacion { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string? Picture { get; set; }=string.Empty;

        public List<Persona> Personas { get; set; } = new List<Persona>();
    }
}