using Florage.Payments.Dtos;
using Florage.Payments.Models;

namespace Florage.Payments.Contracts
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto orderDto);
        Task<IReadOnlyCollection<GetOrderDto>> GetOrdersAsync();
        Task<Order> GetOrderById(string id);
    }
}
