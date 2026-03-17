using StarWars.Models;
using StarWars.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Mapeo
{
    public static class EspecieM
    {
        
        
            public static Especie Map(EspecieSW api)
            {
                return new Especie
                {
                    Nombre = api.name,
                    Clasificacion = api.classification,
                    Designacion = api.designation,
                    EsperanzaDeVida = api.average_lifespan
                };
            }
        
    }
}
