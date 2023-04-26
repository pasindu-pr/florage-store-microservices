using Florage.Shared.Dtos.Payment;

namespace Florage.Payments.Contracts
{
    public interface IPaymentPublishingService
    {
        Task PublishPaymentCreatedEvent(PublishPaymentCreatedDto paymentCreatedEvent);
    }
}
