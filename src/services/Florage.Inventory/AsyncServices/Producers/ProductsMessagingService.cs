using AutoMapper;
using Florage.Inventory.Contracts;
using Florage.Inventory.Models;
using Florage.Shared.Dtos.Products;
using MassTransit;

namespace Florage.Inventory.AsyncServices.Producers
{
    public class ProductsMessagingService : IProductsMessagingService
    {
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public ProductsMessagingService(
            IMapper mapper,
            IPublishEndpoint publishEndpoint)
        {
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public void PublishCreatedProduct(Product product)
        {
            PublishProductCreateDto publishProductDto = _mapper.Map<PublishProductCreateDto>(product);
            _publishEndpoint.Publish(publishProductDto);
        }

        public void PublishUpdateProduct(Product product)
        {
            PublishProductUpdateDto updateProduct = _mapper.Map<PublishProductUpdateDto>(product);
            _publishEndpoint.Publish(updateProduct);
        }

        public void PublishDeleteProduct(string productId)
        {
            PublishProductDeleteDto deleteProduct = new PublishProductDeleteDto { ProductId = productId };
            _publishEndpoint.Publish(deleteProduct);
        }
    }
}
