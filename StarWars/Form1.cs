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
        private readonly IEspecieService _especieService;
        private readonly ITransporteService _transporteService;

        private bool cargando = true;
        private string vistaActual = "Personas";

        public Form1(ApplicationDbContext context,
            IRestApi restApi,
            IRepository repository,
            IPersonaService personaService,
            IPeliculaService peliculaService,
            IPlanetaService planetaService,
            IEspecieService specieService,
            ITransporteService transporteService)
        {
            _planetaService = planetaService;
            _peliculaService = peliculaService;
            _personaService = personaService;
            _especieService = specieService;
            _transporteService = transporteService;
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
            await _transporteService.InicializarTiposAsync();

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
        private async void btespecies_Click(object sender, EventArgs e)
        {
            await CargarMostrarEspeciesAsync();
        }

        private async void btvehiculos_Click(object sender, EventArgs e)
        {
            await CargarMostrarTransportesAsync();
        }
                private void btneditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }

        //Botonera de CRUD para cada tabla

        //BOTON NUEVO PARA CADA TABLA
        private async void btnnuevo_Click(object sender, EventArgs e)
        {

            Persona persona = new Persona
            {
                Nombre = textBox1.Text,
                Altura = textBox2.Text,
                Masa = textBox3.Text,
                ColorDePiel = textBox4.Text,
                ColorDeOjos = textBox5.Text,
                ColorDePelo = textBox6.Text,
                Cumpleaños = textBox7.Text,
                Genero = comboBox1.Text
            };

            await _personaService.CrearPersonaAsync(persona);

            await CargarMostrarPersonasAsync();
            LimpiarControles();
        }

        //BOTON ELIMINAR PARA CADA TABLA
        private async void btneliminar_Click(object sender, EventArgs e)
        {
            if (dtgpersona.CurrentRow == null) return;

            int id = Convert.ToInt32(dtgpersona.CurrentRow.Cells["Id"].Value);

            switch (vistaActual)
            {
                case "Personas":
                    await _personaService.EliminarPersonaAsync(id);
                    await CargarMostrarPersonasAsync();
                    break;

                case "Peliculas":
                    await _peliculaService.EliminarPeliculaAsync(id);
                    await CargarMostrarPeliculasAsync();
                    break;

                case "Planetas":
                    await _planetaService.EliminarPlanetaAsync(id);
                    await CargarMostrarPlanetasAsync();
                    break;

                case "Especies":
                    await _especieService.EliminarEspecieAsync(id);
                    await CargarMostrarEspeciesAsync();
                    break;

                    //case "Transportes":
                    //    await _transporteService.EliminarTransporteAsync(id);
                    //    await CargarMostrarTransportesAsync();
                    //    break;
            }

            LimpiarControles();
        }

        //BOTON GUARDAR PARA CADA TABLA
        private async Task btguardar_ClickAsync(object sender, EventArgs e)
        {
            if (dtgpersona.CurrentRow == null) return;

            int id = Convert.ToInt32(dtgpersona.CurrentRow.Cells["Id"].Value);

            switch (vistaActual)
            {
                case "Personas":
                    Persona persona = new Persona
                    {
                        Id = id,
                        Nombre = textBox1.Text,
                        Altura = textBox2.Text,
                        Masa = textBox3.Text,
                        ColorDePiel = textBox4.Text,
                        ColorDeOjos = textBox5.Text,
                        ColorDePelo = textBox6.Text,
                        Cumpleaños = textBox7.Text,
                        Genero = comboBox1.Text
                    };

                    await _personaService.ActualizarPersonaAsync(persona);
                    await CargarMostrarPersonasAsync();
                    break;

                case "Peliculas":
                    Pelicula pelicula = new Pelicula
                    {
                        Id = id,
                        Titulo = textBox1.Text,
                        Episode_id = Convert.ToInt32(textBox2.Text),
                        Avance = textBox3.Text,
                        Director = textBox4.Text,
                        Productor = textBox5.Text,
                        FechaDeLanzamiento = textBox6.Text
                    };

                    await _peliculaService.ActualizarPeliculaAsync(pelicula);
                    await CargarMostrarPeliculasAsync();
                    break;

                case "Planetas":
                    Planeta planeta = new Planeta
                    {
                        Id = id,
                        Nombre = textBox1.Text,
                        PeriodoDeRotación = textBox2.Text,
                        PeriodoOrbital = textBox3.Text,
                        Diametro = textBox4.Text,
                        Clima = textBox5.Text,
                        Gravedad = textBox6.Text,
                        Terreno = textBox7.Text
                    };

                    await _planetaService.ActualizarPlanetaAsync(planeta);
                    await CargarMostrarPlanetasAsync();
                    break;

                case "Especies":
                    Especie especie = new Especie
                    {
                        Id = id,
                        Nombre = textBox1.Text,
                        Clasificacion = textBox2.Text,
                        Idioma = textBox3.Text
                    };

                    await _especieService.ActualizarEspecieAsync(especie);
                    await CargarMostrarEspeciesAsync();
                    break;

                    //case "Transportes":
                    //    // cuando lo tengas listo
                    //    break;
            }

            LimpiarControles();
        }


        //SelectionChanged del DataGridView para mostrar detalles de las tablas
        private async void dtgpersona_SelectionChanged(object sender, EventArgs e)
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
                    textBox7.Text = fila.Cells["Cumpleaños"]?.Value?.ToString() ?? "";

                    comboBox1.Text = fila.Cells["Genero"]?.Value?.ToString() ?? "";
                    comboBox2.Text = fila.Cells["Especie"]?.Value?.ToString() ?? "";
                    comboBox3.Text = fila.Cells["Planeta"]?.Value?.ToString() ?? "";

                    await MarcarPeliculasSeleccionadasAsync(fila);
                    await MarcarVehiculosSeleccionadosAsync(fila);

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

                case "Especies":
                    textBox1.Text = fila.Cells["Nombre"]?.Value?.ToString() ?? "";
                    textBox2.Text = fila.Cells["Clasificacion"]?.Value?.ToString() ?? "";
                    textBox3.Text = fila.Cells["Designacion"]?.Value?.ToString() ?? "";
                    textBox4.Text = fila.Cells["PromedioDeAltura"]?.Value?.ToString() ?? "";
                    textBox5.Text = fila.Cells["ColorDePiel"]?.Value?.ToString() ?? "";
                    textBox6.Text = fila.Cells["ColorDeOjos"]?.Value?.ToString() ?? "";
                    CargarImagen(fila);
                    break;

                case "Transportes":
                    textBox1.Text = fila.Cells["Nombre"]?.Value?.ToString() ?? "";
                    textBox2.Text = fila.Cells["Modelo"]?.Value?.ToString() ?? "";
                    textBox3.Text = fila.Cells["Fabricante"]?.Value?.ToString() ?? "";
                    textBox4.Text = fila.Cells["Costo"]?.Value?.ToString() ?? "";
                    textBox5.Text = fila.Cells["Longitud"]?.Value?.ToString() ?? "";
                    textBox6.Text = fila.Cells["Velocidad"]?.Value?.ToString() ?? "";
                    textBox7.Text = fila.Cells["Tripulacion"]?.Value?.ToString() ?? "";
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

                var datos = lista.Select(p => new
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

                    Pelicula = string.Join(", ", p.Peliculas.Select(x => x.Titulo)),
                    Planeta = p.Planeta != null ? p.Planeta.Nombre : "",
                    Especie = string.Join(", ", p.Especie.Select(x => x.Nombre)),
                    Vehiculo = string.Join(", ", p.Transportes.Select(x => x.Nombre)),
                }).ToList();

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

        private async Task CargarMostrarEspeciesAsync()
        {
            try
            {
                cargando = true;
                vistaActual = "Especies";

                var lista = await _especieService.ObtenerEspeciesAsync();

                var datos = lista.Select(e => new
                {
                    e.Id,
                    e.Nombre,
                    e.Clasificacion,
                    e.Designacion,
                    e.AlturaPromedio,
                    e.ColoresDePiel,
                    e.ColoresDePelo,
                    e.ColoresDeOjos,
                    e.EsperanzaDeVida,
                    e.Idioma,
                    e.Picture,
                    e.Url
                }).ToList();

                ConfigurarGrid(datos, "Id", "Picture", "Url");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar especies: " + ex.Message);
            }
            finally
            {
                dtgpersona.ClearSelection();
                dtgpersona.CurrentCell = null;
                LimpiarControles();
                cargando = false;
            }
        }

        private async Task CargarMostrarTransportesAsync()
        {
            try
            {
                cargando = true;
                vistaActual = "Transportes";

                var lista = await _transporteService.ObtenerTransportesAsync();

                var datos = lista.Select(t => new
                {
                    t.Id,
                    t.Nombre,
                    t.Modelo,
                    t.Fabricante,
                    t.CostoEnCreditos,
                    t.Longitud,
                    t.VelocidadMaximaAtmosfera,
                    t.Tripulacion,
                    t.Pasajeros,
                    t.CapacidadCarga,
                    t.Consumibles,
                    t.MGLT,
                    t.Clase,
                    Tipo = t.TipoTransporte != null ? t.TipoTransporte.Nombre : "",
                    t.Picture,
                    t.Url
                }).ToList();

                ConfigurarGrid(datos, "Id", "Picture", "Url");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar transportes: " + ex.Message);
            }
            finally
            {
                cargando = false;
                dtgpersona.ClearSelection();
                Picture1.Image = null;
            }
        }

        //OTROS METODOS

        //Cambio de campo de texto al hacer click en un boton
        //PERSONAS
        private async Task clickPersonas()
        {
            this.SuspendLayout();

            lblname.Text = "PERSONAS";
            label1.Text = "Nombre:";
            label2.Text = "Altura:";
            label3.Text = "Masa:";
            label4.Text = "Color de Piel:";
            label5.Text = "Color de Ojos:";
            label6.Text = "Color de Pelo:";
            label7.Text = "Cumpleaños:";

            comboBox1.Visible = true;
            label8.Text = "Genero:";

            comboBox2.Visible = true;
            label9.Text = "Especie:";

            comboBox3.Visible = true;
            label10.Text = "Planeta:";

            checkedListBox1.Visible = true;
            label11.Text = "Películas:";

            checkedListBox2.Visible = true;
            label12.Text = "Vehículos:";

            await CargarCombosPersonasAsync();

            this.ResumeLayout();
        }
        //PELICULAS
        private void clickPeliculas()
        {
            this.SuspendLayout();

            lblname.Text = "PELICULAS";
            label1.Text = "Titulo:";
            label2.Text = "Episodio:";
            label3.Text = "Avance:";
            label4.Text = "Director:";
            label5.Text = "Productor:";
            label6.Text = "Fecha de Lanzamiento:";

            textBox7.Visible = false;

            label7.Text = "";
            comboBox1.Visible = false;

            label8.Text = "";
            comboBox2.Visible = false;

            label9.Text = "";
            comboBox3.Visible = false;

            label10.Text = "";
            comboBox2.Visible = false;

            label11.Text = "";
            //comboBox5.Visible = false;

            label12.Text = "";

            this.ResumeLayout();
        }

        //PLANETAS
        private void clickPlanetas()
        {
            this.SuspendLayout();

            lblname.Text = "PLANETAS";
            label1.Text = "Nombre:";
            label2.Text = "Periodo de Rotacion:";
            label3.Text = "Periodo Orbital:";
            label4.Text = "Diametro:";
            label5.Text = "Clima:";
            label6.Text = "Gravedad:";

            textBox7.Visible = false;

            label7.Text = "Terreno:";
            comboBox1.Visible = false;

            label8.Text = "Agua Superficial:";
            comboBox2.Visible = false;

            label9.Text = "Poblacion:";
            comboBox3.Visible = false;

            label10.Text = "";
            comboBox2.Visible = false;

            label11.Text = "";
            //comboBox5.Visible = false;

            label12.Text = "";

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
        private void HabilitarControles()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;

            checkedListBox1.Enabled = true;
            checkedListBox2.Enabled = true;

            btnimagen.Enabled = true;
            btnnuevo.Enabled = false;
            btneliminar.Enabled = false;
            btneditar.Enabled = false;
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


        //Combox de Personas

        private void CargarGeneros()
        {
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();

            comboBox1.Items.Add("male");
            comboBox1.Items.Add("female");
            comboBox1.Items.Add("n/a");
            comboBox1.Items.Add("unknown");
        }
        private async Task CargarEspeciesAsync()
        {
            var especies = await _especieService.ObtenerEspeciesAsync();

            comboBox2.DataSource = null;

            comboBox2.DataSource = especies;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "Id";
        }
        private async Task CargarPlanetasAsync()
        {
            var planetas = await _planetaService.ObtenerPlanetasAsync();

            comboBox3.DataSource = null;

            comboBox3.DataSource = planetas;
            comboBox3.DisplayMember = "Nombre";
            comboBox3.ValueMember = "Id";
        }
        private async Task CargarPeliculasAsync()
        {
            var peliculas = await _peliculaService.ObtenerPeliculasAsync();

            checkedListBox1.DataSource = null;
            checkedListBox1.Items.Clear();

            foreach (var pelicula in peliculas)
            {
                checkedListBox1.Items.Add(pelicula);
            }

            checkedListBox1.DisplayMember = "Titulo";
            checkedListBox1.ValueMember = "Id";
        }

        private async Task CargarVehiculosAsync()
        {
            var vehiculos = await _transporteService.ObtenerTransportesAsync();

            checkedListBox2.DataSource = null;
            checkedListBox2.Items.Clear();

            foreach (var vehiculo in vehiculos)
            {
                checkedListBox2.Items.Add(vehiculo);
            }

            checkedListBox2.DisplayMember = "Nombre";
            checkedListBox2.ValueMember = "Id";
        }

        private async Task CargarCombosPersonasAsync()
        {
            CargarGeneros();
            await CargarEspeciesAsync();
            await CargarPlanetasAsync();
            await CargarPeliculasAsync();
            await CargarVehiculosAsync();
        }


        // Método para marcar las películas seleccionadas en el CheckedListBox al seleccionar una persona
        private async Task MarcarPeliculasSeleccionadasAsync(DataGridViewRow fila)
        {
            if (checkedListBox1.Items.Count == 0)
                await CargarPeliculasAsync();

            string peliculasTexto = fila.Cells["Pelicula"]?.Value?.ToString() ?? "";

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);

            if (!string.IsNullOrWhiteSpace(peliculasTexto))
            {
                var peliculasSeleccionadas = peliculasTexto
                    .Split(',')
                    .Select(x => x.Trim())
                    .ToList();

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.Items[i] is Pelicula pelicula &&
                        peliculasSeleccionadas.Contains(pelicula.Titulo))
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }
        }

        // Método para marcar los vehículos seleccionados en el CheckedListBox al seleccionar una persona
        private async Task MarcarVehiculosSeleccionadosAsync(DataGridViewRow fila)
        {
            if (checkedListBox2.Items.Count == 0)
                await CargarVehiculosAsync();

            string vehiculosTexto = fila.Cells["Vehiculo"]?.Value?.ToString() ?? "";

            for (int i = 0; i < checkedListBox2.Items.Count; i++)
                checkedListBox2.SetItemChecked(i, false);

            if (!string.IsNullOrWhiteSpace(vehiculosTexto))
            {
                var vehiculosSeleccionados = vehiculosTexto
                    .Split(',')
                    .Select(x => x.Trim())
                    .ToList();

                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    if (checkedListBox2.Items[i] is Transporte vehiculo &&
                        vehiculosSeleccionados.Contains(vehiculo.Nombre))
                    {
                        checkedListBox2.SetItemChecked(i, true);
                    }
                }
            }
        }


    }
}