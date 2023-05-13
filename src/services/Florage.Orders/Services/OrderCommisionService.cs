using Florage.Orders.Models;
using Florage.Orders.Utils;
using Florage.Shared.Contracts;

namespace Florage.Orders.Services
{
    public class OrderCommisionService
    {
        private readonly IRepository<OrderCommisions> _repository;

        public OrderCommisionService(IRepository<OrderCommisions> repository)
        {
            _repository = repository;
            _repository.SetCollectionName(Constants.OrderCommisionsCollectionName);
        }

        public async Task<OrderCommisions> CreateAsync(OrderCommisions orderCommisions)
        {
            OrderCommisions insertedOrderCommisions = await _repository.CreateAsync(orderCommisions);
            return insertedOrderCommisions;
        }

        public async Task DeleteAsync(string orderCommisionsId)
        {
            await _repository.DeleteAsync(orderCommisionsId);
        }

        public async Task<IReadOnlyCollection<OrderCommisions>> GetAllAsync()
        {
            IReadOnlyCollection<OrderCommisions> orderCommisions = await _repository.GetAllAsync();
            return orderCommisions;
        } 
    }
}
