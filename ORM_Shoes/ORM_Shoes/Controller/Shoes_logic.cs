using ORM_Shoes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Shoes.Controller
{
    public class Shoes_logic
    {
        private Shoes_Context context = new Shoes_Context();

        public Shoes Get(int id)
        {
            Shoes findedShoe = context.Shoes.Find(id);
            if (findedShoe != null)
            {
                context.Entry(findedShoe).Reference(x => x.Shoes_type).Load();
            }
            return findedShoe;
        }
        public List<Shoes> GetAll()
        {
            return context.Shoes.Include("Shoes_type").ToList();
        }
        public void Create(Shoes shoe)
        {
            context.Shoes.Add(shoe);
            context.SaveChanges();
        }
        public void Update(int id, Shoes shoe)
        {
            Shoes findedShoe = context.Shoes.Find(id);
            if (findedShoe == null)
            {
                return;
            }
            findedShoe.Brand = shoe.Brand;
            findedShoe.Description = shoe.Description;
            findedShoe.Price = shoe.Price;
            findedShoe.Nomer = shoe.Nomer;
            findedShoe.Shoes_typeId = shoe.Shoes_typeId;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Shoes findedShoe = context.Shoes.Find(id);
            context.Shoes.Remove(findedShoe);
            context.SaveChanges();
        }
    }
}

