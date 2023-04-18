using Florage.Inventory.Contracts;
using Florage.Inventory.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Florage.Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<GetProductDto>>> GetAllProductsAsync()
        {
            IReadOnlyCollection<GetProductDto> products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("id")]
        public async Task<ActionResult<GetProductDto>> GetProductByIdAsync(string id)
        {
            GetProductDto product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(CreateProductDto productDto)
        {
            GetProductDto insertedProduct = await _productService.CreateAsync(productDto);
            return new ObjectResult(insertedProduct) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateProductAsync(string id, UpdateProductDto updateProductDto)
        {
            await _productService.UpdateAsync(id, updateProductDto);
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProductAsync(string id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }

    }
}
