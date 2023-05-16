using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TSProducRepo : Repo, IRepo<Product, string, Product>
    {
        public Product Create(Product obj)
        {
            db.Products.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string product)
        {
            var data = Read(product);
            db.Products.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Product> Read()
        {
            return db.Products.ToList();
        }

        public Product Read(string product)
        {
            return db.Products.FirstOrDefault(c => c.ProductName == product);
        }

        public Product Update(Product Obj)
        {
            var exdata = db.Products.Find(Obj.Id);
            db.Entry(exdata).CurrentValues.SetValues(Obj);
            if (db.SaveChanges() > 0) return Obj;
            return null;
        }
    }
}
