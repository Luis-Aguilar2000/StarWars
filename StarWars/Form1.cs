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
        private int ultimoId = -1;
        private string vistaActual = "Personas";
        private bool cancelado = false;
        private bool combosCargados = false;
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

            await _personaService.SincronizarPersonas();
            await _peliculaService.SincronizarPeliculas();
            await _planetaService.SincronizarPlanetas();
            await _especieService.SincronizarEspecies();
            await _transporteService.SincronizarTransportes();
            await ObtenerPersonasBD();

            dtgpersona.ClearSelection();
            dtgpersona.CurrentCell = null;
            LimpiarControles();

            cargando = false;
        }

        //Botonera NA
        private async void btnpersona_Click(object sender, EventArgs e)
        {

            await ObtenerPersonasBD();
            await clickPersonas();
        }

        private async void btnPeliculas_Click(object sender, EventArgs e)
        {
            await ObtenerPeliculasBD();
            clickPeliculas();

        }

        private async void btplanetas_Click(object sender, EventArgs e)
        {
            clickPlanetas();
            await ObtenerPlanetasBD();


        }
        private async void btespecies_Click(object sender, EventArgs e)
        {
            await ObtenerEspeciesBD();
        }

        private async void btvehiculos_Click(object sender, EventArgs e)
        {
            await ObtenerTransportesBD();
        }

        //botonera del crud
        //editar
        private async void btneditar_Click(object sender, EventArgs e)
        {
            if (dtgpersona.CurrentRow == null || dtgpersona.CurrentRow.Index < 0)
            {
                MessageBox.Show("Seleccione un personaje.");
                return;
            }

            if (vistaActual == "Personas")
            {
                var fila = dtgpersona.CurrentRow;

                await CargarCombosPersonasAsync();

                comboBox1.Text = fila.Cells["Genero"]?.Value?.ToString() ?? "";
                comboBox2.Text = fila.Cells["Especie"]?.Value?.ToString() ?? "";
                comboBox3.Text = fila.Cells["Planeta"]?.Value?.ToString() ?? "";

                await MarcarPeliculasSeleccionadasAsync(fila);
                await MarcarVehiculosSeleccionadosAsync(fila);
            }

            btncrear.Enabled = false;
            HabilitarControles();
            btnactualizar.Enabled = true;
            dtgpersona.Enabled = false;
        }
        //nuevo
        private async void btnnuevo_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            dtgpersona.Enabled = false;
            btncrear.Enabled = true;

            LimpiarControles();

            if (vistaActual == "Personas")
            {
                await CargarCombosPersonasAsync();
            }
        }
        //cancelar
        private void btncancelar_Click(object sender, EventArgs e)
        {
            cancelado = true;

            DeshabilitarControles();
            dtgpersona.Enabled = true;
            btncrear.Enabled = false;
            btnactualizar.Enabled = false;

            LimpiarControles();

            checkedListBox1.DataSource = null;
            checkedListBox1.Items.Clear();

            checkedListBox2.DataSource = null;
            checkedListBox2.Items.Clear();

            dtgpersona.ClearSelection();
            dtgpersona.CurrentCell = null;
            ultimoId = -1;

            cancelado = false;
        }

        //actualizar
        private async void btnactualizar_Click(object sender, EventArgs e)
        {
            if (dtgpersona.CurrentRow == null) return;

            int id = Convert.ToInt32(dtgpersona.CurrentRow.Cells["Id"].Value);

            switch (vistaActual)
            {
                case "Personas":
                    var peliculasSeleccionadas = new List<int>();
                    var transportesSeleccionados = new List<int>();

                    foreach (var item in checkedListBox1.CheckedItems)
                    {
                        if (item is Pelicula peliculaItem)
                            peliculasSeleccionadas.Add(peliculaItem.Id);
                    }

                    foreach (var item in checkedListBox2.CheckedItems)
                    {
                        if (item is Transporte transporteItem)
                            transportesSeleccionados.Add(transporteItem.Id);
                    }

                    int? planetaId = null;
                    if (comboBox3.SelectedValue != null)
                        planetaId = Convert.ToInt32(comboBox3.SelectedValue);

                    int? especieId = null;
                    if (comboBox2.SelectedValue != null)
                        especieId = Convert.ToInt32(comboBox2.SelectedValue);

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
                        Genero = comboBox1.Text,
                        PlanetaId = planetaId
                    };

                    await _personaService.ActualizarPersona(
                        persona,
                        especieId,
                        peliculasSeleccionadas,
                        transportesSeleccionados
                    );

                    await ObtenerPersonasBD();
                    break;
            }

            DeshabilitarControles();
            dtgpersona.Enabled = true;
            LimpiarControles();
        }
        //CREAR
        private async void btncrear_Click(object sender, EventArgs e)
        {
            try
            {
                bool creado = false;

                switch (vistaActual)
                {
                    case "Personas":
                        var peliculasSeleccionadas = new List<int>();
                        var transportesSeleccionados = new List<int>();

                        foreach (var item in checkedListBox1.CheckedItems)
                        {
                            if (item is Pelicula peliculaItem)
                                peliculasSeleccionadas.Add(peliculaItem.Id);
                        }

                        foreach (var item in checkedListBox2.CheckedItems)
                        {
                            if (item is Transporte transporteItem)
                                transportesSeleccionados.Add(transporteItem.Id);
                        }

                        int? planetaId = null;
                        if (comboBox3.SelectedValue != null)
                            planetaId = Convert.ToInt32(comboBox3.SelectedValue);

                        int? especieId = null;
                        if (comboBox2.SelectedValue != null)
                            especieId = Convert.ToInt32(comboBox2.SelectedValue);

                        Persona persona = new Persona
                        {
                            Nombre = textBox1.Text,
                            Altura = textBox2.Text,
                            Masa = textBox3.Text,
                            ColorDePiel = textBox4.Text,
                            ColorDeOjos = textBox5.Text,
                            ColorDePelo = textBox6.Text,
                            Cumpleaños = textBox7.Text,
                            Genero = comboBox1.Text,
                            PlanetaId = planetaId
                        };

                        await _personaService.CrearPersona(
                            persona,
                            especieId,
                            peliculasSeleccionadas,
                            transportesSeleccionados
                        );

                        await ObtenerPersonasBD();
                        creado = true;
                        break;

                    case "Peliculas":
                        Pelicula pelicula = new Pelicula
                        {
                            Titulo = textBox1.Text,
                            Episode_id = int.TryParse(textBox2.Text, out int episodio) ? episodio : 0,
                            Director = textBox3.Text,
                            Productor = textBox4.Text,
                            FechaDeLanzamiento = textBox5.Text,
                            Avance = textBox6.Text
                        };

                        await _peliculaService.CrearPelicula(pelicula);
                        await ObtenerPeliculasBD();
                        creado = true;
                        break;

                    case "Planetas":
                        Planeta planeta = new Planeta
                        {
                            Nombre = textBox1.Text,
                            PeriodoDeRotación = textBox2.Text,
                            PeriodoOrbital = textBox3.Text,
                            Diametro = textBox4.Text,
                            Clima = textBox5.Text,
                            Gravedad = textBox6.Text,
                            Terreno = textBox7.Text
                        };

                        await _planetaService.CrearPlaneta(planeta);
                        await ObtenerPlanetasBD();
                        creado = true;
                        break;

                    case "Especies":
                        Especie especie = new Especie
                        {
                            Nombre = textBox1.Text,
                            Clasificacion = textBox2.Text,
                            Designacion = textBox3.Text,
                            AlturaPromedio = textBox4.Text,
                            ColoresDePiel = textBox5.Text,
                            ColoresDeOjos = textBox6.Text,
                            Idioma = textBox7.Text
                        };

                        await _especieService.CrearEspecie(especie);
                        await ObtenerEspeciesBD();
                        creado = true;
                        break;

                    case "Transportes":
                        Transporte transporte = new Transporte
                        {
                            Nombre = textBox1.Text,
                            Modelo = textBox2.Text,
                            Fabricante = textBox3.Text,
                            CostoEnCreditos = textBox4.Text,
                            Longitud = textBox5.Text,
                            VelocidadMaximaAtmosfera = textBox6.Text,
                            Tripulacion = textBox7.Text
                        };

                        await _transporteService.CrearTransporte(transporte);
                        await ObtenerTransportesBD();
                        creado = true;
                        break;
                }

                if (creado)
                    MessageBox.Show("Registro creado correctamente ✅");
                else
                    MessageBox.Show("No se creó el registro ❌");

                LimpiarControles();
                DeshabilitarControles();
                dtgpersona.Enabled = true;
                btncrear.Enabled = false;
                btnactualizar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear: " + ex.Message);
            }
        }



        //ELIMINAR
        private async void btneliminar_Click(object sender, EventArgs e)
        {
            if (dtgpersona.CurrentRow == null || dtgpersona.CurrentRow.Index < 0)
            {
                MessageBox.Show("Seleccione un registro para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea eliminar este registro?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado != DialogResult.Yes)
                return;

            try
            {
                int id = Convert.ToInt32(dtgpersona.CurrentRow.Cells["Id"].Value);

                switch (vistaActual)
                {
                    case "Personas":
                        await _personaService.EliminarPersona(id);
                        await ObtenerPersonasBD();
                        break;

                    case "Peliculas":
                        await _peliculaService.EliminarPelicula(id);
                        await ObtenerPeliculasBD();
                        break;

                    case "Planetas":
                        await _planetaService.EliminarPlaneta(id);
                        await ObtenerPlanetasBD();
                        break;

                    case "Especies":
                        await _especieService.EliminarEspecie(id);
                        await ObtenerEspeciesBD();
                        break;

                        //case "Transportes":
                        //    await _transporteService.EliminarTransporteAsync(id);
                        //    await CargarMostrarTransportesAsync();
                        //    break;
                }

                LimpiarControles();
                DeshabilitarControles();
                dtgpersona.Enabled = true;

                MessageBox.Show("Registro eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }



        //SelectionChanged del DataGridView para mostrar detalles de las tablas
        private async void dtgpersona_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando || cancelado) return;
            if (dtgpersona.CurrentRow == null) return;
            if (dtgpersona.CurrentCell == null) return;

            var fila = dtgpersona.CurrentRow;

            if (fila.Cells["Id"] == null || fila.Cells["Id"].Value == null)
                return;

            int idActual;
            if (!int.TryParse(fila.Cells["Id"].Value.ToString(), out idActual))
                return;

            if (idActual == ultimoId)
                return;

            ultimoId = idActual;

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
                    textBox3.Text = fila.Cells["Director"]?.Value?.ToString() ?? "";
                    textBox4.Text = fila.Cells["Productor"]?.Value?.ToString() ?? "";
                    textBox5.Text = fila.Cells["FechaDeLanzamiento"]?.Value?.ToString() ?? "";
                    textBox6.Text = fila.Cells["Avance"]?.Value?.ToString() ?? "";

                    CargarImagen(fila);
                    break;

                case "Planetas":
                    textBox1.Text = fila.Cells["Nombre"]?.Value?.ToString() ?? "";
                    textBox2.Text = fila.Cells["PeriodoDeRotación"]?.Value?.ToString() ?? "";
                    textBox3.Text = fila.Cells["PeriodoOrbital"]?.Value?.ToString() ?? "";
                    textBox4.Text = fila.Cells["Diametro"]?.Value?.ToString() ?? "";
                    textBox5.Text = fila.Cells["Clima"]?.Value?.ToString() ?? "";
                    textBox6.Text = fila.Cells["Gravedad"]?.Value?.ToString() ?? "";
                    textBox7.Text = fila.Cells["Terreno"]?.Value?.ToString() ?? "";

                    CargarImagen(fila);
                    break;

                case "Especies":
                    textBox1.Text = fila.Cells["Nombre"]?.Value?.ToString() ?? "";
                    textBox2.Text = fila.Cells["Clasificacion"]?.Value?.ToString() ?? "";
                    textBox3.Text = fila.Cells["Designacion"]?.Value?.ToString() ?? "";
                    textBox4.Text = fila.Cells["AlturaPromedio"]?.Value?.ToString() ?? "";
                    textBox5.Text = fila.Cells["ColoresDePiel"]?.Value?.ToString() ?? "";
                    textBox6.Text = fila.Cells["ColoresDeOjos"]?.Value?.ToString() ?? "";
                    textBox7.Text = fila.Cells["Idioma"]?.Value?.ToString() ?? "";

                    CargarImagen(fila);
                    break;

                case "Transportes":
                    textBox1.Text = fila.Cells["Nombre"]?.Value?.ToString() ?? "";
                    textBox2.Text = fila.Cells["Modelo"]?.Value?.ToString() ?? "";
                    textBox3.Text = fila.Cells["Fabricante"]?.Value?.ToString() ?? "";
                    textBox4.Text = fila.Cells["CostoEnCreditos"]?.Value?.ToString() ?? "";
                    textBox5.Text = fila.Cells["Longitud"]?.Value?.ToString() ?? "";
                    textBox6.Text = fila.Cells["VelocidadMaximaAtmosfera"]?.Value?.ToString() ?? "";
                    textBox7.Text = fila.Cells["Tripulacion"]?.Value?.ToString() ?? "";

                    CargarImagen(fila);
                    break;
            }
        }

        // Métodos para cargar, guardar y mostrar datos de las tablas
        //PERSONAS
        private async Task ObtenerPersonasBD()
        {
            try
            {
                cargando = true;
                vistaActual = "Personas";

                var lista = await _personaService.ObtenerPersonas();

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
                ultimoId = -1;
                LimpiarControles();
                cargando = false;
            }
        }
        //PELÍCULAS
        private async Task ObtenerPeliculasBD()
        {
            try
            {
                cargando = true;
                vistaActual = "Peliculas";

                var lista = await _peliculaService.ObtenerPeliculas();

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
        private async Task ObtenerPlanetasBD()
        {
            try
            {
                cargando = true;
                vistaActual = "Planetas";

                var lista = await _planetaService.ObtenerPlanetas();

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
                ultimoId = -1;
                LimpiarControles();
                cargando = false;
            }
        }

        private async Task ObtenerEspeciesBD()
        {
            try
            {
                cargando = true;
                vistaActual = "Especies";

                var lista = await _especieService.ObtenerEspecies();

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
                ultimoId = -1;
                LimpiarControles();
                cargando = false;
            }
        }

        private async Task ObtenerTransportesBD()
        {
            try
            {
                cargando = true;
                vistaActual = "Transportes";

                var lista = await _transporteService.ObtenerTransportes();

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
                ultimoId = -1;
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

            groupBox1.Visible = true;
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
            label3.Text = "Director:";
            label4.Text = "Productor:";
            label5.Text = "Lanzamiento:";
            label6.Text = "Avance:";
            textBox6.Multiline = true;
            textBox6.Size = new Size(textBox6.Width, 200);

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
            checkedListBox1.Visible = false;

            label12.Text = "";
            checkedListBox2.Visible = false;

            groupBox1.Visible = false;

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
            textBox7.Text = "";

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox2.Items.Count; i++)
                checkedListBox2.SetItemChecked(i, false);

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

            btneditar.Enabled = false;
            btnnuevo.Enabled = false;
            btncancelar.Enabled = true;
            btnimagen.Enabled = true;
            btneliminar.Enabled = false;

        }

        private void DeshabilitarControles()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;

            checkedListBox1.Enabled = false;
            checkedListBox2.Enabled = false;

            btnimagen.Enabled = false;
            btnnuevo.Enabled = true;
            btneliminar.Enabled = true;
            btneditar.Enabled = true;
            btnactualizar.Enabled = false;

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
        }
        private async Task CargarEspeciesAsync()
        {
            var especies = await _especieService.ObtenerEspecies();

            comboBox2.DataSource = null;

            comboBox2.DataSource = especies;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "Id";
        }
        private async Task CargarPlanetasAsync()
        {
            var planetas = await _planetaService.ObtenerPlanetas();

            comboBox3.DataSource = null;

            comboBox3.DataSource = planetas;
            comboBox3.DisplayMember = "Nombre";
            comboBox3.ValueMember = "Id";
        }
        private async Task CargarPeliculasAsync()
        {
            var peliculas = await _peliculaService.ObtenerPeliculas();

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
            var vehiculos = await _transporteService.ObtenerTransportes();

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
            if (combosCargados) return;

            try
            {
                combosCargados = true;
                cargando = true;

                CargarGeneros();
                await CargarEspeciesAsync();
                await CargarPlanetasAsync();
                await CargarPeliculasAsync();
                await CargarVehiculosAsync();
            }
            finally
            {
                combosCargados = false;
                cargando = false;
            }
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

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}