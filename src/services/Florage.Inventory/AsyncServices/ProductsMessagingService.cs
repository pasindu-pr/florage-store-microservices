using AutoMapper;
using Florage.Inventory.Contracts;
using Florage.Inventory.Dtos;
using Florage.Inventory.Models;
using MassTransit;

namespace Florage.Inventory.AsyncServices
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
            PublishProductDto publishProductDto = _mapper.Map<PublishProductDto>(product);
            _publishEndpoint.Publish<PublishProductDto>(publishProductDto);
        }        
    }
}
