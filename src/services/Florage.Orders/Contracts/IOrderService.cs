using Florage.Orders.Dtos;

namespace Florage.Orders.Contracts
{
    public interface IOrderService
    {
        Task<GetCreatedOrderDto> CreateAsync(CreateOrderDto orderDto);
        Task<IReadOnlyCollection<GetOrderDto>> GetAllOrdersAsync();
        Task SetOrderAsPaidAsync(string orderId);
        Task SetOrderAsApprovedAsync(string orderId);
        Task CalculateAndSaveCommisionAsync(string orderId);
    }
}
