using Arctus.ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace Arctus.ApiService.DbContexts;

public class ArctusContext : DbContext
{
    public ArctusContext(DbContextOptions<ArctusContext> options) 
        : base(options) { }

    public DbSet<Book> Books => Set<Book>();
}
