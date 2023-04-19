using Florage.Orders.Models;

namespace Florage.Orders.Contracts
{
    public interface IOrderPublishingService
    {
        void PublishCreatedOrder(Order order);
    }
}
