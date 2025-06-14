using Microsoft.Data.SqlClient;
using System.Data;

namespace SLHDotNetTrainingBatch2.ConsoleApp
{
    public class AdoDotNetExample
    {
        // Ctrl + R, R
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch2",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = "select * from Tbl_Blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            List<BlogDto> lst = new List<BlogDto>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(i);
                Console.WriteLine("BlogId => " + row["BlogId"]);
                Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
                Console.WriteLine("BlogAuthor => " + row["BlogAuthor"]);
                Console.WriteLine("BlogContent => " + row["BlogContent"]);
                BlogDto blog = new BlogDto();
                blog.BlogId = Convert.ToInt32(row["BlogId"]);
                blog.BlogTitle = Convert.ToString(row["BlogTitle"])!;
                blog.BlogAuthor = Convert.ToString(row["BlogAuthor"])!;
                blog.BlogContent = Convert.ToString(row["BlogContent"])!;
                lst.Add(blog);
            }

            foreach (var item in lst)
            {
                Console.WriteLine("BlogId => " + item.BlogId);
                Console.WriteLine("BlogTitle => " + item.BlogTitle);
                Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
                Console.WriteLine("BlogContent => " + item.BlogContent);
            }
        }

        public void Edit()
        {
            Console.Write("Enter Id: ");
            string blogId = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $"select * from Tbl_Blog Where BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", blogId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(i);
                Console.WriteLine("BlogId => " + row["BlogId"]);
                Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
                Console.WriteLine("BlogAuthor => " + row["BlogAuthor"]);
                Console.WriteLine("BlogContent => " + row["BlogContent"]);
            }
        }

        // read => data read
        // create => 
        // update =>
        // delete =>

        public void Create()
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author: ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content: ");
            string content = Console.ReadLine()!;

            //       string query = $@"INSERT INTO [dbo].[Tbl_Blog]
            //      ([BlogTitle]
            //      ,[BlogAuthor]
            //      ,[BlogContent])
            //VALUES
            //      ('{title}'
            //      ,'{author}'
            //      ,'{content}')";

            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@Title
           ,@Author
           ,@Content)";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Content", content);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result > 0 ? "Insert Success!" : "Insert Failed!");
        }

        public void Update()
        {
            string query = @"";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result > 0 ? "Insert Success!" : "Insert Failed!");
        }

        public void Delete()
        {
            string query = @"";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result > 0 ? "Insert Success!" : "Insert Failed!");
        }
    }
}
