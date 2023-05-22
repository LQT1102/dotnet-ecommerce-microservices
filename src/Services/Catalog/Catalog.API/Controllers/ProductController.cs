using Catalog.API.Base;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using Catalog.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Api trả về danh sách
        /// TODO: Custom body truyền lên để lọc thêm
        /// </summary>
        /// <returns></returns>
        [HttpPost("filter")]
        [ProducesResponseType(typeof(ApiResponse<PaginatedResult<Product>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<PaginatedResult<Product>>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<PaginatedResult<Product>>>> GetProducts()
        {
            var response = new ApiResponse<PaginatedResult<Product>> ();
            try
            {
                var projectionDefinition = Builders<Product>.Projection
               .Include(u => u.Id)
               .Include(u => u.Name)
               .Include(u => u.Description);

                var paginatedProducts = await _productService.GetPaginatedProductsAsync(Builders<Product>.Filter.Empty, projectionDefinition: projectionDefinition);
                response.Data = paginatedProducts;

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Success = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Api trả về 1 bản ghi
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<Product>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<Product>>> GetOneProduct([FromRoute] string id)
        {
            var response = new ApiResponse<Product>();
            try
            {
                var product = await _productService.GetProductDetailByID(id);
                response.Data = product;

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Success = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Api Update 1 bản ghi
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(ApiResponse<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<Product>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<Product>>> UpdateOneProduct([FromRoute] string id, [FromBody] Product product)
        {
            var response = new ApiResponse<Product>();
            try
            {
                var updated = await _productService.UpdateProduct(id, product);
                response.Data = product;

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Success = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Api thêm 1 bản ghi
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<Product>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<Product>>> InsertOneProduct([FromBody] Product product)
        {
            var response = new ApiResponse<Product>();
            try
            {
                var updated = await _productService.CreateProduct(product);
                response.Data = product;

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Success = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Api xóa 1 bản ghi
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteOneProduct([FromRoute] string id)
        {
            var response = new ApiResponse<string>();
            try
            {
                var deleted = await _productService.DeleteProduct(id);
                response.Data = id;

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Success = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
