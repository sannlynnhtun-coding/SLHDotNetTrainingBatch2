// See https://aka.ms/new-console-template for more information
using SLHDotNetTrainingBatch2.Project1.ConsoleApp;

Console.WriteLine("Welcome, Mini POS!");

Result:
Console.WriteLine("Menus");
Console.WriteLine("------------------------------");
Console.WriteLine("1. Product");
Console.WriteLine("2. Sale");
Console.WriteLine("3. Exit");
Console.WriteLine("------------------------------");

Console.Write("Choose Menu: ");
string result = Console.ReadLine()!;
bool isInt = int.TryParse(result, out int no);
if (!isInt)
{
    Console.WriteLine("Invalid Product Menu. Please choose 1 to 3.");
    goto Result;
}

EnumMenu menu = (EnumMenu)no;
switch (menu)
{
    case EnumMenu.Product:
        ProductUI productUI = new ProductUI();
        productUI.Execute();
        goto Result;
    case EnumMenu.Sale:
        SaleUI saleUI = new SaleUI();
        saleUI.Execute();
        goto Result;
    case EnumMenu.Exit:
        goto End;
    case EnumMenu.None:
    default:
        Console.WriteLine("Invalid Menu. Please choose 1 to 3.");
        goto Result;
}

End:
Console.WriteLine("Exiting Mini POS...");
Console.ReadLine();
