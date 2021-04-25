using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_book.Data.Models;

namespace my_book.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Book",
                        Description = " 1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 10,
                        Genre = "Fiction",
                        Author = "Da Silva",
                        CoverUrl = "I do not know",
                        DateAdded = DateTime.Now

                    },
                    new Book()
                    {
                        Title = "2nd Book",
                        Description = " 2nd Book Description",
                        IsRead = false,
                        Genre = "Fiction",
                        Author = "Da Silva",
                        CoverUrl = "I do not know either.",
                        DateAdded = DateTime.Today

                    });

                    context.SaveChanges();
                }
            }
        }
    }
}