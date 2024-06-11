using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Shoes.Model
{
    public class Shoes
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Nomer { get; set; }
        public int Shoes_typeId { get; set; }
        public Shoes_type Shoes_type { get; set; }
    }
}
