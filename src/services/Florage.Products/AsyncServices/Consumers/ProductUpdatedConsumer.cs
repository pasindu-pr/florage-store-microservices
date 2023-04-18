using AutoMapper;
using Florage.Products.Contracts;
using Florage.Products.Dtos;
using Florage.Shared.Dtos.Products;
using MassTransit;

namespace Florage.Products.AsyncServices.Consumers
{
    public class ProductUpdatedConsumer : IConsumer<PublishProductUpdateDto>
    {

        private readonly IProductsService _productService;
        private readonly IMapper _mapper;

        public ProductUpdatedConsumer(IMapper mapper, IProductsService productsService)
        {
            _productService = productsService;
            _mapper = mapper;
        }
        
        public async Task Consume(ConsumeContext<PublishProductUpdateDto> context)
        { 
            UpdateProductDto updateProductDto = _mapper.Map<UpdateProductDto>(context.Message);
            string productToUpdateId = context.Message.Id;

            await _productService.UpdateAsync(productToUpdateId, updateProductDto);
        }
    }
}
