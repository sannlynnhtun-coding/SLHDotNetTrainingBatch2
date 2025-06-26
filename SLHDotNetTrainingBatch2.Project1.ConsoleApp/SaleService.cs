using SLHDotNetTrainingBatch2.Project1.Database.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch2.Project1.ConsoleApp
{
    public class SaleService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.TblSales.ToList();
            foreach (var item in lst)
            {
                Console.Write("SaleID => " + item.SaleId);
                Console.Write("VoucherNo => " + item.VoucherNo);
                Console.WriteLine("Total Amount => " + item.TotalAmount);
                Console.Write("SaleDate => " + item.SaleDate);
            }
        }

        public void Edit()
        {
        FirstPage:
            Console.Write("Enter SaleID: ");
            var input = Console.ReadLine();
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                goto FirstPage;
            }
            AppDbContext db = new AppDbContext();
            var item = db.TblSales.Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.SaleId == id);
            if (item is null) return;
            Console.Write("SaleID => " + item.SaleId);
            Console.Write("VoucherNo => " + item.VoucherNo);
            Console.WriteLine("Total Amount => " + item.TotalAmount);
            Console.Write("SaleDate => " + item.SaleDate);
        }

        public void Create()
        {
            Console.Write("Enter Product Voucher Number: ");
            string voucherNo = Console.ReadLine()!;
        PriceInput:
            Console.Write("Enter Total Amount: ");
            var input = Console.ReadLine()!;
            bool isDecimal = decimal.TryParse(input, out decimal total);
            if (!isDecimal)
            {
                goto PriceInput;
            }
        DateInput:
            Console.WriteLine("Enter Sale Date(e.g., 2025-06-22 or MM/dd/yyyy):: ");
            var dateInput = Console.ReadLine()!;
            bool isDateTime = DateTime.TryParse(dateInput, out DateTime saleDate);
            if (!isDateTime)
            {
                goto DateInput;
            }
            var Sale = new TblSale
            {
                VoucherNo = voucherNo,
                TotalAmount = total,
                SaleDate = saleDate,
            };

            AppDbContext db = new AppDbContext();
            db.TblSales.Add(Sale);
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Create Succeed" : "Create failed");
        }

        public void Execute()
        {
        Result:
            Console.WriteLine("\nSale Service Menu");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. New Sale Summary");
            Console.WriteLine("2. List Sales");
            Console.WriteLine("3. Edit Sale Summary");
            Console.WriteLine("4. Exit");
            Console.WriteLine("------------------------------");

            Console.Write("\nChoose Menu : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int no);
            if (!isInt)
            {
                Console.WriteLine("Invalid Product Menu. Please choose 1 to 4.");
            }
            EnumSalesMenu menu = (EnumSalesMenu)no;
            switch (menu)
            {
                case EnumSalesMenu.NewSale:
                    Console.WriteLine("\nCreate a new sale summary");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine();
                    Create();
                    Console.WriteLine("------------------------------");
                    break;
                case EnumSalesMenu.ListSale:
                    Console.WriteLine("\nObtaining a list of sales");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine();
                    Read();
                    Console.WriteLine("------------------------------");
                    break;
                case EnumSalesMenu.EditSale:
                    Console.WriteLine("\nView a sale summary");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine();
                    Edit();
                    Console.WriteLine("------------------------------");
                    break;
                case EnumSalesMenu.Exit:
                    goto End;
                case EnumSalesMenu.None:
                default:
                    Console.WriteLine("Invalid Product Menu. Please choose 1 to 4.");
                    goto Result;
            }
            Console.WriteLine("------------------------------");
            goto Result;

        End:
            Console.WriteLine("\nExiting Sale Service Menu\n");

        }

        public enum EnumSalesMenu
        {
            None,
            NewSale,
            ListSale,
            EditSale,
            Exit
        }
    }
}
