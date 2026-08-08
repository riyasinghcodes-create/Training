using System;
using Microsoft.EntityFrameworkCore;
using productservice.models;


namespace productservice.data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(10, 2);
        }

        public DbSet<Product> Products { get; set; }
    }
}