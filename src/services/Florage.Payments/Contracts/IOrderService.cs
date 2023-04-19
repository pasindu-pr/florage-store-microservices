using Florage.Payments.Dtos;

namespace Florage.Payments.Contracts
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto orderDto);
        Task<IReadOnlyCollection<GetOrderDto>> GetOrdersAsync();
    }
}
