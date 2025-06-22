using SLHDotNetTrainingBatch2.Project1.Database.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch2.Project1.ConsoleApp
{
    public class SaleDetailService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.TblSaleDetails
                .Where(x => x.DeleteFlag == false)
                .ToList();
            foreach (var item in lst)
            {
                Console.WriteLine("SaleDetailID => " + item.SaleDetailId);
                Console.WriteLine("SaleID => " + item.SaleId);
                Console.WriteLine("ProductID => " + item.ProductId);
                Console.WriteLine("Quantity => " + item.Quantity);
                Console.WriteLine("Price => " + item.Price);
            }
        }

        public void Edit()
        {
        FirstPage:
            Console.WriteLine("Enter SaleDetailID : ");
            var input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt) goto FirstPage;
            AppDbContext db = new AppDbContext();
            var item = db.TblSaleDetails.Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.SaleDetailId == id);
            if (item is null) return;
            Console.WriteLine("SaleDetailID => " + item.SaleDetailId);
            Console.WriteLine("SaleID => " + item.SaleId);
            Console.WriteLine("ProductID => " + item.ProductId);
            Console.WriteLine("Quantity => " + item.Quantity);
            Console.WriteLine("Price => " + item.Price);
        }

        public void Create()
        {
            int saleId = ReadInt("Enter SaleID: ");
            int productId = ReadInt("Enter ProductID: ");
            int quantity = ReadInt("Enter Quantity: ");
        PriceInput:
            Console.Write("Enter Price: ");
            var input = Console.ReadLine()!;
            bool isDecimal = decimal.TryParse(input, out decimal price);
            if (!isDecimal)
            {
                goto PriceInput;
            }
            var saleDetail = new TblSaleDetail
            {
                SaleId = saleId,
                ProductId = productId,
                Quantity = quantity,
                Price = price,
            };
            AppDbContext db = new AppDbContext();
            db.TblSaleDetails.Add(saleDetail);
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Create Succeed" : "Create failed");
        }

        public int ReadInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()!;
                if (int.TryParse(input, out value))
                {
                    return value;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}
