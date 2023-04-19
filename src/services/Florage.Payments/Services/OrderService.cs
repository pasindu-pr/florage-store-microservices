using AutoMapper;
using Florage.Payments.Contracts;
using Florage.Payments.Dtos;
using Florage.Payments.Models;
using Florage.Payments.Utils;
using Florage.Shared.Contracts;

namespace Florage.Payments.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _repository.SetCollectionName(Constants.OrdersCollectionName);
            _mapper = mapper;
        }
        
        public async Task CreateOrderAsync(CreateOrderDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);
            await _repository.CreateAsync(order);
        }

        public async Task<IReadOnlyCollection<GetOrderDto>> GetOrdersAsync()
        {
            IReadOnlyCollection<Order> orders = await _repository.GetAllAsync();
            IReadOnlyCollection<GetOrderDto> mappedOrders = _mapper.Map<IReadOnlyCollection<GetOrderDto>>(orders);
            return mappedOrders;
        }
    }
}
