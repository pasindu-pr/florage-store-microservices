using Florage.Products.Contracts;
using Florage.Products.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Florage.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService; 

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService; 
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<GetProductDto>>> GetAllProductsAsync()
        {
            IReadOnlyCollection<GetProductDto> products = await _productsService.GetAllAsync();
            return Ok(products);
        }
         
        [HttpGet("id")]
        public async Task<ActionResult<GetProductDto>> GetProductByIdAsync(string id)
        {
            GetProductDto product = await _productsService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(CreateProductDto productDto)
        {
            await _productsService.CreateAsync(productDto);
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateProductAsync(string id, UpdateProductDto updateProductDto)
        {
            await _productsService.UpdateAsync(id, updateProductDto);
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProductAsync(string id)
        {
            await _productsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
