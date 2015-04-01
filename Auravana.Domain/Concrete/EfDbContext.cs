using Auravana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auravana.Domain.Concrete
{
    public class EfDbContext : DbContext
    {
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
