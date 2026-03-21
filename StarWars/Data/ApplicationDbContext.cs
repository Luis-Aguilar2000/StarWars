using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
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

    }
}
