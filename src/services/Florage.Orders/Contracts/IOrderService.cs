using Florage.Orders.Dtos;

namespace Florage.Orders.Contracts
{
    public interface IOrderService
    {
        Task CreateAsync(CreateOrderDto orderDto);
        Task<IReadOnlyCollection<GetOrderDto>> GetAllOrdersAsync(); 
        
    }
}
