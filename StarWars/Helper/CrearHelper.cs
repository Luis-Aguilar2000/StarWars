using StarWars.Models;
using StarWars.Services;

namespace StarWars.Helpers
{
    public class CrearHelper
    {
        private readonly IPersonaService _personaService;
        private readonly IPeliculaService _peliculaService;
        private readonly IPlanetaService _planetaService;
        private readonly IEspecieService _especieService;
        private readonly ITransporteService _transporteService;

        public CrearHelper(
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

        public async Task CrearAsync(string vistaActual, FormData datos)
        {
            switch (vistaActual)
            {
                case "Personas":
                    await CrearPersonaAsync(datos);
                    break;

                case "Peliculas":
                    await CrearPeliculaAsync(datos);
                    break;

                case "Planetas":
                    await CrearPlanetaAsync(datos);
                    break;

                case "Especies":
                    await CrearEspecieAsync(datos);
                    break;

                case "Transportes":
                    await CrearTransporteAsync(datos);
                    break;

                default:
                    throw new Exception("Vista no válida para crear.");
            }
        }

        private async Task CrearPersonaAsync(FormData datos)
        {
            Persona persona = new Persona
            {
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
            };

            await _personaService.CrearPersona(
                persona,
                datos.Combo2Value,
                datos.PeliculasSeleccionadas,
                datos.TransportesSeleccionados
            );
        }

        private async Task CrearPeliculaAsync(FormData datos)
        {
            Pelicula pelicula = new Pelicula
            {
                Titulo = datos.Text1,
                Episode_id = int.TryParse(datos.Text2, out int episodio) ? episodio : 0,
                Director = datos.Text3,
                Productor = datos.Text4,
                FechaDeLanzamiento = datos.Text5,
                Avance = datos.richTextBox,
                Picture = datos.Picture
            };

            await _peliculaService.CrearPelicula(pelicula);
        }

        private async Task CrearPlanetaAsync(FormData datos)
        {
            Planeta planeta = new Planeta
            {
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

            await _planetaService.CrearPlaneta(planeta);
        }

        private async Task CrearEspecieAsync(FormData datos)
        {
            Especie especie = new Especie
            {
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

            await _especieService.CrearEspecie(especie);
        }

        private async Task CrearTransporteAsync(FormData datos)
        {
            Transporte transporte = new Transporte
            {
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
                TipoTransporteId = datos.Combo4Value ?? 0
            };

            await _transporteService.CrearTransporte(transporte);
        }
    }
}