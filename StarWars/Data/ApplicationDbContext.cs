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
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Planeta> Planetas { get; set; }
        public DbSet<TipoTransporte> TiposTransporte { get;set; }
        public DbSet<Transporte> Transportes { get; set; }



    }
}
