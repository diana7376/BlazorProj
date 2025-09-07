using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Proj.Infrastructure.Persistence;

// Simple entity used for the Products table
public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; } = "";
    public decimal Price { get; set; }
}

public class projSQLContext : DbContext
{
    public projSQLContext(DbContextOptions<projSQLContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(b =>
        {
            b.ToTable("Products");
            b.HasKey(p => p.Id);
            b.Property(p => p.ProductName)
                .HasMaxLength(200)
                .IsRequired();
            b.Property(p => p.Price)
                .HasPrecision(18, 2); // decimal(18,2)
        });
    }
}
