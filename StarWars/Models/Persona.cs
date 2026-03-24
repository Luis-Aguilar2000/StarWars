using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Altura { get; set; }
        public string Masa { get; set; }
        public string ColorDePiel { get; set; }
        public string ColorDeOjos { get; set; }
        public string ColorDePelo { get; set; }
        public string Cumpleaños { get; set; }
        public string Genero { get; set; }

        public int IdPlaneta { get; set; }
        public Planeta Planeta { get; set; }

        public int IdEspecie { get; set; }
        public Especie Especie { get; set; }

        // sin tablas intermedias
        public List<Pelicula> Peliculas { get; set; }
        public  List<Transporte> Transportes { get; set; }


    }
}
