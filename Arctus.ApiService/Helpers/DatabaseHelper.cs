using Arctus.ApiService.DbContexts;
using Arctus.ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace Arctus.ApiService.Helpers;

public static class DatabaseHelper
{
    public static void Seed(ArctusContext context)
    {
        context.Database.Migrate();
        if (context.Books.Count() == 0)
        {
            context.Books.AddRange(
                new Book
                {
                    Title = "Don Quixote"
                },
                new Book
                {
                    Title = "Moby-Dick"
                },
                new Book
                {
                    Title = "1984"
                }
            );
            context.SaveChanges();
        }
    }
}
