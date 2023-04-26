using Florage.Orders.Contracts;
using Florage.Shared.Dtos.Payment;
using MassTransit;

namespace Florage.Orders.AsyncServices.Consumers
{
    public class PaymentConfirmedConsumer : IConsumer<PublishPaymentCreatedDto>
    {
        private readonly IOrderService _orderService;

        public PaymentConfirmedConsumer(IOrderService orderService)
        {
            _orderService = orderService;
        }

        
        public async Task Consume(ConsumeContext<PublishPaymentCreatedDto> context)
        {
            await _orderService.SetOrderAsPaidAsync(context.Message.OrderId);
        }
    }
}
