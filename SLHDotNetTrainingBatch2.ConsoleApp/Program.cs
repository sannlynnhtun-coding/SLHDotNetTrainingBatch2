using Microsoft.Data.SqlClient;
using SLHDotNetTrainingBatch2.ConsoleApp;
using System.Data;

Console.WriteLine("Hello, World!");

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
////adoDotNetExample.Read();
//adoDotNetExample.Edit();
//adoDotNetExample.Create();

// 101 connection timeout 3 mins

DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit();
dapperExample.Create();

Console.ReadKey();

// ADO.NET
// Dapper
// EF Core
