using ORM_Shoes.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Shoes.Controller
{
    public class Shoes_type_Logic
    {
        private Shoes_Context context = new Shoes_Context();
        public List<Shoes_type> GetAll()
        {
            return context.Shoes_type.ToList();
        }
        public string GetShoeById(int id)
        {
            return context.Shoes_type.Find(id).Shoe_Name;
        }
    }
}
