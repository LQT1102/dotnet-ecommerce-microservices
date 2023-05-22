using Catalog.API.Base;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Services
{
    public interface IProductService
    {
        Task<PaginatedResult<Product>> GetPaginatedProductsAsync(FilterDefinition<Product>? filterDefinition = null, int pageNumber = 1, int pageSize = 10, SortDefinition<Product>? sortDefinition = null, ProjectionDefinition<Product, Product>? projectionDefinition = null);

        Task<Product> GetProductDetailByID(string productID);

        Task<bool> UpdateProduct(string productID, Product newProduct);

        Task<bool> DeleteProduct(string productID);

        Task<Product> CreateProduct(Product newProduct);
    }
}
