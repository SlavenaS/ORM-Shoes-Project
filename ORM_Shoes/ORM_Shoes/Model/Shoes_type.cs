using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Shoes.Model
{
    public class Shoes_type
    {
        public int Id { get; set; }
        public string Shoe_Name { get; set; }
      
        public ICollection<Shoes> Shoes { get; set; }
    }
}
