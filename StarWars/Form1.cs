using Microsoft.EntityFrameworkCore;
using PersistenceLibrary.Interfaces;
using RestLibrary.Interfaces;
using StarWars.Data;
using StarWars.Dtos;
using StarWars.Models;
using StarWars.Services;

namespace StarWars
{
    public partial class Form1 : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly IRestApi _restApi;
        private readonly IRepository _repository;
        private readonly IPersonaService _personaService;
        private readonly IPeliculaService _peliculaService;
        private readonly IPlanetaService _planetaService;

        private bool cargando = true;
        private string vistaActual = "Personas";

        public Form1(ApplicationDbContext context, IRestApi restApi, IRepository repository, IPersonaService personaService, IPeliculaService peliculaService, IPlanetaService planetaService)
        {
            _planetaService = planetaService;
            _peliculaService = peliculaService;
            _personaService = personaService;
            _context = context;
            _restApi = restApi;
            _repository = repository;
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            colorpanel();

            dtgpersona.SelectionChanged += dtgpersona_SelectionChanged;

            await CargarMostrarPersonasAsync();

            dtgpersona.ClearSelection();
            dtgpersona.CurrentCell = null;
            LimpiarControles();

            cargando = false;
        }

        //Botonera General
        private async void btnpersona_Click(object sender, EventArgs e)
        {
            clickPersonas();
            await CargarMostrarPersonasAsync();

        }

        private async void btnPeliculas_Click(object sender, EventArgs e)
        {
            clickPeliculas();
            await CargarMostrarPeliculasAsync();
         
        }

        private async void btplanetas_Click(object sender, EventArgs e)
        {
            clickPlanetas();
            await CargarMostrarPlanetasAsync();
           

        }

        //SelectionChanged del DataGridView para mostrar detalles de las tablas
        private void dtgpersona_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            if (dtgpersona.CurrentRow == null) return;
            if (dtgpersona.CurrentCell == null) return;

            var fila = dtgpersona.CurrentRow;

