using Stripe;

namespace Florage.Payments.Contracts
{
    public interface IPaymentService
    {
        Task CreatePaymentAsync(Event @event);
    }
}
