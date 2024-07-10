using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .HasData(
                new Product() { ProductId = 1, ProductName = "Computer", Price = 30_000 },
                new Product() { ProductId = 2, ProductName = "Keyboard", Price = 3_000 },
                new Product() { ProductId = 3, ProductName = "Mouse", Price = 800 },
                new Product() { ProductId = 4, ProductName = "Monitor", Price = 20_000 },
                new Product() { ProductId = 5, ProductName = "Deck", Price = 5_000 }
            );
        }
    }
}
