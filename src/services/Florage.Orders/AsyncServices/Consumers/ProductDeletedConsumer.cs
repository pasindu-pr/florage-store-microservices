using Florage.Orders.Contracts;
using Florage.Shared.Dtos.Products;
using MassTransit;

namespace Florage.Orders.AsyncServices.Consumers
{
    public class ProductDeletedConsumer: IConsumer<PublishProductDeleteDto>
    {
        private readonly IProductService _productService;

        public ProductDeletedConsumer(IProductService productsService)
        {
            _productService = productsService;
        }

        public async Task Consume(ConsumeContext<PublishProductDeleteDto> context)
        {
            await _productService.DeleteAsync(context.Message.ProductId);
        }
    }
}
