using StarWars.Models;
using StarWars.Api;
using System;
using System.Collections.Generic;
using System.Text;
using static StarWars.Api.PeliculaSW;

namespace StarWars.Mapeo
{
    public static class PeliculaM
    {
        public static Pelicula Map(PeliculaSW api)
        {
            return new Pelicula
            {
                Titulo = api.title,
                Episode_id = api.episode_id,
                Avance = api.opening_crawl,
                Director = api.director,
                Productor = api.producer,
                FechaDeLanzamiento = api.release_date
            };
        }
    }
}

