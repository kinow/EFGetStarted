using System;
using System.Linq;
using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Model.BloggingContext())
            {
                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog {Url = "http://google.com/"});
                db.SaveChanges();
                
                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();
                
                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://duckduckgo.com/";
                blog.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    }
                );
                db.SaveChanges();
                
                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();
                
                Console.WriteLine("Bye!");
            }
        }
    }
}
