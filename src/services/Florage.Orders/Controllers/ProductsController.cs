using Florage.Orders.Contracts;
using Florage.Orders.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Florage.Orders.Controllers
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
        public async Task<IActionResult> GetAllAsync()
        {
            IReadOnlyCollection<GetProductDto> products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductDto productDto)
        {
            await _productService.CreateAsync(productDto);
            return Ok();
        }
    }
}
