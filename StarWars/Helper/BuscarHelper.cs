using StarWars.Models;
using StarWars.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<string>> ObtenerSugerenciasAsync(string vista)
        {
            switch (vista)
            {
                case "Personas":
                    var personas = await _personaService.ObtenerPersonas();

                    return personas
                        .SelectMany(p => new List<string>()
                        {
                    p.Nombre ?? "",
                    p.Altura ?? "",
                    p.Masa ?? "",
                    p.ColorDePiel ?? "",
                    p.ColorDeOjos ?? "",
                    p.ColorDePelo ?? "",
                    p.Cumpleaños ?? "",
                    p.Genero ?? "",
                    p.Planeta != null ? p.Planeta.Nombre ?? "" : "",
                    string.Join(", ", p.Especie.Select(e => e.Nombre)),
                    string.Join(", ", p.Peliculas.Select(pe => pe.Titulo)),
                    string.Join(", ", p.Transportes.Select(t => t.Nombre))
                        })
                        .SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries))
                        .Select(x => x.Trim())
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Distinct()
                        .OrderBy(x => x)
                        .ToList();

                case "Planetas":
                    var planetas = await _planetaService.ObtenerPlanetas();

                    return planetas
                        .SelectMany(p => new List<string>()
                        {
                    p.Nombre ?? "",
                    p.PeriodoDeRotación ?? "",
                    p.PeriodoOrbital ?? "",
                    p.Diametro ?? "",
                    p.Clima ?? "",
                    p.Gravedad ?? "",
                    p.Terreno ?? "",
                    p.AguaSuperficial ?? "",
                    p.Poblacion ?? ""
                        })
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Distinct()
                        .OrderBy(x => x)
                        .ToList();

                case "Peliculas":
                    var peliculas = await _peliculaService.ObtenerPeliculas();

                    return peliculas
                        .SelectMany(p => new List<string>()
                        {
                    p.Titulo ?? "",
                    p.Episode_id.ToString(),
                    p.Director ?? "",
                    p.Productor ?? "",
                    p.FechaDeLanzamiento ?? "",
                    p.Avance ?? ""
                        })
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Distinct()
                        .OrderBy(x => x)
                        .ToList();

                case "Especies":
                    var especies = await _especieService.ObtenerEspecies();

                    return especies
                        .SelectMany(e => new List<string>()
                        {
                    e.Nombre ?? "",
                    e.Clasificacion ?? "",
                    e.Designacion ?? "",
                    e.AlturaPromedio ?? "",
                    e.ColoresDePiel ?? "",
                    e.ColoresDePelo ?? "",
                    e.ColoresDeOjos ?? "",
                    e.EsperanzaDeVida ?? "",
                    e.Idioma ?? ""
                        })
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Distinct()
                        .OrderBy(x => x)
                        .ToList();

                case "Transportes":
                    var transportes = await _transporteService.ObtenerTransportes();

                    return transportes
                        .SelectMany(t => new List<string>()
                        {
                    t.Nombre ?? "",
                    t.Modelo ?? "",
                    t.Fabricante ?? "",
                    t.CostoEnCreditos ?? "",
                    t.Longitud ?? "",
                    t.VelocidadMaximaAtmosfera ?? "",
                    t.Tripulacion ?? "",
                    t.Pasajeros ?? "",
                    t.CapacidadCarga ?? "",
                    t.Consumibles ?? "",
                    t.MGLT ?? "",
                    t.Clase ?? "",
                    t.TipoTransporte != null ? t.TipoTransporte.Nombre ?? "" : ""
                        })
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Distinct()
                        .OrderBy(x => x)
                        .ToList();

                default:
                    return new List<string>();
            }
        }


        public object ResultadoGrip(string vista, object resultado)
        {
            switch (vista)
            {
                case "Personas":
                    var personas = resultado as List<Persona>;
                    return personas.Select(p => new
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

                case "Peliculas":
                    var peliculas = resultado as List<Pelicula>;
                    return peliculas.Select(p => new
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

                case "Planetas":
                    var planetas = resultado as List<Planeta>;
                    return planetas.Select(p => new
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
                        p.Picture
                    }).ToList();

                case "Especies":
                    var especies = resultado as List<Especie>;
                    return especies.Select(e => new
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
                        e.Picture
                    }).ToList();

                case "Transportes":
                    var transportes = resultado as List<Transporte>;
                    return transportes.Select(t => new
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
                        t.Picture
                    }).ToList();

                default:
                    throw new Exception("Vista no válida");
            }
        }

        public (string vistaDestino, string columnaDestino) ObtenerNavegacion(string vistaActual, string nombreColumna)
        {
            if (vistaActual != "Personas")
                return ("", "");

            switch (nombreColumna)
            {
                case "Planeta":
                    return ("Planetas", "Nombre");

                case "Pelicula":
                    return ("Peliculas", "Titulo");

                case "Vehiculo":
                    return ("Transportes", "Nombre");

                default:
                    return ("", "");
            }
        }
    }
}