using AutoMapper;
using Florage.Products.Contracts;
using Florage.Products.Dtos;
using Florage.Shared.Dtos.Products;
using MassTransit;

namespace Florage.Products.AsyncServices.Consumers
{
    public class ProductCreatedConsumer : IConsumer<PublishProductCreateDto>
    {
        private readonly IProductsService _productService;
        private readonly IMapper _mapper;

        public ProductCreatedConsumer(IProductsService productsService, IMapper mapper)
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
