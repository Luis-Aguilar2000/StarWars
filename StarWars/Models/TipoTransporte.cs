using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Models
{
    public class TipoTransporte
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Transporte> Transportes { get; set; } = new List<Transporte>();
    }
}
