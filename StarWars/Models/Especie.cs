namespace StarWars.Models
{
    public class Especie
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Clasificacion { get; set; }

        public string Designacion { get; set; }

        public string AlturaPromedio { get; set; }

        public string ColoresDePelo { get; set; }

        public string ColoresDePiel { get; set; }

        public string ColoresDeOjos { get; set; }

        public string EsperanzaDeVida { get; set; } = string.Empty;
        public string Idioma { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public string Picture { get; set; } = string.Empty;

        public List<Persona> Personas { get; set; } = new List<Persona>();
    }
}