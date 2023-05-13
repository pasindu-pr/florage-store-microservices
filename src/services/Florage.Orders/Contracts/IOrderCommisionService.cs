using Florage.Orders.Models;

namespace Florage.Orders.Contracts
{
    public interface IOrderCommisionService
    {
        Task<OrderCommisions> CreateAsync(OrderCommisions orderCommisions);
        Task DeleteAsync(string orderCommisionsId);
        Task<IReadOnlyCollection<OrderCommisions>> GetAllAsync();
    }
}