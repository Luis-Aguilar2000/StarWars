namespace StarWars.Models
{
    public class FormData
    {
        public int Id { get; set; }

        public string Text1 { get; set; } = "";
        public string Text2 { get; set; } = "";
        public string Text3 { get; set; } = "";
        public string Text4 { get; set; } = "";
        public string Text5 { get; set; } = "";
        public string Text6 { get; set; } = "";
        public string Text7 { get; set; } = "";
        public string Text8 { get; set; } = "";
        public string Text9 { get; set; } = "";

        public string Combo1 { get; set; } = "";

        public int? Combo2Value { get; set; } 
        public int? Combo3Value { get; set; }  
        public string richTextBox { get; set; } =""; 

        public List<int> PeliculasSeleccionadas { get; set; } = new List<int>();
        public List<int> TransportesSeleccionados { get; set; } = new List<int>();
    }
}