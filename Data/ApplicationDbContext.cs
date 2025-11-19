using meta.Models;
using Microsoft.EntityFrameworkCore;

namespace meta.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<Comment> Comment { get; set; }
}