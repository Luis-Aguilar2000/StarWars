using StarWars.Api;
using StarWars.Data;
using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Mapeo
{
    public static class PlanetaM
    {
        
        public static Planeta Map(PlanetaSW api)
        {
            return new Planeta
            {
                Nombre = api.name,
                PeriodoDeRotación = api.rotation_period,
                PeriodoOrbital = api.orbital_period,
                Diametro = api.diameter,
                Clima = api.climate,
                Gravedad = api.gravity,
                Terreno = api.terrain,
                AguaSuperficial = api.surface_water,
                Poblacion = api.population
            };
        }
        
    }
}
