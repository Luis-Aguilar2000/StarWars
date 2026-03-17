using StarWars.Data;
using StarWars.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Mapeo
{
    public static class PersonaM
    {
        public static Persona Map(PersonajeSW api)
        {
            return new Persona
            {
                Nombre = api.name,
                Altura = api.height,
                Masa = api.mass,
                ColorDePiel = api.skin_color,
                ColorDeOjos = api.eye_color,
                ColorDePelo = api.hair_color,
                Cumpleaños = api.birth_year,
                Genero = api.gender,

                
                UrlPeliculas = api.films != null ? string.Join(",", api.films) : null,
                UrlTransportes = api.vehicles != null ? string.Join(",", api.vehicles) : null

               
            };
        }
    }
}
