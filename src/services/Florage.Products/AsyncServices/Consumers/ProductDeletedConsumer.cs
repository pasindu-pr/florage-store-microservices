using MassTransit;
using Florage.Shared.Dtos.Products;
using Florage.Products.Contracts;

namespace Florage.Products.AsyncServices.Consumers
{
    public class ProductDeletedConsumer : IConsumer<PublishProductDeleteDto>
    {
        private readonly IProductsService _productService; 

        public ProductDeletedConsumer(IProductsService productsService)
        {
            _productService = productsService; 
        }

        public async Task Consume(ConsumeContext<PublishProductDeleteDto> context)
        {
            await _productService.DeleteAsync(context.Message.ProductId);
        }
    }
}
