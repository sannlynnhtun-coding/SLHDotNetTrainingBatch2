using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch2.ConsoleApp
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> lst = db.Blogs
                .Where(x => x.DeleteFlag == false) // 1,000
                .OrderByDescending(x => x.BlogId)
                //.ToList() // execute 10,000 delete 9,000
                .ToList();
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
            string result = Console.ReadLine()!;

            bool isInt = int.TryParse(result, out int id);
            if (!isInt) return;

            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.BlogId == id); // top 2
            if (item is null)
            {
                return;
            }

            Console.WriteLine("BlogId => " + item.BlogId);
            Console.WriteLine("BlogTitle => " + item.BlogTitle);
            Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
            Console.WriteLine("BlogContent => " + item.BlogContent);

            //foreach (var x in db.Blogs)
            //{
            //    if(x.BlogId == id)
            //    {
            //        return x;
            //    }
            //}
        }

        public void Create()
        {
            Console.Write("Enter title : ");
            string title = Console.ReadLine()!;
            Console.Write("Enter author : ");
            string author = Console.ReadLine()!;
            Console.Write("Enter content : ");
            string content = Console.ReadLine()!;

            BlogModel blog = new BlogModel
            {
                BlogAuthor = author,
                BlogContent = content,
                BlogTitle = title
            };

            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Saving Successful." : "Saving Failed.");
        }

        public void Update()
        {
            // Input Id
            Console.Write("Enter Id: ");
            string input = Console.ReadLine()!;

            bool isInt = int.TryParse(input, out int id);
            if (!isInt) return;

            // Read Input Data From Console
            Console.Write("Modify title : ");
            string title = Console.ReadLine()!;
            Console.Write("Modify author : ");
            string author = Console.ReadLine()!;
            Console.Write("Modify content : ");
            string content = Console.ReadLine()!;

            // Find Blog Id
            bool isExist = IsExistBlog(id);
            if (!isExist) return;

            // Update Process
            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.BlogId == id);
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Updating Successful." : "Updating Failed.");
        }

        public void Delete()
        {
            // Input Id
            Console.Write("Enter Id: ");
            string input = Console.ReadLine()!;

            bool isInt = int.TryParse(input, out int id);
            if (!isInt) return;

            // Find Blog Id
            bool isExist = IsExistBlog(id);
            if (!isExist) return;

            // Delete Process
            AppDbContext db = new AppDbContext();
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            //db.Blogs.Remove(item);
            item.DeleteFlag = true; // soft delete
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Deleting Successful." : "Deleting Failed.");
        }

        private bool IsExistBlog(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.BlogId == id); // top 2
            //return item == null ? true : false;
            //return !(item == null);
            return item != null;
        }
    }
}
