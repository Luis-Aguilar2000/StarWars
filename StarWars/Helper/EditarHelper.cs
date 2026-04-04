using StarWars.Models;
using StarWars.Services;

namespace StarWars.Helpers
{
    public class EditarHelper
    {
        private readonly IPersonaService _personaService;
        private readonly IPeliculaService _peliculaService;
        private readonly IPlanetaService _planetaService;
        private readonly IEspecieService _especieService;
        private readonly ITransporteService _transporteService;

        public EditarHelper(
            IPersonaService personaService,
            IPeliculaService peliculaService,
            IPlanetaService planetaService,
            IEspecieService especieService,
            ITransporteService transporteService)
        {
            _personaService = personaService;
            _peliculaService = peliculaService;
            _planetaService = planetaService;
            _especieService = especieService;
            _transporteService = transporteService;
        }

        public async Task EditarAsync(string vistaActual, FormData datos)
        {
            switch (vistaActual)
            {
                case "Personas":
                    await EditarPersonaAsync(datos);
                    break;

                case "Peliculas":
                    await EditarPeliculaAsync(datos);
                    break;

                case "Planetas":
                    await EditarPlanetaAsync(datos);
                    break;

                case "Especies":
                    await EditarEspecieAsync(datos);
                    break;

                case "Transportes":
                    await EditarTransporte(datos);
                    break;

                default:
                    throw new Exception("Vista no válida para editar.");
            }
        }

        private async Task EditarPersonaAsync(FormData datos)
        {
            Persona persona = new Persona
            {
                Id = datos.Id,
                Nombre = datos.Text1,
                Altura = datos.Text2,
                Masa = datos.Text3,
                ColorDePiel = datos.Text4,
                ColorDeOjos = datos.Text5,
                ColorDePelo = datos.Text6,
                Cumpleaños = datos.Text7,
                Genero = datos.Combo1,
                Picture = datos.Picture,
                PlanetaId = datos.Combo3Value
            }; ;

            await _personaService.ActualizarPersona(
                persona,
                datos.Combo2Value,
                datos.PeliculasSeleccionadas,
                datos.TransportesSeleccionados
            );
        }

        private async Task EditarPeliculaAsync(FormData datos)
        {
            Pelicula pelicula = new Pelicula
            {
                Id = datos.Id,
                Titulo = datos.Text1,
                Episode_id = int.TryParse(datos.Text2, out int episodio) ? episodio : 0,
                Director = datos.Text3,
                Productor = datos.Text4,
                FechaDeLanzamiento = datos.Text5,
                Avance = datos.richTextBox,
                Picture = datos.Picture
            };

            await _peliculaService.ActualizarPelicula(pelicula);
        }

        private async Task EditarPlanetaAsync(FormData datos)
        {
            Planeta planeta = new Planeta
            {
                Id = datos.Id,
                Nombre = datos.Text1,
                PeriodoDeRotación = datos.Text2,
                PeriodoOrbital = datos.Text3,
                Diametro = datos.Text4,
                Clima = datos.Text5,
                Gravedad = datos.Text6,
                Terreno = datos.Text7,
                AguaSuperficial = datos.Text8,
                Poblacion = datos.Text9,
                Picture = datos.Picture
            };

            await _planetaService.ActualizarPlaneta(planeta);
        }

        private async Task EditarEspecieAsync(FormData datos)
        {
            Especie especie = new Especie
            {
                Id = datos.Id,
                Nombre = datos.Text1,
                Clasificacion = datos.Text2,
                Designacion = datos.Text3,
                AlturaPromedio = datos.Text4,
                ColoresDePiel = datos.Text5,
                ColoresDePelo = datos.Text6,
                ColoresDeOjos = datos.Text7,
                EsperanzaDeVida = datos.Text8,
                Idioma = datos.Text9,
                Picture = datos.Picture
            };

            await _especieService.ActualizarEspecie(especie);
        }

        private async Task EditarTransporte(FormData datos)
        {
            if (datos.Combo4Value == null)
            {
                MessageBox.Show("Seleccione un tipo de transporte.");
                return;
            }

            Transporte transporte = new Transporte
            {
                Id = datos.Id,
                Nombre = datos.Text1,
                Modelo = datos.Text2,
                Fabricante = datos.Text3,
                CostoEnCreditos = datos.Text4,
                Longitud = datos.Text5,
                VelocidadMaximaAtmosfera = datos.Text6,
                Tripulacion = datos.Text7,
                Pasajeros = datos.Text8,
                CapacidadCarga = datos.Text9,
                Consumibles = datos.Text10,
                MGLT = datos.Text11,
                Clase = datos.Text12,
                Picture = datos.Picture,
                TipoTransporteId = datos.Combo4Value.Value
            };

            await _transporteService.ActualizarTransporte(transporte);
        }
    }
}