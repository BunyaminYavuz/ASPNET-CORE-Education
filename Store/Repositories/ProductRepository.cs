using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product) => Create(product);

        public void DeleteOneProduct(Product product) => Remove(product);

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return p.CategoryId is null
                    ? _context
                    .Products
                    .Include(prd => prd.Category)
                    : _context
                    .Products
                    .Include(prd => prd.Category)
                    .Where(prd => prd.CategoryId.Equals(p.CategoryId));
        }

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);
        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p => p.ProductId.Equals(id), trackChanges);
        }

        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            return FindAll(false)
                   .Where(p => p.ShowCase.Equals(true));
        }

        public void UpdateOneProduct(Product product) => Update(product);
    }
}