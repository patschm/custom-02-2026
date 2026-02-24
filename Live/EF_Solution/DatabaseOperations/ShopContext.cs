using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseOperations;

public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<ProductGroup> ProductGroups => Set<ProductGroup>();
    public DbSet<Product> Products => Set<Product>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>().Property(p => p.Name).IsConcurrencyToken();
    }
}
