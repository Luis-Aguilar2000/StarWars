using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Episode_id { get; set; }
        public string Avance {  get; set; }
        public string Director { get; set; }
        public string Productor { get; set; }
        public string FechaDeLanzamiento {  get; set; }
    }
}
