using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(
                new Product() { ProductId = 1, CategoryId = 2, ProductName = "Computer", Price = 30_000 },
                new Product() { ProductId = 2, CategoryId = 2, ProductName = "Keyboard", Price = 3_000 },
                new Product() { ProductId = 3, CategoryId = 2, ProductName = "Mouse", Price = 800 },
                new Product() { ProductId = 4, CategoryId = 2, ProductName = "Monitor", Price = 20_000 },
                new Product() { ProductId = 5, CategoryId = 2, ProductName = "Deck", Price = 5_000 },
                new Product() { ProductId = 6, CategoryId = 1, ProductName = "History", Price = 1_000 },
                new Product() { ProductId = 7, CategoryId = 1, ProductName = "Science", Price = 2_000 }
            );
        }
    }
}