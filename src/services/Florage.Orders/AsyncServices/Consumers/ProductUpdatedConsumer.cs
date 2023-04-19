using AutoMapper;
using Florage.Orders.Contracts;
using Florage.Orders.Dtos;
using Florage.Shared.Dtos.Products;
using MassTransit;

namespace Florage.Orders.AsyncServices.Consumers
{
    public class ProductUpdatedConsumer: IConsumer<PublishProductUpdateDto>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductUpdatedConsumer(IMapper mapper, IProductService productsService)
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
