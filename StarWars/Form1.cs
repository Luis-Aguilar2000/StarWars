using StarWars.Services;
using StarWars.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarWars
{
    public partial class Form1 : Form
    {
        #region Atributos y Servicios
        private readonly IPersonaService _personaService;
        private readonly IPeliculaService _peliculaService;
        private readonly IPlanetaService _planetaService;
        private readonly IEspecieService _especieService;
        private readonly ITransporteService _transporteService;
        #endregion

        #region Constructor
        public Form1(
            IPersonaService personaService,
            IPeliculaService peliculaService,
            IPlanetaService planetaService,
            IEspecieService especieService,
            ITransporteService transporteService)
        {
            InitializeComponent();

            _personaService = personaService;
            _peliculaService = peliculaService;
            _planetaService = planetaService;
            _especieService = especieService;
            _transporteService = transporteService;
        }
        #endregion

        #region Eventos del Formulario
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ColorPanel();
                ConfigurarBotones();

                // Sincronización en segundo plano al abrir
                await SincronizarDatosIniciales();

                // Se eliminó AbrirVista("Personas") para que el panel inicie vacío
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message);
            }
        }
        #endregion

        #region Navegación y Control de Vistas
        private void Navegacion_Click(object sender, EventArgs e)
        {
            if (sender is Button boton && boton.Tag != null)
            {
                string vista = boton.Tag.ToString() ?? "";
                AbrirVista(vista);
            }
        }

        private void AbrirVista(string vista)
        {
            var vistas = new Dictionary<string, UserControl>
            {
                {
                    "Personas",
                    new UcPersonas(_personaService, _especieService, _planetaService, _peliculaService, _transporteService)
                },
                {
                    "Peliculas",
                    new UcPeliculas(_personaService, _peliculaService, _planetaService, _especieService, _transporteService)
                },
                {
                    "Planetas",
                    new UcPlanetas(_personaService, _peliculaService, _planetaService, _especieService, _transporteService)
                },
                {
                    "Especies",
                    new UcEspecies(_personaService, _peliculaService, _planetaService, _especieService, _transporteService)
                },
                {
                    "Transportes",
                    new UcTransportes(_personaService, _peliculaService, _planetaService, _especieService, _transporteService)
                }
            };

            if (vistas.TryGetValue(vista, out UserControl uc))
            {
                MostrarControl(uc);
            }
        }

        private void MostrarControl(UserControl uc)
        {
            paneldata.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            paneldata.Controls.Add(uc);
        }
        #endregion

        #region Configuración Visual y Datos
        private void ColorPanel()
        {
            panel1.BackColor = Color.FromArgb(60, 100, 100, 100);
            panel2.BackColor = Color.FromArgb(30, 100, 100, 100);
            paneldata.BackColor = Color.FromArgb(28, 100, 100, 100);
        }

        private void ConfigurarBotones()
        {
            btnpersona.Tag = "Personas";
            btnPeliculas.Tag = "Peliculas";
            btnplanetas.Tag = "Planetas";
            btnespecies.Tag = "Especies";
            btnvehiculos.Tag = "Transportes";

            btnpersona.Click += Navegacion_Click;
            btnPeliculas.Click += Navegacion_Click;
            btnplanetas.Click += Navegacion_Click;
            btnespecies.Click += Navegacion_Click;
            btnvehiculos.Click += Navegacion_Click;
        }

        private async Task SincronizarDatosIniciales()
        {
            await _planetaService.SincronizarPlanetas();
            await _peliculaService.SincronizarPeliculas();
            await _especieService.SincronizarEspecies();
            await _transporteService.SincronizarTransportes();
            await _personaService.SincronizarPersonas();
            await _personaService.RelacionarPersonasAsync();
        }
        #endregion

        private void btnviajes_Click(object sender, EventArgs e)
        {
            // Lógica para viajes
        }
    }
}