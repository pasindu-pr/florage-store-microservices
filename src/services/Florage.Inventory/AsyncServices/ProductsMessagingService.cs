using AutoMapper;
using Florage.Inventory.Contracts;
using Florage.Inventory.Dtos;
using Florage.Inventory.Models;
using Florage.Shared.Contracts;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Florage.Inventory.AsyncServices
{
    public class ProductsMessagingService : IProductsMessagingService
    {
        IConnection _connection;
        private readonly IModel _channel;
        private readonly IMapper _mapper;
        IRabbitMqService _rabbitMqService;

        public ProductsMessagingService(IRabbitMqService rabbitMqService, IMapper mapper)
        {
            _rabbitMqService = rabbitMqService;
            _connection = _rabbitMqService.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "Inventory", type: ExchangeType.Fanout);
            _mapper = mapper;
        }

        public void PublishCreatedProduct(Product product)
        {
            PublishProductDto publishProductDto = _mapper.Map<PublishProductDto>(product);
            publishProductDto.Event = "ProductCreated";
            var message = JsonSerializer.Serialize(publishProductDto);

            if (_connection.IsOpen)
            {
                SendMessage(message);
            }else
            {
                Console.WriteLine("Connection has closed!");
            }
        }

        public void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "Inventory",
                routingKey: "",
                basicProperties: null,
                body: body);
        }

        public void Dispose()
        { 
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }
    }
}
