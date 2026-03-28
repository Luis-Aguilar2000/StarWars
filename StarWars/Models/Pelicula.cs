using System.Collections.Generic;

namespace StarWars.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int Episode_id { get; set; }
        public string Avance { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Productor { get; set; } = string.Empty;
        public string FechaDeLanzamiento { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public List<Persona> Personas { get; set; } = new List<Persona>();
    }
}