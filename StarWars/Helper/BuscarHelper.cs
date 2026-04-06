using StarWars.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;



namespace StarWars.Helper
{
    public class BuscarHelper
    {
        private readonly IPersonaService _personaService;
        private readonly IPlanetaService _planetaService;
        private readonly IPeliculaService _peliculaService;
        private readonly IEspecieService _especieService;
        private readonly ITransporteService _transporteService;

        public BuscarHelper(
            IPersonaService personaService,
            IPlanetaService planetaService,
            IPeliculaService peliculaService,
            IEspecieService especieService,
            ITransporteService transporteService)
        {
            _personaService = personaService;
            _planetaService = planetaService;
            _peliculaService = peliculaService;
            _especieService = especieService;
            _transporteService = transporteService;
        }

        public async Task<object> BuscarAsync(string vista, string filtro)
        {
            switch (vista)
            {
                case "Personas":
                    return await _personaService.BuscarAsync(filtro);

                case "Planetas":
                    return await _planetaService.BuscarAsync(filtro);

                case "Peliculas":
                    return await _peliculaService.BuscarAsync(filtro);

                case "Especies":
                    return await _especieService.BuscarAsync(filtro);

                case "Transportes":
                    return await _transporteService.BuscarAsync(filtro);

                default:
                    throw new Exception("Vista no válida");
            }
        }

        public static List<string> ObtenerPalabras(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return new List<string>();

            return texto
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .ToList();
        }
    }
}
