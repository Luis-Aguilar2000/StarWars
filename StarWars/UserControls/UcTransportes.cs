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
    public partial class UcTransportes : UserControl
    {
        #region Atributos y Servicios
        private readonly ITransporteService _transporteService;
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
        public UcTransportes(
            IPersonaService personaService,
            IPeliculaService peliculaService,
            IPlanetaService planetaService,
            IEspecieService especieService,
            ITransporteService transporteService)
        {
            InitializeComponent();

            _transporteService = transporteService;

            _crearHelper = new CrearHelper(personaService, peliculaService, planetaService, especieService, transporteService);
            _editarHelper = new EditarHelper(personaService, peliculaService, planetaService, especieService, transporteService);
            _eliminarHelper = new EliminarHelper(personaService, peliculaService, planetaService, especieService, transporteService);
            _buscarHelper = new BuscarHelper(personaService, planetaService, peliculaService, especieService, transporteService);

            this.Load += UcTransportes_Load;
            dtgTransportes.SelectionChanged += dtgTransportes_SelectionChanged;
            txtbuscar.KeyDown += txtbuscar_KeyDown;
        }
        #endregion

        #region Eventos del UserControl
        private async void UcTransportes_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            try
            {
                cargando = true;
                await CargarComboTipos();
                await ObtenerTransportesBD();
                await AutocomplementarBusqueda();

                dtgTransportes.ClearSelection();
                dtgTransportes.CurrentCell = null;
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar transportes: " + ex.Message);
            }
            finally
            {
                cargando = false;
            }
        }

        private void dtgTransportes_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando || cancelado) return;
            if (dtgTransportes.CurrentRow == null) return;
            if (dtgTransportes.CurrentCell == null) return;

            var fila = dtgTransportes.CurrentRow;

            if (fila.Cells["Id"]?.Value == null)
                return;

            if (!int.TryParse(fila.Cells["Id"].Value.ToString(), out int idActual))
                return;

            if (idActual == ultimoId)
                return;

            ultimoId = idActual;
            rutaImagen = dtgTransportes.Columns.Contains("Picture")
                ? fila.Cells["Picture"]?.Value?.ToString() ?? ""
                : "";

            textBox1.Text = dtgTransportes.Columns.Contains("Nombre") ? fila.Cells["Nombre"]?.Value?.ToString() ?? "" : "";
            textBox2.Text = dtgTransportes.Columns.Contains("Modelo") ? fila.Cells["Modelo"]?.Value?.ToString() ?? "" : "";
            textBox3.Text = dtgTransportes.Columns.Contains("Fabricante") ? fila.Cells["Fabricante"]?.Value?.ToString() ?? "" : "";
            textBox4.Text = dtgTransportes.Columns.Contains("CostoEnCreditos") ? fila.Cells["CostoEnCreditos"]?.Value?.ToString() ?? "" : "";
            textBox5.Text = dtgTransportes.Columns.Contains("Longitud") ? fila.Cells["Longitud"]?.Value?.ToString() ?? "" : "";
            textBox6.Text = dtgTransportes.Columns.Contains("VelocidadMaximaAtmosfera") ? fila.Cells["VelocidadMaximaAtmosfera"]?.Value?.ToString() ?? "" : "";
            textBox7.Text = dtgTransportes.Columns.Contains("Tripulacion") ? fila.Cells["Tripulacion"]?.Value?.ToString() ?? "" : "";
            textBox8.Text = dtgTransportes.Columns.Contains("Pasajeros") ? fila.Cells["Pasajeros"]?.Value?.ToString() ?? "" : "";
            textBox9.Text = dtgTransportes.Columns.Contains("CapacidadCarga") ? fila.Cells["CapacidadCarga"]?.Value?.ToString() ?? "" : "";
            textBox10.Text = dtgTransportes.Columns.Contains("Consumibles") ? fila.Cells["Consumibles"]?.Value?.ToString() ?? "" : "";
            textBox11.Text = dtgTransportes.Columns.Contains("MGLT") ? fila.Cells["MGLT"]?.Value?.ToString() ?? "" : "";
            textBox12.Text = dtgTransportes.Columns.Contains("Clase") ? fila.Cells["Clase"]?.Value?.ToString() ?? "" : "";

            if (dtgTransportes.Columns.Contains("TipoTransporteId") &&
                fila.Cells["TipoTransporteId"]?.Value != null &&
                fila.Cells["TipoTransporteId"].Value != DBNull.Value)
            {
                comboBox1.SelectedValue = Convert.ToInt32(fila.Cells["TipoTransporteId"].Value);
            }
            else if (dtgTransportes.Columns.Contains("TipoTransporte"))
            {
                comboBox1.Text = fila.Cells["TipoTransporte"]?.Value?.ToString() ?? "";
            }
            else
            {
                comboBox1.SelectedIndex = -1;
            }

            if (dtgTransportes.Columns.Contains("Picture"))
                CargarImagen(fila);
            else
                Picture1.Image = null;

            btneditar.Enabled = true;
            btneliminar.Enabled = true;
        }

        private void txtbuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btbuscar.PerformClick();
            }
        }
        #endregion

        #region Buscar
        private async void btbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtbuscar.Text.Trim();

                var resultado = await _buscarHelper.BuscarAsync("Transportes", filtro);
                var datos = _buscarHelper.ResultadoGrip("Transportes", resultado);

                ConfigurarGrid(datos, "Id", "TipoTransporteId", "Picture", "Url");
                dtgTransportes.ClearSelection();
                dtgTransportes.CurrentCell = null;
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
                var sugerencias = await _buscarHelper.ObtenerSugerenciasAsync("Transportes");

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
                await CargarComboTipos();
                await ObtenerTransportesBD();
                await AutocomplementarBusqueda();

                dtgTransportes.ClearSelection();
                dtgTransportes.CurrentCell = null;
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
                dtgTransportes.Enabled = false;

                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar nuevo registro: " + ex.Message);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dtgTransportes.CurrentRow == null)
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
                dtgTransportes.Enabled = false;
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
                    MessageBox.Show("Ingrese un nombre.");
                    return;
                }

                var datos = ObtenerDatosFormulario();

                await _crearHelper.CrearAsync("Transportes", datos);
                await ObtenerTransportesBD();

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
                if (dtgTransportes.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un registro.");
                    return;
                }

                var datos = ObtenerDatosFormulario();
                datos.Id = Convert.ToInt32(dtgTransportes.CurrentRow.Cells["Id"].Value);

                await _editarHelper.EditarAsync("Transportes", datos);
                await ObtenerTransportesBD();

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
                if (dtgTransportes.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un registro.");
                    return;
                }

                int id = Convert.ToInt32(dtgTransportes.CurrentRow.Cells["Id"].Value);

                DialogResult resultado = MessageBox.Show(
                    "¿Desea eliminar este registro?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                    return;

                await _eliminarHelper.EliminarAsync("Transportes", id);
                await ObtenerTransportesBD();

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
                    string carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes", "Transportes");

                    if (!Directory.Exists(carpetaDestino))
                        Directory.CreateDirectory(carpetaDestino);

                    string rutaDestino = Path.Combine(carpetaDestino, nombreArchivo);
                    File.Copy(rutaOrigen, rutaDestino, true);
                    rutaImagen = Path.Combine("Imagenes", "Transportes", nombreArchivo);

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
        private async Task CargarComboTipos()
        {
            var tipos = await _transporteService.ObtenerTiposTransporte();

            comboBox1.DataSource = null;
            comboBox1.DataSource = tipos;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedIndex = -1;
        }

        private async Task ObtenerTransportesBD()
        {
            try
            {
                cargando = true;
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
                    TipoTransporte = t.TipoTransporte != null ? t.TipoTransporte.Nombre : "",
                    t.TipoTransporteId,
                    t.Picture
                }).ToList();

                ConfigurarGrid(datos, "Id", "TipoTransporteId", "Picture");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar transportes: " + ex.Message);
            }
            finally
            {
                cargando = false;
            }
        }

        private void ConfigurarGrid(object datos, params string[] columnasOcultas)
        {
            dtgTransportes.DataSource = null;
            dtgTransportes.DataSource = datos;
            dtgTransportes.MultiSelect = false;
            dtgTransportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgTransportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgTransportes.ReadOnly = true;

            foreach (string columna in columnasOcultas)
            {
                if (dtgTransportes.Columns[columna] != null)
                    dtgTransportes.Columns[columna].Visible = false;
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
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            comboBox1.SelectedIndex = -1;

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
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;
            comboBox1.Enabled = true;
            btnimagen.Enabled = true;
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
            dtgTransportes.Enabled = true;

            dtgTransportes.ClearSelection();
            dtgTransportes.CurrentCell = null;
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
                Text6 = textBox6.Text.Trim(),
                Text7 = textBox7.Text.Trim(),
                Text8 = textBox8.Text.Trim(),
                Text9 = textBox9.Text.Trim(),
                Text10 = textBox10.Text.Trim(),
                Text11 = textBox11.Text.Trim(),
                Text12 = textBox12.Text.Trim(),
                Combo4Value = comboBox1.SelectedValue != null ? Convert.ToInt32(comboBox1.SelectedValue) : 0,
                Picture = rutaImagen
            };
        }
        #endregion
    }
}