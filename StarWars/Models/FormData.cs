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
    public string Text10 { get; set; } = "";
    public string Text11 { get; set; } = "";
    public string Text12 { get; set; } = "";

    public string Combo1 { get; set; } = "";
    public int? Combo2Value { get; set; }
    public int? Combo3Value { get; set; }
    public int? Combo4Value { get; set; }

    public string richTextBox { get; set; } = "";
    public string Picture { get; set; } = "";

    public List<int> PeliculasSeleccionadas { get; set; } = new();
    public List<int> TransportesSeleccionados { get; set; } = new();
}