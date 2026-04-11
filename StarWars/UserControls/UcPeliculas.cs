using StarWars.Helper;
using StarWars.Helpers;
using StarWars.Models;
using StarWars.Services;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarWars.UserControls
{
    public partial class UcPeliculas : UserControl
    {
        #region Atributos y Servicios
        private readonly IPeliculaService _peliculaService;
        private readonly CrearHelper _crearHelper;
        private readonly EditarHelper _editarHelper;
        private readonly EliminarHelper _eliminarHelper;
        private readonly BuscarHelper _buscarHelper;

        private bool cargando = false;
        private bool cancelado = false;
        private int ultimoId = -1;
        private string rutaImagen = "";
        #endregion

        #region Constructor
        public UcPeliculas(
            IPersonaService personaService,
            IPeliculaService peliculaService,
            IPlanetaService planetaService,
            IEspecieService especieService,
            ITransporteService transporteService)
        {
            InitializeComponent();

            _peliculaService = peliculaService;
            _crearHelper = new CrearHelper(personaService, peliculaService, planetaService, especieService, transporteService);
            _editarHelper = new EditarHelper(personaService, peliculaService, planetaService, especieService, transporteService);
            _eliminarHelper = new EliminarHelper(personaService, peliculaService, planetaService, especieService, transporteService);
            _buscarHelper = new BuscarHelper(personaService, planetaService, peliculaService, especieService, transporteService);

            this.Load += UcPeliculas_Load;
            dtgPeliculas.SelectionChanged += dtgPeliculas_SelectionChanged;
            txtbuscar.KeyDown += txtbuscar_KeyDown;
        }
        #endregion

        #region Eventos del UserControl
        private async void UcPeliculas_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            try
            {
                cargando = true;
                await ObtenerPeliculasBD();
                await AutocomplementarBusqueda();

                dtgPeliculas.ClearSelection();
                dtgPeliculas.CurrentCell = null;
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar películas: " + ex.Message);
            }
            finally
            {
                cargando = false;
            }
        }

        private void dtgPeliculas_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando || cancelado) return;
            if (dtgPeliculas.CurrentRow == null) return;
            if (dtgPeliculas.CurrentCell == null) return;

            var fila = dtgPeliculas.CurrentRow;

            if (fila.Cells["Id"]?.Value == null)
                return;

            if (!int.TryParse(fila.Cells["Id"].Value.ToString(), out int idActual))
                return;

            if (idActual == ultimoId)
                return;

            ultimoId = idActual;
            rutaImagen = fila.Cells["Picture"]?.Value?.ToString() ?? "";

            textBox1.Text = fila.Cells["Titulo"]?.Value?.ToString() ?? "";
            textBox2.Text = fila.Cells["Episode_id"]?.Value?.ToString() ?? "";
            textBox3.Text = fila.Cells["Director"]?.Value?.ToString() ?? "";
            textBox4.Text = fila.Cells["Productor"]?.Value?.ToString() ?? "";
            textBox5.Text = fila.Cells["FechaDeLanzamiento"]?.Value?.ToString() ?? "";
            richTextBox1.Text = fila.Cells["Avance"]?.Value?.ToString() ?? "";

            CargarImagen(fila);

            btneditar.Enabled = true;
            btneliminar.Enabled = true;
        }

        private void txtbuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnbuscar.PerformClick();
            }
        }
        #endregion

        #region Buscar
        private async void btbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtbuscar.Text.Trim();

                var resultado = await _buscarHelper.BuscarAsync("Peliculas", filtro);
                var datos = _buscarHelper.ResultadoGrip("Peliculas", resultado);

                ConfigurarGrid(datos, "Id", "Picture", "Url");
                dtgPeliculas.ClearSelection();
                dtgPeliculas.CurrentCell = null;
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }

        private async Task AutocomplementarBusqueda()
        {
            try
            {
                var sugerencias = await _buscarHelper.ObtenerSugerenciasAsync("Peliculas");

                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                coleccion.AddRange(sugerencias.ToArray());

                txtbuscar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtbuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtbuscar.AutoCompleteCustomSource = coleccion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar autocompletado: " + ex.Message);
            }
        }

        private async void btnrefesh_Click(object sender, EventArgs e)
        {
            try
            {
                txtbuscar.Text = "";
                await ObtenerPeliculasBD();
                await AutocomplementarBusqueda();

                dtgPeliculas.ClearSelection();
                dtgPeliculas.CurrentCell = null;
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al refrescar: " + ex.Message);
            }
        }
        #endregion

        #region Botonera (Acciones)
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarControles();
                HabilitarControles();

                btnnuevo.Enabled = false;
                btncrear.Enabled = true;
                btnactualizar.Enabled = false;
                btneditar.Enabled = false;
                btneliminar.Enabled = false;
                btncancelar.Enabled = true;
                btnimagen.Enabled = true;
                dtgPeliculas.Enabled = false;

                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar nuevo registro: " + ex.Message);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dtgPeliculas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro.");
                return;
            }

            try
            {
                HabilitarControles();
                btncancelar.Enabled = true;
                btnactualizar.Enabled = true;
                btncrear.Enabled = false;
                btneliminar.Enabled = false;
                btnnuevo.Enabled = false;
                btnimagen.Enabled = true;
                dtgPeliculas.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar edición: " + ex.Message);
            }
        }

        private async void btncrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Ingrese un título.");
                    return;
                }

                var datos = ObtenerDatosFormulario();

                await _crearHelper.CrearAsync("Peliculas", datos);
                await ObtenerPeliculasBD();

                MessageBox.Show("Registro creado correctamente.");
                FinalizarAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear: " + ex.Message);
            }
        }

        private async void btnactualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgPeliculas.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un registro.");
                    return;
                }

                var datos = ObtenerDatosFormulario();
                datos.Id = Convert.ToInt32(dtgPeliculas.CurrentRow.Cells["Id"].Value);

                await _editarHelper.EditarAsync("Peliculas", datos);
                await ObtenerPeliculasBD();

                MessageBox.Show("Registro actualizado correctamente.");
                FinalizarAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        private async void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgPeliculas.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un registro.");
                    return;
                }

                int id = Convert.ToInt32(dtgPeliculas.CurrentRow.Cells["Id"].Value);

                DialogResult resultado = MessageBox.Show(
                    "¿Desea eliminar este registro?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                    return;

                await _eliminarHelper.EliminarAsync("Peliculas", id);
                await ObtenerPeliculasBD();

                MessageBox.Show("Registro eliminado correctamente.");
                FinalizarAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            cancelado = true;
            FinalizarAccion();
            cancelado = false;
        }

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
                    string carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes", "Peliculas");

                    if (!Directory.Exists(carpetaDestino))
                        Directory.CreateDirectory(carpetaDestino);

                    string rutaDestino = Path.Combine(carpetaDestino, nombreArchivo);
                    File.Copy(rutaOrigen, rutaDestino, true);
                    rutaImagen = Path.Combine("Imagenes", "Peliculas", nombreArchivo);

                    if (Picture1.Image != null)
                    {
                        Picture1.Image.Dispose();
                        Picture1.Image = null;
                    }

                    using FileStream fs = new FileStream(rutaDestino, FileMode.Open, FileAccess.Read);
                    Picture1.Image = new Bitmap(Image.FromStream(fs));

                    MessageBox.Show("Imagen cargada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar imagen: " + ex.Message);
            }
        }
        #endregion

        #region Métodos de Apoyo
        private async Task ObtenerPeliculasBD()
        {
            try
            {
                cargando = true;

                var lista = await _peliculaService.ObtenerPeliculas();
                var datos = lista.Select(p => new
                {
                    p.Id,
                    p.Titulo,
                    p.Episode_id,
                    p.Director,
                    p.Productor,
                    p.FechaDeLanzamiento,
                    p.Avance,
                    p.Picture
                }).ToList();

                ConfigurarGrid(datos, "Id", "Picture");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar películas: " + ex.Message);
            }
            finally
            {
                cargando = false;
            }
        }

        private void ConfigurarGrid(object datos, params string[] columnasOcultas)
        {
            dtgPeliculas.DataSource = null;
            dtgPeliculas.DataSource = datos;
            dtgPeliculas.MultiSelect = false;
            dtgPeliculas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPeliculas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgPeliculas.ReadOnly = true;

            foreach (string columna in columnasOcultas)
            {
                if (dtgPeliculas.Columns[columna] != null)
                    dtgPeliculas.Columns[columna].Visible = false;
            }
        }

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
                using FileStream fs = new FileStream(rutaCompleta, FileMode.Open, FileAccess.Read);
                Picture1.Image = new Bitmap(Image.FromStream(fs));
            }
        }

        private void LimpiarControles()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            richTextBox1.Clear();

            if (Picture1.Image != null)
            {
                Picture1.Image.Dispose();
                Picture1.Image = null;
            }

            rutaImagen = "";
            ultimoId = -1;
        }

        private void HabilitarControles()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            richTextBox1.Enabled = true;
        }

        private void FinalizarAccion()
        {
            LimpiarControles();

            btnnuevo.Enabled = true;
            btneditar.Enabled = true;
            btneliminar.Enabled = true;
            btncancelar.Enabled = true;
            btncrear.Enabled = false;
            btnactualizar.Enabled = false;
            btnimagen.Enabled = false;
            dtgPeliculas.Enabled = true;

            dtgPeliculas.ClearSelection();
            dtgPeliculas.CurrentCell = null;
        }

        private FormData ObtenerDatosFormulario()
        {
            return new FormData
            {
                Text1 = textBox1.Text.Trim(),
                Text2 = textBox2.Text.Trim(),
                Text3 = textBox3.Text.Trim(),
                Text4 = textBox4.Text.Trim(),
                Text5 = textBox5.Text.Trim(),
                richTextBox = richTextBox1.Text.Trim(),
                Picture = rutaImagen
            };
        }
        #endregion
    }
}