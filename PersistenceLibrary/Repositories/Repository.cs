using PersistenceLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLibrary.Repositories
{
    public class Repository : IRepository
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }
        public void Add<T>(T model) where T : class
        {
            _context.Set<T>();
            _context.Add(model);
            _context.SaveChanges();
        }
    }
}
