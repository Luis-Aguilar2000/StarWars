using StarWars.Models;
using StarWars.Services;

namespace StarWars.Helpers
{
    public class ComboHelper
    {
        private readonly IEspecieService _especieService;
        private readonly IPlanetaService _planetaService;
        private readonly IPeliculaService _peliculaService;
        private readonly ITransporteService _transporteService;

        public ComboHelper(
            IEspecieService especieService,
            IPlanetaService planetaService,
            IPeliculaService peliculaService,
            ITransporteService transporteService)
        {
            _especieService = especieService;
            _planetaService = planetaService;
            _peliculaService = peliculaService;
            _transporteService = transporteService;
        }

        public void CargarGeneros(ComboBox combo)
        {
            combo.DataSource = null;
            combo.Items.Clear();

            combo.Items.Add("male");
            combo.Items.Add("female");
            combo.Items.Add("n/a");
            combo.Items.Add("unknown");
        }

        public async Task CargarEspeciesAsync(ComboBox combo)
        {
            var especies = await _especieService.ObtenerEspecies();

            combo.DataSource = null;
            combo.Items.Clear();

            combo.DataSource = especies;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "Id";
            combo.SelectedIndex = -1;
        }

        public async Task CargarPlanetasAsync(ComboBox combo)
        {
            var planetas = await _planetaService.ObtenerPlanetas();

            combo.DataSource = null;
            combo.Items.Clear();

            combo.DataSource = planetas;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "Id";
            combo.SelectedIndex = -1;
        }

        public async Task CargarPeliculasAsync(CheckedListBox check)
        {
            var peliculas = await _peliculaService.ObtenerPeliculas();

            check.DataSource = null;
            check.Items.Clear();

            foreach (var pelicula in peliculas)
            {
                check.Items.Add(pelicula);
            }

            check.DisplayMember = "Titulo";
            check.ValueMember = "Id";
        }

        public async Task CargarVehiculosAsync(CheckedListBox check)
        {
            var vehiculos = await _transporteService.ObtenerTransportes();

            check.DataSource = null;
            check.Items.Clear();

            foreach (var vehiculo in vehiculos)
            {
                check.Items.Add(vehiculo);
            }

            check.DisplayMember = "Nombre";
            check.ValueMember = "Id";
        }

        public async Task CargarCombosPersonasAsync(
            ComboBox comboGenero,
            ComboBox comboEspecie,
            ComboBox comboPlaneta,
            CheckedListBox checkPeliculas,
            CheckedListBox checkVehiculos)
        {
            CargarGeneros(comboGenero);
            await CargarEspeciesAsync(comboEspecie);
            await CargarPlanetasAsync(comboPlaneta);
            await CargarPeliculasAsync(checkPeliculas);
            await CargarVehiculosAsync(checkVehiculos);
        }

        public void MarcarPeliculasSeleccionadas(CheckedListBox check, string peliculasTexto)
        {
            for (int i = 0; i < check.Items.Count; i++)
            {
                check.SetItemChecked(i, false);
            }

            if (string.IsNullOrWhiteSpace(peliculasTexto))
                return;

            var peliculasSeleccionadas = peliculasTexto
                .Split(',')
                .Select(x => x.Trim())
                .ToList();

            for (int i = 0; i < check.Items.Count; i++)
            {
                if (check.Items[i] is Pelicula pelicula &&
                    peliculasSeleccionadas.Contains(pelicula.Titulo))
                {
                    check.SetItemChecked(i, true);
                }
            }
        }

        public void MarcarVehiculosSeleccionados(CheckedListBox check, string vehiculosTexto)
        {
            for (int i = 0; i < check.Items.Count; i++)
            {
                check.SetItemChecked(i, false);
            }

            if (string.IsNullOrWhiteSpace(vehiculosTexto))
                return;

            var vehiculosSeleccionados = vehiculosTexto
                .Split(',')
                .Select(x => x.Trim())
                .ToList();

            for (int i = 0; i < check.Items.Count; i++)
            {
                if (check.Items[i] is Transporte vehiculo &&
                    vehiculosSeleccionados.Contains(vehiculo.Nombre))
                {
                    check.SetItemChecked(i, true);
                }
            }
        }

        public void LimpiarChecks(CheckedListBox check)
        {
            for (int i = 0; i < check.Items.Count; i++)
            {
                check.SetItemChecked(i, false);
            }
        }

        public void LimpiarCombos(ComboBox combo)
        {
            combo.SelectedIndex = -1;
            combo.Text = "";
        }
    }
}