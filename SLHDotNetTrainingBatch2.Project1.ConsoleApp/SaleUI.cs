﻿using SLHDotNetTrainingBatch2.Project1.Database.AppDbContextModels;
using SLHDotNetTrainingBatch2.Project1.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch2.Project1.ConsoleApp
{
    public class SaleUI
    {
        public void Execute()
        {
            Result:
            Console.WriteLine("Sale Menu");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. New Sale");
            Console.WriteLine("2. Sale List");
            Console.WriteLine("3. Sale Detail");
            Console.WriteLine("4. Exit");
            Console.WriteLine("------------------------------");

            Console.Write("Choose Menu: ");
            string result = Console.ReadLine()!;
            bool isInt = int.TryParse(result, out int no);
            if (!isInt)
            {
                Console.WriteLine("Invalid Sale Menu. Please choose 1 to 4.");
                goto Result;
            }

            Console.WriteLine("------------------------------");
            EnumSaleMenu menu = (EnumSaleMenu)no;
            switch (menu)
            {
                case EnumSaleMenu.NewSale:
                    NewSale();
                    break;
                case EnumSaleMenu.SaleList:
                    break;
                case EnumSaleMenu.SaleDetail:
                    SaleDetail();
                    break;
                case EnumSaleMenu.Exit:
                    break;
                case EnumSaleMenu.None:
                default:
                    Console.WriteLine("Invalid Sale Menu. Please choose 1 to 4.");
                    goto Result;
            }

            Console.WriteLine("------------------------------");
            goto Result;

            End:
            Console.WriteLine("Exiting Product Menu...");
        }

        public void NewSale() // UI / API / WEB
        {
            SaleService saleService = new SaleService();

            List<TblSaleDetail> products = new List<TblSaleDetail>();

            FirstPage:

            #region Prepare Product

            Console.Write("Please enter Product Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var item = saleService.FindProduct(id);

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

            #endregion

            #region Add more product or Continue

            Console.WriteLine("Are you sure want to add more? Y/N");
            string confirm = Console.ReadLine();
            if (confirm == "Y")
            {
                goto FirstPage;
            }

            #endregion

            #region Sale Process

            int result = saleService.Sale(products);
            Console.WriteLine(result > 0 ? "Sale Processing Success." : "Failed.");
            Console.WriteLine("--------------------------------------------------");

            #endregion
        }

        public void SaleDetail()
        {
            SaleService saleService = new SaleService();

            #region Sale ID Input & Validation

            FirstPage:

            Console.Write("Please enter sale id to view detail : ");
            int saleId = Convert.ToInt32(Console.ReadLine());

            var sale = saleService.FindSale(saleId);
            if (sale == null)
            {
                Console.Write("Sale not found! Do you want to find another sale? Y/N : ");
                string result = Console.ReadLine();
                if (result == "Y")
                {
                    goto FirstPage;
                }

                return;
            }

            #endregion

            #region Sale Header Display

            List<TblSaleDetail> saleDetailLst = saleService.GetSaleDetails(saleId);

            Console.WriteLine("Sale Details");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Sale ID: {sale.SaleId}");
            Console.WriteLine($"Voucher No: {sale.VoucherNo}");
            Console.WriteLine($"Date: {sale.SaleDate?.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Total Amount: {sale.TotalAmount:N2}");
            Console.WriteLine("--------------------------------------------------");

            #endregion

            #region Sale Items Display

            Console.WriteLine("Products:");
            Console.WriteLine("--------------------------------------------------");

            foreach (var detail in saleDetailLst)
            {
                var product = saleService.FindProduct(detail.ProductId);
                decimal subtotal = detail.Quantity * detail.Price;

                Console.WriteLine($"Product Id : {detail.ProductId}");
                Console.WriteLine($"Product Name : {product.PName}");
                Console.WriteLine($"Product Quantity : {detail.Quantity}");
                Console.WriteLine($"Product Price : {detail.Price:N2}");
                Console.WriteLine($"Subtotal : {subtotal:N2}");
                Console.WriteLine("--------------------------------------------------");
            }

            Console.WriteLine("End of sale details.");

            #endregion
        }
    }

    public enum EnumSaleMenu
    {
        None,
        NewSale,
        SaleList,
        SaleDetail,
        Exit
    }
}