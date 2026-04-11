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
    public partial class UcPersonas : UserControl
    {
        #region Atributos y Servicios
        private readonly IPersonaService _personaService;
        private readonly IPlanetaService _planetaService;
        private readonly IPeliculaService _peliculaService;
        private readonly ITransporteService _transporteService;

        private readonly ComboHelper _comboHelper;
        private readonly CrearHelper _crearHelper;
        private readonly EditarHelper _editarHelper;
        private readonly EliminarHelper _eliminarHelper;
        private readonly BuscarHelper _buscarHelper;

        private bool combosCargados = false;
        private bool cargando = false;
        private bool cancelado = false;
        private int ultimoId = -1;
        private string rutaImagen = "";
        #endregion

        #region Eventos para navegación opcional
        public event Action<string> AbrirPlanetaDesdePersona;
        public event Action<string> AbrirPeliculaDesdePersona;
        public event Action<string> AbrirTransporteDesdePersona;
        #endregion

        #region Constructor
        public UcPersonas(
            IPersonaService personaService,
            IEspecieService especieService,
            IPlanetaService planetaService,
            IPeliculaService peliculaService,
            ITransporteService transporteService)
        {
            InitializeComponent();

            _personaService = personaService;
            _planetaService = planetaService;
            _peliculaService = peliculaService;
            _transporteService = transporteService;

            _comboHelper = new ComboHelper(especieService, planetaService, peliculaService, transporteService);
            _crearHelper = new CrearHelper(personaService, peliculaService, planetaService, especieService, transporteService);
            _editarHelper = new EditarHelper(personaService, peliculaService, planetaService, especieService, transporteService);
            _eliminarHelper = new EliminarHelper(personaService, peliculaService, planetaService, especieService, transporteService);
            _buscarHelper = new BuscarHelper(personaService, planetaService, peliculaService, especieService, transporteService);

            this.Load += UcPersonas_Load;
            dtgpersona.SelectionChanged += dtgpersona_SelectionChanged;
            dtgpersona.CellDoubleClick += dtgpersona_CellDoubleClick;
            txtbuscar.KeyDown += txtbuscar_KeyDown;
        }
        #endregion

        #region Eventos del UserControl
        private async void UcPersonas_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            try
            {
                cargando = true;

                await ObtenerPersonasBD();
                await AutocomplementarBusqueda();

                dtgpersona.ClearSelection();
                dtgpersona.CurrentCell = null;
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar personas: " + ex.Message);
            }
            finally
            {
                cargando = false;
            }
        }

        private async void dtgpersona_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando || cancelado) return;
            if (dtgpersona.CurrentRow == null || dtgpersona.CurrentCell == null) return;

            var fila = dtgpersona.CurrentRow;
            if (fila.Cells["Id"]?.Value == null) return;

            if (!int.TryParse(fila.Cells["Id"].Value.ToString(), out int idActual)) return;
            if (idActual == ultimoId) return;

            ultimoId = idActual;
            rutaImagen = fila.Cells["Picture"]?.Value?.ToString() ?? "";

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

        private void dtgpersona_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                string nombreColumna = dtgpersona.Columns[e.ColumnIndex].Name;
                string valor = dtgpersona.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(valor)) return;

                if (nombreColumna == "Pelicula" || nombreColumna == "Vehiculo")
                    valor = valor.Split(',')[0].Trim();

                if (nombreColumna == "Planeta")
                {
                    AbrirPlanetaDesdePersona?.Invoke(valor);
                    return;
                }

                if (nombreColumna == "Pelicula")
                {
                    AbrirPeliculaDesdePersona?.Invoke(valor);
                    return;
                }

                if (nombreColumna == "Vehiculo")
                {
                    AbrirTransporteDesdePersona?.Invoke(valor);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al navegar: " + ex.Message);
            }
        }
        #endregion

        #region Buscar
        private async void btbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtbuscar.Text.Trim();

                var resultado = await _buscarHelper.BuscarAsync("Personas", filtro);
                var datos = _buscarHelper.ResultadoGrip("Personas", resultado);

                ConfigurarGrid(datos, "Id", "Picture", "Url");
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
                var sugerencias = await _buscarHelper.ObtenerSugerenciasAsync("Personas");

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
                await ObtenerPersonasBD();
                await AutocomplementarBusqueda();

                dtgpersona.ClearSelection();
                dtgpersona.CurrentCell = null;
                LimpiarControles();
                DeshabilitarControlesInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al refrescar: " + ex.Message);
            }
        }
        #endregion

        #region Botones CRUD
        private async void btnnuevo_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarControles();
                await CargarCombosPersonasAsync();
                HabilitarControles();

                btnnuevo.Enabled = false;
                btncrear.Enabled = true;
                btnactualizar.Enabled = false;
                btneditar.Enabled = false;
                btneliminar.Enabled = false;
                btncancelar.Enabled = true;
                dtgpersona.Enabled = false;

                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar nuevo registro: " + ex.Message);
            }
        }

        private async void btneditar_Click(object sender, EventArgs e)
        {
            if (dtgpersona.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro.");
                return;
            }

            try
            {
                await CargarCombosPersonasAsync();
                await MarcarRelacionadosAsync(dtgpersona.CurrentRow);

                HabilitarControles();

                btncancelar.Enabled = true;
                btnactualizar.Enabled = true;
                btncrear.Enabled = false;
                btneliminar.Enabled = false;
                btnnuevo.Enabled = false;
                dtgpersona.Enabled = false;
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

                await _crearHelper.CrearAsync("Personas", datos);
                await ObtenerPersonasBD();

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
                if (dtgpersona.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un registro.");
                    return;
                }

                var datos = ObtenerDatosFormulario();
                datos.Id = Convert.ToInt32(dtgpersona.CurrentRow.Cells["Id"].Value);

                await _editarHelper.EditarAsync("Personas", datos);
                await ObtenerPersonasBD();

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
                if (dtgpersona.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un registro.");
                    return;
                }

                int id = Convert.ToInt32(dtgpersona.CurrentRow.Cells["Id"].Value);

                var confirmar = MessageBox.Show(
                    "¿Desea eliminar este registro?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmar != DialogResult.Yes) return;

                await _eliminarHelper.EliminarAsync("Personas", id);
                await ObtenerPersonasBD();

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
                OpenFileDialog abrir = new OpenFileDialog
                {
                    Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp"
                };

                if (abrir.ShowDialog() == DialogResult.OK)
                {
                    string rutaOrigen = abrir.FileName;
                    string nombreArchivo = Path.GetFileName(rutaOrigen);
                    string carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes", "Personas");

                    if (!Directory.Exists(carpetaDestino))
                        Directory.CreateDirectory(carpetaDestino);

                    string rutaDestino = Path.Combine(carpetaDestino, nombreArchivo);
                    File.Copy(rutaOrigen, rutaDestino, true);

                    rutaImagen = Path.Combine("Imagenes", "Personas", nombreArchivo);

                    ActualizarPicturebox(rutaDestino);
                    MessageBox.Show("Imagen cargada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar imagen: " + ex.Message);
            }
        }
        #endregion

        #region Métodos
        private async Task ObtenerPersonasBD()
        {
            try
            {
                cargando = true;

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
                    Vehiculo = string.Join(", ", p.Transportes.Select(x => x.Nombre))
                }).ToList();

                ConfigurarGrid(datos, "Id", "Picture");
            }
            finally
            {
                cargando = false;
            }
        }

        private void ConfigurarGrid(object datos, params string[] columnasOcultas)
        {
            dtgpersona.DataSource = null;
            dtgpersona.DataSource = datos;
            dtgpersona.MultiSelect = false;
            dtgpersona.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgpersona.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgpersona.ReadOnly = true;

            foreach (string col in columnasOcultas)
            {
                if (dtgpersona.Columns[col] != null)
                    dtgpersona.Columns[col].Visible = false;
            }
        }

        private async Task CargarCombosPersonasAsync()
        {
            if (combosCargados) return;

            await _comboHelper.CargarCombosPersonasAsync(
                comboBox1,
                comboBox2,
                comboBox3,
                checkedListBox1,
                checkedListBox2);

            combosCargados = true;
        }

        private async Task MarcarRelacionadosAsync(DataGridViewRow fila)
        {
            if (!combosCargados)
                await CargarCombosPersonasAsync();

            _comboHelper.MarcarPeliculasSeleccionadas(
                checkedListBox1,
                fila.Cells["Pelicula"]?.Value?.ToString() ?? "");

            _comboHelper.MarcarVehiculosSeleccionados(
                checkedListBox2,
                fila.Cells["Vehiculo"]?.Value?.ToString() ?? "");
        }

        private void CargarImagen(DataGridViewRow fila)
        {
            string ruta = fila.Cells["Picture"]?.Value?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(ruta))
            {
                ActualizarPicturebox(null);
                return;
            }

            string rutaCompleta = Path.Combine(Application.StartupPath, ruta);

            if (File.Exists(rutaCompleta))
                ActualizarPicturebox(rutaCompleta);
            else
                ActualizarPicturebox(null);
        }

        private void ActualizarPicturebox(string rutaAbsoluta)
        {
            if (Picture1.Image != null)
            {
                Picture1.Image.Dispose();
                Picture1.Image = null;
            }

            if (!string.IsNullOrWhiteSpace(rutaAbsoluta) && File.Exists(rutaAbsoluta))
            {
                using FileStream fs = new FileStream(rutaAbsoluta, FileMode.Open, FileAccess.Read);
                Picture1.Image = new Bitmap(Image.FromStream(fs));
            }
        }

        private void FinalizarAccion()
        {
            LimpiarControles();
            DeshabilitarControlesInicial();

            btnnuevo.Enabled = true;
            btneditar.Enabled = true;
            btneliminar.Enabled = true;
            btncancelar.Enabled = true;
            btncrear.Enabled = false;
            btnactualizar.Enabled = false;
            btnimagen.Enabled = false;
            dtgpersona.Enabled = true;

            dtgpersona.ClearSelection();
            dtgpersona.CurrentCell = null;
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

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox2.Items.Count; i++)
                checkedListBox2.SetItemChecked(i, false);

            ActualizarPicturebox(null);
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

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;

            checkedListBox1.Enabled = true;
            checkedListBox2.Enabled = true;

            btnimagen.Enabled = true;
            btncancelar.Enabled = true;
        }

        private void DeshabilitarControlesInicial()
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

            btncrear.Enabled = false;
            btnactualizar.Enabled = false;
            btncancelar.Enabled = false;
            btnimagen.Enabled = false;
            btneditar.Enabled = false;
            btneliminar.Enabled = false;
        }

        private FormData ObtenerDatosFormulario()
        {
            var datos = new FormData
            {
                Text1 = textBox1.Text.Trim(),
                Text2 = textBox2.Text.Trim(),
                Text3 = textBox3.Text.Trim(),
                Text4 = textBox4.Text.Trim(),
                Text5 = textBox5.Text.Trim(),
                Text6 = textBox6.Text.Trim(),
                Text7 = textBox7.Text.Trim(),
                Combo1 = comboBox1.Text,
                Combo2Value = comboBox2.SelectedValue != null ? Convert.ToInt32(comboBox2.SelectedValue) : null,
                Combo3Value = comboBox3.SelectedValue != null ? Convert.ToInt32(comboBox3.SelectedValue) : null,
                Picture = rutaImagen
            };

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
        #endregion
    }
}