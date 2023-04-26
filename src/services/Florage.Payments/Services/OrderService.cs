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
        private readonly IUserService _userService;

        public OrderService(IRepository<Order> repository, IMapper mapper, IUserService userService)
        {
            _repository = repository;
            _repository.SetCollectionName(Constants.OrdersCollectionName);
            _mapper = mapper;
            _userService = userService;
        }
        
        public async Task CreateOrderAsync(CreateOrderDto orderDto)
        {
            User user = await _userService.GetUserById(orderDto.UserId);

            Order order = new Order
            {
                Id = orderDto.Id,
                User = user,
                TotalPrice = orderDto.TotalPrice, 
                Status = nameof(PaymentStatus.Pending)
            };
            await _repository.CreateAsync(order);
        }

        public async Task<IReadOnlyCollection<GetOrderDto>> GetOrdersAsync()
        {
            IReadOnlyCollection<Order> orders = await _repository.GetAllAsync();
            IReadOnlyCollection<GetOrderDto> mappedOrders = _mapper.Map<IReadOnlyCollection<GetOrderDto>>(orders);
            return mappedOrders;
        }

        public async Task<Order> GetOrderById(string id)
        {
            Order order = await _repository.GetByIdAsync(id);
            return order;
        }
    }
}
