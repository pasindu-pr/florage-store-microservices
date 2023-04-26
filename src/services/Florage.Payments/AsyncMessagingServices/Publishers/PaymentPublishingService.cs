using Florage.Payments.Contracts;
using Florage.Shared.Dtos.Payment;
using MassTransit;

namespace Florage.Payments.AsyncMessagingServices.Publishers
{
    public class PaymentPublishingService: IPaymentPublishingService
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
