using StarWars.Services;

namespace StarWars.Helpers
{
    public class EliminarHelper
    {
        private readonly IPersonaService _personaService;
        private readonly IPeliculaService _peliculaService;
        private readonly IPlanetaService _planetaService;
        private readonly IEspecieService _especieService;
        private readonly ITransporteService _transporteService;

        public EliminarHelper(
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

        public async Task EliminarAsync(string vistaActual, int id)
        {
            switch (vistaActual)
            {
                case "Personas":
                    await _personaService.EliminarPersona(id);
                    break;

                case "Peliculas":
                    await _peliculaService.EliminarPelicula(id);
                    break;

                case "Planetas":
                    await _planetaService.EliminarPlaneta(id);
                    break;

                case "Especies":
                    await _especieService.EliminarEspecie(id);
                    break;

                case "Transportes":
                    await _transporteService.EliminarTransporte(id);
                    break;

                default:
                    throw new Exception("Vista no válida para eliminar.");
            }
        }
    }
}