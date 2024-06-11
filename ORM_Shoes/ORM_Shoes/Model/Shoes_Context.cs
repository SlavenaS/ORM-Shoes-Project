using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Shoes.Model
{
    public class Shoes_Context:DbContext
    {
        public Shoes_Context() : base("Shoes_Context") { }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<Shoes_type> Shoes_type { get; set; }
    }
}
