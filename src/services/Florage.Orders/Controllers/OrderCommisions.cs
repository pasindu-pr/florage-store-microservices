using AutoMapper;
using Florage.Orders.Contracts;
using Florage.Orders.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Florage.Orders.Controllers
{
    [Route("api/orders/commisions")]
    [ApiController]
    public class OrderCommisions : ControllerBase
    {
        private readonly IOrderCommisionService _orderCommisionService;
        private readonly IMapper _mapper;

        public OrderCommisions(IOrderCommisionService orderCommisionService, IMapper mapper)
        {
            _orderCommisionService = orderCommisionService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IReadOnlyCollection<GetOrderCommisionDto>>> GetAllAsync()
        {
            IReadOnlyCollection<GetOrderCommisionDto> orderCommisions = _mapper.Map<IReadOnlyCollection<GetOrderCommisionDto>>(await _orderCommisionService.GetAllAsync());
            return Ok(orderCommisions);
        }

    }
}
