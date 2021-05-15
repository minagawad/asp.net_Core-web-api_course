using apicourse.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apicourse.Data
{
    public class AppInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var servicescope=applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<AppDbContext>();
                if (!context.books.Any())
                {
                    context.books.AddRange(new Book
                    {
                        Title = "1st Book title",
                        Description = "1st book description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        CoverUrl = "http......",
                        DateAdded = DateTime.Now

                    },
                    new Book
                    {
                        Title = "2st Book title",
                        Description = "2st book description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 3,
                        Genre = "chemistry",
                        CoverUrl = "http......",
                        DateAdded = DateTime.Now

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
