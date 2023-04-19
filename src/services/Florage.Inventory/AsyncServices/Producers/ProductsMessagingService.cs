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

        public async void PublishCreatedProduct(Product product)
        {
            PublishProductCreateDto publishProductDto = _mapper.Map<PublishProductCreateDto>(product);
            await _publishEndpoint.Publish(publishProductDto);
        }

        public async void PublishUpdateProduct(Product product)
        {
            PublishProductUpdateDto updateProduct = _mapper.Map<PublishProductUpdateDto>(product);
            await _publishEndpoint.Publish(updateProduct);
        }

        public async void PublishDeleteProduct(string productId)
        {
            PublishProductDeleteDto deleteProduct = new PublishProductDeleteDto { ProductId = productId };
            await _publishEndpoint.Publish(deleteProduct);
        }
    }
}
