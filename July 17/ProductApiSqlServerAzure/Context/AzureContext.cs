using Microsoft.EntityFrameworkCore;
using ProductApiSqlServerAzure.Model;
using System.Numerics;

namespace ProductApiSqlServerAzure.Context
{
    public class AzureContext:DbContext
    {
        public AzureContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductID = 101, ProductName = "Laptop", ProductPrice = 500000, ProductImage = "#" },
                 new Product() { ProductID = 102, ProductName = "Laptop", ProductPrice = 500000, ProductImage = "#" }
                );
        }
    }
}
