using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        IEnumerable<Product> GetShowcaseProducts(bool trackChanges);
        IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
        Product? GetOneProduct(int id, bool trackChanges);
        void CreateOneProduct(ProductDtoForInsertion productDto);
        void UpdateOneProduct(ProductDtoForUpdate productDto);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate? GetOneProductForUpdate(int id, bool trackChanges);
    }
}