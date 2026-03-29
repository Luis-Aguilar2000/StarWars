using System.Collections.Generic;

namespace StarWars.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Altura { get; set; } = string.Empty;
        public string Masa { get; set; } = string.Empty;
        public string ColorDePiel { get; set; } = string.Empty;
        public string ColorDeOjos { get; set; } = string.Empty;
        public string ColorDePelo { get; set; } = string.Empty;
        public string Cumpleaños { get; set; } = string.Empty;
        public string Idioma { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string? Picture { get; set; }

        public int? PlanetaId { get; set; }
        public Planeta? Planeta { get; set; }

        public List<Especie> Especie { get; set; } = new List<Especie>();
        public List<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
        //public List<Transporte> Transportes { get; set; } = new List<Transporte>();
    }
}