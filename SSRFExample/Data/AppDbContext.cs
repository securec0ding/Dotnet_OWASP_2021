// AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using SSRFExample.Models; // Make sure this namespace matches the folder structure

namespace SSRFExample.Data // Make sure this namespace matches the folder structure
{
    public class AppDbContext : DbContext
    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<UrlData> UrlData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure UrlData as a keyless entity type
            modelBuilder.Entity<UrlData>().HasNoKey();
        }

        
}
}


