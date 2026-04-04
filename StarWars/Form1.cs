using Microsoft.EntityFrameworkCore;
using PersistenceLibrary.Interfaces;
using RestLibrary.Interfaces;
using StarWars.Data;
using StarWars.Dtos;
using StarWars.Helpers;
using StarWars.Models;
using StarWars.Services;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        private readonly EditarHelper _editarHelper;
        private readonly CrearHelper _crearHelper;
        private readonly EliminarHelper _eliminarHelper;
        private readonly VistaHelper _vistaHelper;
        private readonly ComboHelper _comboHelper;

        private bool combosCargados = false;
        private bool cargando = false;
        private int ultimoId = -1;
        private string vistaActual = "Personas";
        private bool cancelado = false;
        private string rutaImagen = "";

        public Form1(
            ApplicationDbContext context,
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

            _crearHelper = new CrearHelper(
                _personaService,
                _peliculaService,
                _planetaService,
                _especieService,
                _transporteService
            );

            _editarHelper = new EditarHelper(
                _personaService,
                _peliculaService,
                _planetaService,
                _especieService,
                _transporteService
            );

            _eliminarHelper = new EliminarHelper(
                _personaService,
                _peliculaService,
                _planetaService,
                _especieService,
                _transporteService
            );

            _vistaHelper = new VistaHelper();

            _comboHelper = new ComboHelper(
                _especieService,
                _planetaService,
                _peliculaService,
                _transporteService
            );

            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                cargando = true;

                colorpanel();
                dtgpersona.SelectionChanged += dtgpersona_SelectionChanged;

                await _personaService.SincronizarPersonas();
                await _peliculaService.SincronizarPeliculas();
                await _planetaService.SincronizarPlanetas();
                await _especieService.SincronizarEspecies();
                await _transporteService.SincronizarTransportes();

                await ObtenerPersonasBD();
                await clickPersonas();

                dtgpersona.ClearSelection();
                dtgpersona.CurrentCell = null;
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message);
            }
            finally
            {
                cargando = false;
            }
        }

        // Botonera principal
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
            await ObtenerPlanetasBD();
            clickPlanetas();
        }

        private async void btespecies_Click(object sender, EventArgs e)
        {
            await ObtenerEspeciesBD();
            clickEspecies();
        }

        private async void btvehiculos_Click(object sender, EventArgs e)
        {
            await ObtenerTransportesBD();
            await clickTransporte();
        }

        // EDITAR
        private async void btneditar_Click(object sender, EventArgs e)
        {
            if (dtgpersona.CurrentRow == null || dtgpersona.CurrentRow.Index < 0)
            {
                MessageBox.Show("Seleccione un registro.");
                return;
            }

            try
            {
                if (vistaActual == "Personas")
                {
                    var fila = dtgpersona.CurrentRow;

                    await CargarCombosPersonasAsync();
                    await MarcarRelacionadosAsync(fila);
                }

                // SOLO activar modo edición
                HabilitarControles();

                btncrear.Enabled = false;
                btnactualizar.Enabled = true;
                dtgpersona.Enabled = false;
                richTextBox1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar edición: " + ex.Message);
            }
        }

        // NUEVO
        private async void btnnuevo_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarControles();
                HabilitarControles();

                btncrear.Enabled = true;
                btnactualizar.Enabled = false;
                dtgpersona.Enabled = false;
                if (vistaActual == "Personas")
                {
                    await CargarCombosPersonasAsync();

                    comboBox1.Visible = true;
                    comboBox2.Visible = true;
                    comboBox3.Visible = true;
                    checkedListBox1.Visible = true;
                    checkedListBox2.Visible = true;
                }
                else
                {
                    comboBox1.Visible = false;
                    comboBox2.Visible = false;
                    comboBox3.Visible = false;
                    checkedListBox1.Visible = false;
                    checkedListBox2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar nuevo registro: " + ex.Message);
            }
        }
        // CANCELAR
        private void btncancelar_Click(object sender, EventArgs e)
        {
            cancelado = true;

            DeshabilitarControles();
            dtgpersona.Enabled = true;
            btncrear.Enabled = false;
            btnactualizar.Enabled = false;

            LimpiarControles();

            dtgpersona.ClearSelection();
            dtgpersona.CurrentCell = null;
            ultimoId = -1;

            cancelado = false;
        }

        //SUBIR IMAGEN
        private void btnimagen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog abrir = new OpenFileDialog();
                abrir.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (abrir.ShowDialog() == DialogResult.OK)
                {
                    string rutaOrigen = abrir.FileName;
                    string nombreArchivo = Path.GetFileName(rutaOrigen);

                    string carpetaDestino = "";

                    switch (vistaActual)
                    {
                        case "Personas":
                            carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes", "Personas");
                            break;

                        case "Peliculas":
                            carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes", "Peliculas");
                            break;

                        case "Planetas":
                            carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes", "Planetas");
                            break;

                        case "Especies":
                            carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes", "Especies");
                            break;

                        case "Transportes":
                            carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes", "Transportes");
                            break;

                        default:
                            MessageBox.Show("Seleccione una vista válida antes de subir imagen.");
                            return;
                    }

                    if (!Directory.Exists(carpetaDestino))
                        Directory.CreateDirectory(carpetaDestino);

                    string rutaDestino = Path.Combine(carpetaDestino, nombreArchivo);

                    File.Copy(rutaOrigen, rutaDestino, true);

                    rutaImagen = Path.Combine("Imagenes", vistaActual, nombreArchivo);

                    if (Picture1.Image != null)
                    {
                        Picture1.Image.Dispose();
                        Picture1.Image = null;
                    }

                    using (FileStream fs = new FileStream(rutaDestino, FileMode.Open, FileAccess.Read))
                    {
                        Picture1.Image = new Bitmap(Image.FromStream(fs));
                    }

                    MessageBox.Show("Imagen cargada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar imagen: " + ex.Message);
            }
        }
        // ACTUALIZAR
        private async void btnactualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgpersona.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un registro.");
                    return;
                }

                var datos = ObtenerDatosFormulario();
                datos.Id = Convert.ToInt32(dtgpersona.CurrentRow.Cells["Id"].Value);

                await _editarHelper.EditarAsync(vistaActual, datos);

                await RecargarVistaActual();

                MessageBox.Show("Registro actualizado correctamente");

                LimpiarControles();
                DeshabilitarControles();
                dtgpersona.Enabled = true;
            }
            catch (Exception ex)
            {
                var msg = ex.ToString();

                if (ex.InnerException != null)
                    msg += "\n\nINNER:\n" + ex.InnerException;

                if (ex.InnerException?.InnerException != null)
                    msg += "\n\nINNER 2:\n" + ex.InnerException.InnerException;

                MessageBox.Show(msg);
            }
        }

        // CREAR
        private async void btncrear_Click(object sender, EventArgs e)
        {
            try
            {
                var datos = ObtenerDatosFormulario();

                await _crearHelper.CrearAsync(vistaActual, datos);

                MessageBox.Show("Registro creado correctamente");

                await RecargarVistaActual();

                LimpiarControles();
                DeshabilitarControles();
                dtgpersona.Enabled = true;
                btncrear.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear: " + ex.Message);
            }
        }

        // ELIMINAR
        private async void btneliminar_Click(object sender, EventArgs e)
        {
            if (dtgpersona.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro.");
                return;
            }

            var confirm = MessageBox.Show(
                "¿Desea eliminar este registro?",
                "Confirmación",
                MessageBoxButtons.YesNo
            );

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                int id = Convert.ToInt32(dtgpersona.CurrentRow.Cells["Id"].Value);

                await _eliminarHelper.EliminarAsync(vistaActual, id);

                await RecargarVistaActual();

                MessageBox.Show("Eliminado correctamente");

                LimpiarControles();
                DeshabilitarControles();
                dtgpersona.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        // SelectionChanged del DataGridView
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
            rutaImagen = fila.Cells["Picture"]?.Value?.ToString() ?? "";

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

                    await MarcarRelacionadosAsync(fila);
                    CargarImagen(fila);
                    break;

                case "Peliculas":
                    textBox1.Text = fila.Cells["Titulo"]?.Value?.ToString() ?? "";
                    textBox2.Text = fila.Cells["Episode_id"]?.Value?.ToString() ?? "";
                    textBox3.Text = fila.Cells["Director"]?.Value?.ToString() ?? "";
                    textBox4.Text = fila.Cells["Productor"]?.Value?.ToString() ?? "";
                    textBox5.Text = fila.Cells["FechaDeLanzamiento"]?.Value?.ToString() ?? "";
                    richTextBox1.Text = fila.Cells["Avance"]?.Value?.ToString() ?? "";
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
                    textBox8.Text = fila.Cells["AguaSuperficial"]?.Value?.ToString() ?? "";
                    textBox9.Text = fila.Cells["Poblacion"]?.Value?.ToString() ?? "";
                    CargarImagen(fila);
                    break;

                case "Especies":
                    textBox1.Text = fila.Cells["Nombre"]?.Value?.ToString() ?? "";
                    textBox2.Text = fila.Cells["Clasificacion"]?.Value?.ToString() ?? "";
                    textBox3.Text = fila.Cells["Designacion"]?.Value?.ToString() ?? "";
                    textBox4.Text = fila.Cells["AlturaPromedio"]?.Value?.ToString() ?? "";
                    textBox5.Text = fila.Cells["ColoresDePiel"]?.Value?.ToString() ?? "";
                    textBox6.Text = fila.Cells["ColoresDePelo"]?.Value?.ToString() ?? "";
                    textBox7.Text = fila.Cells["ColoresDeOjos"]?.Value?.ToString() ?? "";
                    textBox8.Text = fila.Cells["Esperanzadevida"]?.Value?.ToString() ?? "";
                    textBox9.Text = fila.Cells["Idioma"]?.Value?.ToString() ?? "";
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
                    textBox8.Text = fila.Cells["Pasajeros"]?.Value?.ToString() ?? "";
                    textBox9.Text = fila.Cells["CapacidadCarga"]?.Value?.ToString() ?? "";
                    textBox10.Text = fila.Cells["Consumibles"]?.Value?.ToString() ?? "";
                    textBox11.Text = fila.Cells["MGLT"]?.Value?.ToString() ?? "";
                    textBox12.Text = fila.Cells["Clase"]?.Value?.ToString() ?? "";
                    comboBox4.Text = fila.Cells["Tipo"]?.Value?.ToString() ?? "";
                    CargarImagen(fila);
                    break;
            }
        }

        // PERSONAS
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

        // PELÍCULAS
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

        // PLANETAS
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

        // ESPECIES
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

        // TRANSPORTES
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
                dtgpersona.ClearSelection();
                dtgpersona.CurrentCell = null;
                ultimoId = -1;
                LimpiarControles();
                cargando = false;
            }
        }

        // VISTAS
        private async Task clickPersonas()
        {
            await _vistaHelper.ConfigurarVistaPersonasAsync(
                lblname,
                label1, label2, label3, label4, label5, label6, label7,
                label8, label9, label10, label11, label12, label13,
                lbPelicula, lbTransporte,
                textBox7, textBox10, textBox11, textBox12,
                comboBox1, comboBox2, comboBox3, comboBox4,
                richTextBox1,
                checkedListBox1, checkedListBox2,
                groupBox1,
                CargarCombosPersonasAsync,
                this
            );
        }

        private void clickPeliculas()
        {
            _vistaHelper.ConfigurarVistaPeliculas(
                lblname,
                label1, label2, label3, label4, label5, label6, label7,
                label8, label9, label10, label11, label12, label13,
                lbPelicula, lbTransporte,
                textBox6, textBox7,
                comboBox1, comboBox2, comboBox3, comboBox4,
                richTextBox1,
                checkedListBox1, checkedListBox2,
                groupBox1,
                this
            );
        }

        private void clickPlanetas()
        {
            _vistaHelper.ConfigurarVistaPlanetas(
                lblname,
                label1, label2, label3, label4, label5, label6, label7,
                label8, label9, label10, label11, label12, label13,
                lbPelicula, lbTransporte,
                textBox6, textBox7, textBox8, textBox9,
                comboBox1, comboBox2, comboBox3, comboBox4,
                richTextBox1,
                checkedListBox1, checkedListBox2,
                groupBox1,
                this
            );
        }
        private void clickEspecies()
        {
            _vistaHelper.ConfigurarVistaEspecies(
                lblname,
                label1, label2, label3, label4, label5, label6, label7,
                label8, label9, label10, label11, label12, label13,
                lbPelicula, lbTransporte,
                textBox6, textBox7, textBox8, textBox9,
                comboBox1, comboBox2, comboBox3, comboBox4,
                richTextBox1,
                checkedListBox1, checkedListBox2,
                groupBox1,
                this
            );
        }

        private async Task clickTransporte()
        {
            _vistaHelper.ConfigurarVistaTransporte(
                lblname,
                label1, label2, label3, label4, label5, label6, label7,
                label8, label9, label10, label11, label12, label13,
                lbPelicula, lbTransporte,
                textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12,
                comboBox1, comboBox2, comboBox3, comboBox4,
                richTextBox1,
                checkedListBox1, checkedListBox2,
                groupBox1,
                this
            );

            await _comboHelper.CargarTipoTransporteAsync(comboBox4);
        }
        // LIMPIAR
        private void LimpiarControles()
        {
            _vistaHelper.LimpiarControles(
                textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12,
                comboBox1, comboBox2, comboBox3, comboBox4,
                richTextBox1,
                checkedListBox1, checkedListBox2,
                Picture1
            );
        }

        private void HabilitarControles()
        {
            _vistaHelper.HabilitarControles(
                textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12,
                comboBox1, comboBox2, comboBox3, comboBox4,
                richTextBox1,
                checkedListBox1, checkedListBox2,
                btneditar, btnnuevo, btncancelar, btnimagen, btneliminar
            );
        }

        private void DeshabilitarControles()
        {
            _vistaHelper.DeshabilitarControles(
                textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12,
                comboBox1, comboBox2, comboBox3, comboBox4,
                checkedListBox1, checkedListBox2,
                btnimagen, btnnuevo, btneliminar, btneditar, btnactualizar
            );
        }

        private void colorpanel()
        {
            panel1.BackColor = Color.FromArgb(60, 100, 100, 100);
            panel2.BackColor = Color.FromArgb(30, 100, 100, 100);
            paneldata.BackColor = Color.FromArgb(28, 100, 100, 100);
        }

        // CARGAR IMAGEN
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

        // CONFIGURAR GRID
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

        // COMBOS PERSONAS
        private async Task CargarCombosPersonasAsync()
        {
            if (combosCargados) return;

            try
            {
                combosCargados = true;
                cargando = true;

                await _comboHelper.CargarCombosPersonasAsync(
                    comboBox1,
                    comboBox2,
                    comboBox3,
                    checkedListBox1,
                    checkedListBox2
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combos: " + ex.Message);
            }
            finally
            {
                cargando = false;
                combosCargados = false;
            }
        }

        // MARCAR RELACIONADOS
        private async Task MarcarRelacionadosAsync(DataGridViewRow fila)
        {
            if (checkedListBox1.Items.Count == 0 || checkedListBox2.Items.Count == 0)
            {
                await CargarCombosPersonasAsync();
            }

            string peliculasTexto = fila.Cells["Pelicula"]?.Value?.ToString() ?? "";
            string vehiculosTexto = fila.Cells["Vehiculo"]?.Value?.ToString() ?? "";

            _comboHelper.MarcarPeliculasSeleccionadas(checkedListBox1, peliculasTexto);
            _comboHelper.MarcarVehiculosSeleccionados(checkedListBox2, vehiculosTexto);
        }

        // RECARGAR VISTA
        private async Task RecargarVistaActual()
        {
            switch (vistaActual)
            {
                case "Personas":
                    await ObtenerPersonasBD();
                    break;

                case "Peliculas":
                    await ObtenerPeliculasBD();
                    break;

                case "Planetas":
                    await ObtenerPlanetasBD();
                    break;

                case "Especies":
                    await ObtenerEspeciesBD();
                    break;

                case "Transportes":
                    await ObtenerTransportesBD();
                    break;
            }
        }

        // OBTENER DATOS FORMULARIO
        private FormData ObtenerDatosFormulario()
        {
            var datos = new FormData
            {
                Text1 = textBox1.Text,
                Text2 = textBox2.Text,
                Text3 = textBox3.Text,
                Text4 = textBox4.Text,
                Text5 = textBox5.Text,
                Text6 = textBox6.Text,
                Text7 = textBox7.Text,
                Text8 = textBox8.Text,
                Text9 = textBox9.Text,
                Text10 = textBox10.Text,
                Text11 = textBox11.Text,
                Text12 = textBox12.Text,
                Combo1 = comboBox1.Text,
                richTextBox = richTextBox1.Text,
                Picture = rutaImagen
            };

            if (comboBox2.SelectedValue != null)
                datos.Combo2Value = Convert.ToInt32(comboBox2.SelectedValue);

            if (comboBox3.SelectedValue != null)
                datos.Combo3Value = Convert.ToInt32(comboBox3.SelectedValue);

            if (comboBox4.SelectedValue != null)
                datos.Combo4Value = Convert.ToInt32(comboBox4.SelectedValue);

            foreach (var item in checkedListBox1.CheckedItems)
            {
                if (item is Pelicula pelicula)
                    datos.PeliculasSeleccionadas.Add(pelicula.Id);
            }

            foreach (var item in checkedListBox2.CheckedItems)
            {
                if (item is Transporte transporte)
                    datos.TransportesSeleccionados.Add(transporte.Id);
            }

            return datos;
        }


    }
}