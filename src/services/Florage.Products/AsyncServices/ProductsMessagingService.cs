using Florage.Shared.Contracts;
using RabbitMQ.Client;

namespace Florage.Products.AsyncServices
{
    public class ProductsMessagingService
    {
        IConnection _connection;
        IRabbitMqService _rabbitMqService;

        public ProductsMessagingService(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
            _connection = _rabbitMqService.CreateChannel();
        }
    }
}
