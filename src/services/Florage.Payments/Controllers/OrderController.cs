using Florage.Payments.Contracts;
using Florage.Payments.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Florage.Payments.Controllers
{
    [Route("api/payments/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<GetOrderDto>>> GetOrdersAsync()
        {
            IReadOnlyCollection<GetOrderDto> orders = await _orderService.GetOrdersAsync();
            return Ok(orders);
        } 
    }
}
