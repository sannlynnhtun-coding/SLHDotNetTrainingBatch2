using SLHDotNetTrainingBatch2.Project1.Database.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch2.Project1.Domain.Features
{
    public class ProductService
    {
        public List<TblProduct> GetProducts()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.TblProducts.Where(x => x.DeleteFlag == false).ToList();
            return lst;
        }

        public TblProduct? FindProduct(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.ProductId == id);
            return item;
        }

        public int CreatProduct(string name, decimal price)
        {
            var product = new TblProduct
            {
                PName = name,
                Price = price,
                Createat = DateTime.Now,
            };

            AppDbContext db = new AppDbContext();
            db.TblProducts.Add(product);
            var result = db.SaveChanges();
            return result;
        }

        public int UpdateProduct(int id, string name, decimal price)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.ProductId == id);
            if (item is null) return -1;

            item.PName = name;
            item.Price = price;
            item.Createat = DateTime.Now;
            var result = db.SaveChanges();
            return result;
        }

        public int DeleteProduct(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            if(item is null) return -1; 

            item.DeleteFlag = true;
            var result = db.SaveChanges();
            return result;
        }
    }
}
