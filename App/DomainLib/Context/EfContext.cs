using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Context
{
    public class EfContext : DbContext
    {
        public DbSet<Kindergarden> Kindergardens { get; set; }
        public DbSet<Child> Children { get; set; }
    }
}
