using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StarWars.Models;

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
        public DbSet<Planeta> Transporte { get; set; }
        public DbSet<TipoTransporte> TipoTransporte { get;set; }

        public DbSet<Transporte> Transportes { get; set; }



    }
}
