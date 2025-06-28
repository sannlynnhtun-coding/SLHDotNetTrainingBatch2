using SLHDotNetTrainingBatch2.Project1.Database.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch2.Project1.ConsoleApp
{
    public class SaleFeatureService
    {
        public void Execute()
        {
            AppDbContext db = new AppDbContext();
            List<TblSaleDetail> products = new List<TblSaleDetail>();

        FirstPage:
            Console.Write("Please enter Product Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            // item is null

            Console.WriteLine($"Product Name : {item.PName}");
            Console.WriteLine($"Product Price : {item.Price}");
            Console.Write("Please enter Product Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            products.Add(new TblSaleDetail
            {
                DeleteFlag = false,
                Price = item.Price,
                ProductId = item.ProductId,
                Quantity = quantity,
            });

            Console.WriteLine("Are you sure want to add more? Y/N");
            string result = Console.ReadLine();
            if (result == "Y")
            {
                goto FirstPage;
            }

            // Sale
            TblSale sale = new TblSale()
            {
                DeleteFlag = false,
                SaleDate = DateTime.Now,
                TotalAmount = products.Sum(x => (x.Price * x.Quantity)),
                VoucherNo = Guid.NewGuid().ToString(),
            };
            db.TblSales.Add(sale);
            db.SaveChanges();

            foreach (var product in products)
            {
                product.SaleId = sale.SaleId;
            }

            //var lst = products.Where(x => x.DeleteFlag == false).ToList();
            //db.TblSaleDetails.AddRange(lst);

            db.TblSaleDetails.AddRange(products);
            db.SaveChanges();
        }
    }
}