            switch (vistaActual)
            {
                case "Personas":
                    textBox1.Text = fila.Cells["Nombre"]?.Value?.ToString() ?? "";
                    textBox2.Text = fila.Cells["Altura"]?.Value?.ToString() ?? "";
                    textBox3.Text = fila.Cells["Masa"]?.Value?.ToString() ?? "";
                    textBox4.Text = fila.Cells["ColorDePiel"]?.Value?.ToString() ?? "";
                    textBox5.Text = fila.Cells["ColorDeOjos"]?.Value?.ToString() ?? "";
                    textBox6.Text = fila.Cells["ColorDePelo"]?.Value?.ToString() ?? "";
                    CargarImagen(fila);

                    break;

                case "Peliculas":
                    textBox1.Text = fila.Cells["Titulo"]?.Value?.ToString() ?? "";
                    textBox2.Text = fila.Cells["Episode_id"]?.Value?.ToString() ?? "";
                    textBox3.Text = fila.Cells["Avance"]?.Value?.ToString() ?? "";
                    textBox4.Text = fila.Cells["Director"]?.Value?.ToString() ?? "";
                    textBox5.Text = fila.Cells["Productor"]?.Value?.ToString() ?? "";
                    textBox6.Text = fila.Cells["FechaDeLanzamiento"]?.Value?.ToString() ?? "";
                    CargarImagen(fila);
                    break;

                case "Planetas":
                    textBox1.Text = fila.Cells["Nombre"]?.Value?.ToString() ?? "";
                    textBox2.Text = fila.Cells["PeriodoDeRotación"]?.Value?.ToString() ?? "";
                    textBox3.Text = fila.Cells["PeriodoOrbital"]?.Value?.ToString() ?? "";
                    textBox4.Text = fila.Cells["Diametro"]?.Value?.ToString() ?? "";
                    textBox5.Text = fila.Cells["Clima"]?.Value?.ToString() ?? "";
                    textBox6.Text = fila.Cells["Gravedad"]?.Value?.ToString() ?? "";
                    CargarImagen(fila);
                    break;
            }
        }

        // Métodos para cargar, guardar y mostrar datos de las tablas
        //PERSONAS
        private async Task CargarMostrarPersonasAsync()
        {
            try
            {
                cargando = true;
                vistaActual = "Personas";

                var lista = await _personaService.ObtenerPersonasAsync();

                var datos = lista
                    .SelectMany(p => p.Peliculas.DefaultIfEmpty(), (p, peli) => new
                    {
                        p.Id,
                        p.Nombre,
                        p.Altura,
                        p.Masa,
                        p.ColorDePiel,
                        p.ColorDeOjos,
                        p.ColorDePelo,
                        p.Cumpleaños,
                        p.Genero,
                        p.Picture,
                        Pelicula = peli != null ? peli.Titulo : "",
                        Planeta = p.Planeta != null ? p.Planeta.Nombre : ""
                    })
                    .ToList();

                ConfigurarGrid(datos, "Id", "Picture", "Url");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar personas: " + ex.Message);
            }
            finally
            {
                dtgpersona.ClearSelection();
                dtgpersona.CurrentCell = null;
                LimpiarControles();
                cargando = false;
            }
        }

        //PELÍCULAS
        private async Task CargarMostrarPeliculasAsync()
        {
            try
            {
                cargando = true;
                vistaActual = "Peliculas";

                var lista = await _peliculaService.ObtenerPeliculasAsync();

                var datos = lista.Select(p => new
                {
                    p.Id,
                    p.Titulo,
                    p.Episode_id,
                    p.Avance,
                    p.Director,
                    p.Productor,
                    p.FechaDeLanzamiento,
                    p.Picture,
                    p.Url
                }).ToList();

                ConfigurarGrid(datos, "Id", "Picture", "Url");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar películas: " + ex.Message);
            }
            finally
            {
                dtgpersona.ClearSelection();
                dtgpersona.CurrentCell = null;
                LimpiarControles();
                cargando = false;
            }
        }

        //PLANETAS
        private async Task CargarMostrarPlanetasAsync()
        {
            try
            {
                cargando = true;
                vistaActual = "Planetas";

                var lista = await _planetaService.ObtenerPlanetasAsync();

                var datos = lista.Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    p.PeriodoDeRotación,
                    p.PeriodoOrbital,
                    p.Diametro,
                    p.Clima,
                    p.Gravedad,
                    p.Terreno,
                    p.AguaSuperficial,
                    p.Poblacion,
                    p.Picture,
                    p.Url
                }).ToList();

                ConfigurarGrid(datos, "Id", "Picture", "Url");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar planetas: " + ex.Message);
            }
            finally
            {
                dtgpersona.ClearSelection();
                dtgpersona.CurrentCell = null;
                LimpiarControles();
                cargando = false;
            }
        }

        //OTROS METODOS

        //Cambio de campo de texto al hacer click en un boton
        //PERSONAS
        private void clickPersonas()
        {
            vistaActual = "Personas";

            this.SuspendLayout();

            lblname.Text = "PERSONAS";
            label1.Text = "Nombre:";
            label2.Text = "Altura:";
            label3.Text = "Masa:";
            label4.Text = "Color de Piel:";
            label5.Text = "Color de Ojos:";
            label6.Text = "Color de Pelo:";
            dateTimePicker1.Visible = true;
            label7.Text = "Cumpleaños:";
            comboBox1.Visible = true;
            label8.Text = "Genero:";
            comboBox2.Visible = true;
            label9.Text = "Idioma:";
            comboBox3.Visible = true;
            label10.Text = "Especie:";
            comboBox4.Visible = true;
            label11.Text = "Planeta:";
            comboBox5.Visible = true;
            label12.Text = "Pelicula:";
            comboBox6.Visible = true;
            label13.Text = "Vehiculo:";

            this.ResumeLayout();
        }
        //PELICULAS
        private void clickPeliculas()
        {
            vistaActual = "Peliculas";

            this.SuspendLayout();

            lblname.Text = "PELICULAS";
            label1.Text = "Titulo:";
            label2.Text = "Episodio:";
            label3.Text = "Avance:";
            label4.Text = "Director:";
            label5.Text = "Productor:";
            label6.Text = "Fecha de Lanzamiento:";

            dateTimePicker1.Visible = false;

            label7.Text = "";
            comboBox1.Visible = false;

            label8.Text = "";
            comboBox2.Visible = false;

            label9.Text = "";
            comboBox3.Visible = false;

            label10.Text = "";
            comboBox4.Visible = false;

            label11.Text = "";
            comboBox5.Visible = false;

            label12.Text = "";
            comboBox6.Visible = false;

            label13.Text = "";

            this.ResumeLayout();
        }

        //PLANETAS
        private void clickPlanetas()
        {

            vistaActual = "Peliculas";

            this.SuspendLayout();

            lblname.Text = "PLANETAS";
            label1.Text = "Nombre:";
            label2.Text = "Periodo de Rotacion:";
            label3.Text = "Periodo Orbital:";
            label4.Text = "Diametro:";
            label5.Text = "Clima:";
            label6.Text = "Gravedad:";

            dateTimePicker1.Visible = false;

            label7.Text = "Terreno:";
            comboBox1.Visible = false;

            label8.Text = "Agua Superficial:";
            comboBox2.Visible = false;

            label9.Text = "Poblacion:";
            comboBox3.Visible = false;

            label10.Text = "";
            comboBox4.Visible = false;

            label11.Text = "";
            comboBox5.Visible = false;

            label12.Text = "";
            comboBox6.Visible = false;

            label13.Text = "";

            this.ResumeLayout();
        }

        // Método para limpiar los controles de detalle
        private void LimpiarControles()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            if (Picture1.Image != null)
            {
                Picture1.Image.Dispose();
                Picture1.Image = null;
            }
        }

        // Método para establecer colores con transparencia en los paneles
        private void colorpanel()
        {
            panel1.BackColor = Color.FromArgb(60, 100, 100, 100);
            panel2.BackColor = Color.FromArgb(30, 100, 100, 100);
            paneldata.BackColor = Color.FromArgb(28, 100, 100, 100);
        }

        //Cargar imagen seleccionada 
        private void CargarImagen(DataGridViewRow fila)
        {
            string ruta = fila.Cells["Picture"]?.Value?.ToString() ?? "";
            string rutaCompleta = Path.Combine(Application.StartupPath, ruta);

            if (Picture1.Image != null)
            {
                Picture1.Image.Dispose();
                Picture1.Image = null;
            }

            if (!string.IsNullOrWhiteSpace(ruta) && File.Exists(rutaCompleta))
            {
                using (FileStream fs = new FileStream(rutaCompleta, FileMode.Open, FileAccess.Read))
                {
                    Picture1.Image = new Bitmap(Image.FromStream(fs));
                }
            }
        }

        // Método para configurar el DataGridView de forma genérica
        private void ConfigurarGrid(object datos, params string[] columnasOcultas)
        {
            dtgpersona.DataSource = null;
            dtgpersona.DataSource = datos;

            dtgpersona.MultiSelect = false;
            dtgpersona.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgpersona.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            foreach (string columna in columnasOcultas)
            {
                if (dtgpersona.Columns[columna] != null)
                    dtgpersona.Columns[columna].Visible = false;
            }
        }
    }
}