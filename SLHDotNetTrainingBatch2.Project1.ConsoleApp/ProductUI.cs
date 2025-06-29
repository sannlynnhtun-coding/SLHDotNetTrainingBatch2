using SLHDotNetTrainingBatch2.Project1.Database.AppDbContextModels;
using SLHDotNetTrainingBatch2.Project1.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch2.Project1.ConsoleApp
{
    public class ProductUI
    {
        public void Read()
        {
            //AppDbContext db = new AppDbContext();
            //var lst = db.TblProducts.Where(x => x.DeleteFlag == false).ToList();
            ProductService productService = new ProductService();
            var lst = productService.GetProducts();
            foreach (var item in lst)
            {
                Console.WriteLine("ProductID => " + item.ProductId);
                Console.WriteLine("Product Name => " + item.PName);
                Console.WriteLine("Price => " + item.Price);
                Console.WriteLine("Create at => " + item.Createat);
                Console.WriteLine("-------------------------------");
            }
        }

        public void Edit()
        {
        FirstPage:
            Console.Write("Enter ProductID: ");
            var input = Console.ReadLine();
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                goto FirstPage;
            }

            ProductService productService = new ProductService();
            var item = productService.FindProduct(id);

            if (item is null) return;
            Console.WriteLine("ProductID => " + item.ProductId);
            Console.WriteLine("Product Name => " + item.PName);
            Console.WriteLine("Price => " + item.Price);
            Console.WriteLine("Create at => " + item.Createat);
        }

        public void Create()
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine()!;
        PriceInput:
            Console.Write("Enter Price: ");
            var input = Console.ReadLine()!;
            bool isDecimal = decimal.TryParse(input, out decimal price);
            if (!isDecimal)
            {
                goto PriceInput;
            }

            ProductService productService = new ProductService();
            int result = productService.CreatProduct(name, price);

            Console.WriteLine(result > 0 ? "Create Succeed" : "Create failed");
        }

        public void Update()
        {
        ProductIdInput:
            Console.WriteLine("Enter ProductID : ");
            var idInput = Console.ReadLine()!;
            bool isInt = int.TryParse(idInput, out int id);
            if (!isInt) goto ProductIdInput;

            ProductService productService = new ProductService();
            var item = productService.FindProduct(id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                goto ProductIdInput;
            }

            Console.WriteLine(item.PName);
            Console.WriteLine(item.Price);
            Console.WriteLine(item.Createat);

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine()!;
        PriceInput:
            Console.Write("Enter Price: ");
            var input = Console.ReadLine()!;
            bool isDecimal = decimal.TryParse(input, out decimal price);
            if (!isDecimal)
            {
                goto PriceInput;
            }
        DateInput:
            Console.WriteLine("Enter Date(e.g., 2025-06-22 or MM/dd/yyyy) : ");
            var dateInput = Console.ReadLine()!;
            bool isDateTime = DateTime.TryParse(dateInput, out DateTime createdAt);
            if (!isDateTime)
            {
                goto DateInput;
            }

            int result = productService.UpdateProduct(id, name, price);
            if (result == -1)
            {
                Console.WriteLine("No data found.");
                goto ProductIdInput;
            }

            Console.WriteLine(result > 0 ? "Update Success" : "Update Failed");
        }

        public void Delete()
        {
        ProductIdInput:
            Console.WriteLine("Enter ProductID : ");
            var input = Console.ReadLine();
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                goto ProductIdInput;
            }

            ProductService productService = new ProductService();
            var item = productService.FindProduct(id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                goto ProductIdInput;
            }

            int result = productService.DeleteProduct(id);
            if (result == -1)
            {
                Console.WriteLine("No data found.");
                goto ProductIdInput;
            }
            Console.WriteLine(result > 0 ? "Delete Success" : "Delete Failed");
        }

        public void Execute()
        {
        Result:
            Console.WriteLine("Product Menu");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. New Product");
            Console.WriteLine("2. Product List");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");
            Console.WriteLine("------------------------------");

            Console.Write("Choose Menu: ");
            string result = Console.ReadLine()!;
            bool isInt = int.TryParse(result, out int no);
            if (!isInt)
            {
                Console.WriteLine("Invalid Product Menu. Please choose 1 to 5.");
                goto Result;
            }

            Console.WriteLine("------------------------------");
            EnumProductMenu menu = (EnumProductMenu)no;
            switch (menu)
            {
                case EnumProductMenu.NewProduct:
                    Console.WriteLine("this menu is NewProduct.");
                    Console.WriteLine("------------------------------");
                    Create();
                    Console.WriteLine("------------------------------");
                    break;
                case EnumProductMenu.ProductList:
                    Console.WriteLine("this menu is ProductList.");
                    Read();
                    Console.WriteLine("------------------------------");
                    break;
                case EnumProductMenu.EditProdut:
                    Console.WriteLine("this menu is EditProdut.");
                    Update();
                    Console.WriteLine("------------------------------");
                    break;
                case EnumProductMenu.DeleteProduct:
                    Console.WriteLine("this menu is DeleteProduct.");
                    Delete();
                    Console.WriteLine("------------------------------");
                    break;
                case EnumProductMenu.Exit:
                    goto End;
                case EnumProductMenu.None:
                default:
                    Console.WriteLine("Invalid Product Menu. Please choose 1 to 5.");
                    goto Result;
            }
            Console.WriteLine("------------------------------");
            goto Result;

        End:
            Console.WriteLine("Exiting Product Menu...");
        }
    }

    public enum EnumProductMenu
    {
        None,
        NewProduct,
        ProductList,
        EditProdut,
        DeleteProduct,
        Exit
    }

    public enum EnumMenu
    {
        None,
        Product,
        Sale,
        SaleDetail,
        Exit
    }
}
