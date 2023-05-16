using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var projectionDefinition = Builders<Product>.Projection
                .Exclude(u => u.Id)
                .Include(u => u.Name)
                .Include(u => u.Description);

            var products = await _productRepository.GetManyAsync(Builders<Product>.Filter.Empty, projectionDefinition: projectionDefinition);
            return products;
        }

    }
}
