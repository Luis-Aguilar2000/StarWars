using StarWars.Models;
using Microsoft.EntityFrameworkCore;

namespace StarWars.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Especie> Especies { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<Persona> Personas { get; set; }
<<<<<<< HEAD
        public DbSet<Planeta> Peliculas { get; set; }
=======
        public DbSet<Planeta> planeta { get; set; }
>>>>>>> a391e937e6cb1ebb78ccebda417fd3cc0fbd2053
        public DbSet<TipoTransporte> TipoTransporte { get;set; }

        public DbSet<Transporte> Transportes { get; set; }



    }
}
