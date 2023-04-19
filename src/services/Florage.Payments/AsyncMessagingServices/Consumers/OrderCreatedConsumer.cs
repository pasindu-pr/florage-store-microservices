using AutoMapper;
using Florage.Payments.Contracts;
using Florage.Payments.Dtos;
using Florage.Shared.Dtos.Orders;
using MassTransit;

namespace Florage.Payments.AsyncMessagingServices.Consumers
{
    public class OrderCreatedConsumer : IConsumer<PublishCreateOrderDto>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderCreatedConsumer(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<PublishCreateOrderDto> context)
        {
            CreateOrderDto createOrderDto = _mapper.Map<CreateOrderDto>(context.Message);
            await _orderService.CreateOrderAsync(createOrderDto);
        }
    }
}
