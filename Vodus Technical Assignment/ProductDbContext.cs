using Microsoft.EntityFrameworkCore;

using Vodus_Technical_Assignment.Models;

public class ProductDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Configure the database provider and connection string for PostgreSQL here.
            optionsBuilder.UseNpgsql("Host=your_host_address;Port=5432;Database=product;Username=productapp;Password=demopassword;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
  
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Sample Product 1", Description = "Description 1", Price = 10.99M },
            new Product { Id = 2, Name = "Sample Product 2", Description = "Description 2", Price = 19.99M },
            new Product { Id = 3, Name = "Sample Product 3", Description = "Description 3", Price = 5.49M }
        
        );
    }
}
