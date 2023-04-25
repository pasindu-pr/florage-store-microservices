using Florage.Payments.Dtos;
using MassTransit;

namespace Florage.Payments.AsyncMessagingServices.Publishers
{
    public class PaymentPublishingService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PaymentPublishingService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishPaymentCreatedEvent(PublishPaymentCreatedDto paymentCreatedEvent)
        {
            await _publishEndpoint.Publish(paymentCreatedEvent);
        }
    }
}
