using Florage.Payments.Contracts;
using Florage.Payments.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Florage.Payments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(CreateOrderDto orderDto)
        {
            await _orderService.CreateOrderAsync(orderDto);
            return Ok();
        }
    }
}
