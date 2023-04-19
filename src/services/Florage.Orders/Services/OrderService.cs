using AutoMapper;
using Florage.Orders.Contracts;
using Florage.Orders.Dtos;
using Florage.Orders.Models;
using Florage.Orders.Utils;
using Florage.Shared.Contracts;

namespace Florage.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repository;
        private readonly IRepository<Product> _productsRepository;
        private readonly IMapper _mapper;
        private readonly IOrderPublishingService _orderPublishingService;

        public OrderService(IRepository<Order> repository, 
            IRepository<Product> productsRepository, 
            IMapper mapper,
            IOrderPublishingService orderPublishingService)
        {
            _repository = repository;
            _productsRepository = productsRepository;
            _repository.SetCollectionName(Constants.OrdersCollectionName);
            _productsRepository.SetCollectionName(Constants.ProductsCollectionName);
            _mapper = mapper;
            _orderPublishingService = orderPublishingService;
        } 

        public async Task CreateAsync(CreateOrderDto orderDto)
        { 
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            float totalPrice = 0;

            foreach (var orderProductDto in orderDto.Products)
            {
                Product product = await _productsRepository.GetByIdAsync(orderProductDto.Product);
                OrderProduct orderProduct = new OrderProduct
                {
                    Product = product,
                    Quantity = orderProductDto.Quantity
                };

                totalPrice += product.Price * orderProductDto.Quantity;
                orderProducts.Add(orderProduct);
            }

            Order order = new Order
            {
                Products = orderProducts,
                TotalPrice = totalPrice
            };

            Order createdOrder = await _repository.CreateAsync(order);
            _orderPublishingService.PublishCreatedOrder(createdOrder);
        }

        public async Task<IReadOnlyCollection<GetOrderDto>> GetAllOrdersAsync()
        {
            IReadOnlyCollection<Order> orders = await _repository.GetAllAsync();
            IReadOnlyCollection<GetOrderDto> getOrders = _mapper.Map<IReadOnlyCollection<GetOrderDto>>(orders);
            return getOrders;
        }

        public async Task SetOrderAsPaidAsync(string orderId)
        {
            Order order = await _repository.GetByIdAsync(orderId);

            if (order == null)
                throw new KeyNotFoundException();

            order.Status = nameof(OrderStatus.Processing);
            await _repository.UpdateAsync(orderId, order);
        }
    }
}
