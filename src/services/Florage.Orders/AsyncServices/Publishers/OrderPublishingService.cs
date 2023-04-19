using AutoMapper;
using Florage.Orders.Contracts;
using Florage.Orders.Models;
using Florage.Shared.Dtos.Orders;
using MassTransit;

namespace Florage.Orders.AsyncServices.Publishers
{
    public class OrderPublishingService : IOrderPublishingService
    {
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderPublishingService(
            IMapper mapper,
            IPublishEndpoint publishEndpoint)
        {
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async void PublishCreatedOrder(Order order)
        {
            PublishCreateOrderDto publishCreateOrderDto = _mapper.Map<PublishCreateOrderDto>(order);
            await _publishEndpoint.Publish(publishCreateOrderDto);
        }
    }
}
