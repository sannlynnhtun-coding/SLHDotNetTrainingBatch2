using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch2.ConsoleApp
{
    public class DapperExample
    {
        // Read
        // Edit
        // Create
        // Update
        // Delete

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = ".", // server => (local), 
            InitialCatalog = "DotNetTrainingBatch2", // database
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                List<BlogDto> lst = db.Query<BlogDto>("select * from tbl_blog").ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine("BlogId => " + item.BlogId);
                    Console.WriteLine("BlogTitle => " + item.BlogTitle);
                    Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
                    Console.WriteLine("BlogContent => " + item.BlogContent);
                }
            }
        }

        public void Edit()
        {
        FirstPage:
            //object a = new { BlogId = 1, BlogTitle = "Mg Mg" };
            Console.Write("Enter Id: ");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            //if(isInt == false)
            if (!isInt)
            {
                Console.WriteLine("Invid Id. Please enter a valid integer.");
                goto FirstPage;
            }

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<BlogDto>("select * from tbl_blog where BlogId = @BlogId", new BlogDto { BlogId = id });
                if (item == null)
                {
                    Console.WriteLine("Blog not found with Id: " + id);
                    return;
                }

                Console.WriteLine("BlogId => " + item.BlogId);
                Console.WriteLine("BlogTitle => " + item.BlogTitle);
                Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
                Console.WriteLine("BlogContent => " + item.BlogContent);
            }
        }

        public void Create()
        {
            Console.Write("Title : ");
            string title = Console.ReadLine()!;
            Console.Write("Author : ");
            string author = Console.ReadLine()!;
            Console.Write("Content : ");
            string content = Console.ReadLine()!;

            BlogDto blog = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"
                            INSERT INTO [dbo].[Tbl_Blog]
                                        ([BlogTitle]
                                        ,[BlogAuthor]
                                        ,[BlogContent])
                                    VALUES
                                        (@BlogTitle
                                        ,@BlogAuthor
                                        ,@BlogContent)
                            ";
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                int result = db.Execute(query, blog);
                Console.WriteLine(result > 0 ? "Saving Successful." : "Saving Failed.");
            }
        }

        public void Update()
        {
        FirstPage:
            Console.Write("Id : ");
            string input = Console.ReadLine()!;

            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                Console.WriteLine("Invid Id. Please enter a valid integer.");
                goto FirstPage;
            }

            Console.Write("Modify Title : ");
            string title = Console.ReadLine()!;
            Console.Write("Modify Author : ");
            string author = Console.ReadLine()!;
            Console.Write("Modify Content : ");
            string content = Console.ReadLine()!;

            BlogDto blog = new BlogDto()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"
                           UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle
                                  ,[BlogAuthor] = @BlogAuthor
                                  ,[BlogContent] = @BlogContent
                             WHERE BlogId = @BlogId
                            ";
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                int result = db.Execute(query, blog);
                Console.WriteLine(result > 0 ? "Updating Successful." : "Updating Failed.");
            }
        }

        public void Delete()
        {
        FirstPage:
            Console.Write("Id : ");
            string input = Console.ReadLine()!;

            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                Console.WriteLine("Invid Id. Please enter a valid integer.");
                goto FirstPage;
            }

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<BlogDto>("select * from tbl_blog where BlogId = @BlogId", new BlogDto { BlogId = id });
                if (item == null)
                {
                    Console.WriteLine("Blog not found with Id: " + id);
                    return;
                }

                string query = "delete from tbl_blog where BlogId = @BlogId;";

                var result = db.Execute(query, new BlogDto { BlogId = id });
                Console.WriteLine(result > 0 ? "Deleting Successful." : "Deleting Failed.");
            }
        }
    }
}
