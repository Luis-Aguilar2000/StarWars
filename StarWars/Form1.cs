using Microsoft.EntityFrameworkCore;
using PersistenceLibrary.Interfaces;
using RestLibrary.Interfaces;
using StarWars.Data;
using StarWars.Dtos;
using StarWars.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StarWars
{
    public partial class Form1 : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly IRestApi _restApi;
        private readonly IRepository _repository;

        public Form1(ApplicationDbContext context, IRestApi restApi, IRepository repository)
        {
            _context = context;
            _restApi = restApi;
            _repository = repository;
            InitializeComponent();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            colorpanel();

            dtgpersona.SelectionChanged += dtgpersona_SelectionChanged;

            await CargarGuardarYMostrarAsync();
            dtgpersona.ClearSelection();
            Picture1.Image = null;
        }
        private void colorpanel()
        {
            panel1.BackColor = Color.FromArgb(60, 100, 100, 100);
            panel2.BackColor = Color.FromArgb(30, 100, 100, 100);
            paneldata.BackColor = Color.FromArgb(28, 100, 100, 100);
        }

        private async void btnpersona_Click(object sender, EventArgs e)
        {
        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            paneldata.Controls.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private async void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private async void btnPeliculas_Click(object sender, EventArgs e)
        {

        }
        private void dtgpersona_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgpersona.CurrentRow == null) return;

                var fila = dtgpersona.CurrentRow;

                // TEXTBOX
                textBox1.Text = fila.Cells["Nombre"]?.Value?.ToString() ?? "";
                textBox2.Text = fila.Cells["Altura"]?.Value?.ToString() ?? "";
                textBox3.Text = fila.Cells["Masa"]?.Value?.ToString() ?? "";
                textBox4.Text = fila.Cells["ColorDePiel"]?.Value?.ToString() ?? "";
                textBox5.Text = fila.Cells["ColorDeOjos"]?.Value?.ToString() ?? "";
                textBox6.Text = fila.Cells["ColorDePelo"]?.Value?.ToString() ?? "";


                string ruta = fila.Cells["Picture"]?.Value?.ToString() ?? "";
                string rutaCompleta = Path.Combine(Application.StartupPath, ruta);

                if (File.Exists(rutaCompleta))
                {
                    // liberar imagen anterior
                    if (Picture1.Image != null)
                    {
                        Picture1.Image.Dispose();
                        Picture1.Image = null;
                    }

                    // cargar imagen correctamente
                    using (FileStream fs = new FileStream(rutaCompleta, FileMode.Open, FileAccess.Read))
                    {
                        Picture1.Image = Image.FromStream(fs);
                    }
                }
                else
                {
                    Picture1.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar imagen: " + ex.Message);
            }
        }
        private async Task CargarGuardarYMostrarAsync()
        {
            // 1. TRAER DE API
            var result = await _restApi.Get<PeopleResponse<PersonajeJsonModel>>(
                "https://swapi.dev/api/",
                "people/"
            );

            // 2. GUARDAR EN BD
            foreach (var item in result.Results)
            {
                bool existe = await _context.Personas
                    .AnyAsync(p => p.Nombre == item.Name);

                if (!existe)
                {
                    var persona = new Persona
                    {
                        Nombre = item.Name,
                        Altura = item.Height,
                        Masa = item.Mass,
                        ColorDePiel = item.SkinColor,
                        ColorDeOjos = item.EyeColor,
                        ColorDePelo = item.HairColor,
                        Cumpleaños = item.BirthYear,
                        Genero = item.Gender
                    };

                    _context.Personas.Add(persona);
                }
            }

            await _context.SaveChangesAsync();

            // 3. MOSTRAR DESDE LA BASE
            var lista = await _context.Personas.ToListAsync();

            dtgpersona.DataSource = null;
            dtgpersona.DataSource = lista;

            // 4. OCULTAR COLUMNAS
            if (dtgpersona.Columns["Id"] != null)
                dtgpersona.Columns["Id"].Visible = false;

            if (dtgpersona.Columns["Picture"] != null)
                dtgpersona.Columns["Picture"].Visible = false;
        }
    }
}