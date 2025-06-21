using Microsoft.Data.SqlClient;
using SLHDotNetTrainingBatch2.ConsoleApp;
using SLHDotNetTrainingBatch2.Database;
using SLHDotNetTrainingBatch2.Database.App2DbContextModels;
using System.Data;
Console.WriteLine("Hello, World!");

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
////adoDotNetExample.Read();
//adoDotNetExample.Edit();
//adoDotNetExample.Create();

// 101 connection timeout 3 mins

//DapperExample dapperExample = new DapperExample();
////dapperExample.Read();
////dapperExample.Edit();
//dapperExample.Create();

EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Edit();
//eFCoreExample.Create();
eFCoreExample.Update();
eFCoreExample.Delete();

//Class1 class1 = new Class1();
//int result = class1.Method(1, 2);

App2DbContext db = new App2DbContext();
db.TblBlogs.ToList();

Console.ReadKey();

// ADO.NET
// Dapper
// EF Core
