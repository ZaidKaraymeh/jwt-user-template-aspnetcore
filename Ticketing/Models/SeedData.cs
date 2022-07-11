using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ticketing.Models;
using System;
using System.Linq;


namespace Ticketing.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DatabaseContext>>()))
            {
                // Look for any reocrds.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User
                    {
                        Id = 1,
                        Username = "Zaid",
                        Email = "karaymehzaid@gmail.com",
                        Password = "TestCase12",
                        CreatedDate = DateTime.Parse("2014-06-30 00:00:00.000"),
                    },
                    new User
                    {
                        Id = 1,
                        Username = "Luay",
                        Email = "luayosama@gmail.com",
                        Password = "TestCase12",
                        CreatedDate = DateTime.Parse("2016-12-09 18:03:05.000"),
                    }



                ); ;
                context.SaveChanges();
            }
        }
    }
}
