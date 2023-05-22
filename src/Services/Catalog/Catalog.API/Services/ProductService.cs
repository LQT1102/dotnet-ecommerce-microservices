using Catalog.API.Base;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Core.Authentication;

namespace Catalog.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateProduct(Product newProduct)
        {
            var product = await _productRepository.Create(newProduct);
            return product;
        }

        public async Task<bool> DeleteProduct(string productID)
        {
            await _productRepository.Delete(productID);
            return true;
        }

        public async Task<Product> GetProductDetailByID(string productID)
        {
            var result = await _productRepository.GetOneAync(productID);
            return result;
        }

        public async Task<PaginatedResult<Product>> GetPaginatedProductsAsync(FilterDefinition<Product>? filterDefinition = null, int pageNumber = 1, int pageSize = 10, SortDefinition<Product>? sortDefinition = null, ProjectionDefinition<Product, Product>? projectionDefinition = null)
        {
            var getListTask = _productRepository.GetManyAsync(filterDefinition, (pageNumber - 1) * pageSize, pageSize, sortDefinition, projectionDefinition);
            var getCountTask = _productRepository.GetCountAsync(filterDefinition);

            await Task.WhenAll(getListTask, getCountTask);

            var result = new PaginatedResult<Product>(pageNumber, pageSize, getCountTask.Result, getListTask.Result);
            return result;
        }

        public async Task<bool> UpdateProduct(string productID, Product newProduct)
        {
            await _productRepository.Update(productID, newProduct);
            return true;
        }
    }
}
