using AutoMapper;
using Florage.Orders.Contracts;
using Florage.Orders.Dtos;
using Florage.Shared.Dtos.Products;
using MassTransit;

namespace Florage.Orders.AsyncServices.Consumers
{
    public class ProductCreatedConsumer : IConsumer<PublishProductCreateDto>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductCreatedConsumer(IProductService productsService, IMapper mapper)
        {
            _productService = productsService;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<PublishProductCreateDto> context)
        {
            CreateProductDto createProduct = _mapper.Map<CreateProductDto>(context.Message);
            await _productService.CreateAsync(createProduct);
        }
    }
}
