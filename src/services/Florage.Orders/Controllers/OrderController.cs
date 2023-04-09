using Florage.Orders.Contracts;
using Florage.Orders.Dtos; 
using Microsoft.AspNetCore.Mvc;

namespace Florage.Orders.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<GetOrderDto>>> GetAllAsync()
        {
            IReadOnlyCollection<GetOrderDto> orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        } 

        [HttpPost]
        public async Task<ActionResult> CreateAsync(CreateOrderDto orderDto)
        {
            await _orderService.CreateAsync(orderDto);
            return Ok();
        }

        [HttpPatch]
        public async Task<ActionResult> UpdatePaymentAsync(string orderId)
        {
            try
            {
                await _orderService.SetOrderAsPaidAsync(orderId);
                return Ok();
            }catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
