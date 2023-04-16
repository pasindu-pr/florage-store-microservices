using Florage.Products.Contracts;
using Florage.Shared.Contracts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Florage.Products.AsyncServices
{
    public class MessageBusSubscriber: BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IEventProcessor _eventProcessor;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IRabbitMqService _rabbitMqService;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queue;

        public MessageBusSubscriber(
            IConfiguration configuration, 
            IEventProcessor eventProcessor,  
            IServiceScopeFactory serviceScopeFactory)
        {
            _configuration = configuration;
            _eventProcessor = eventProcessor;
            _scopeFactory = serviceScopeFactory;

            using (var scope = _scopeFactory.CreateScope())
            { 
                _rabbitMqService = scope.ServiceProvider.GetRequiredService<IRabbitMqService>();

                _connection = _rabbitMqService.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(exchange: "Inventory", type: ExchangeType.Fanout);
                _queue = _channel.QueueDeclare().QueueName;
                _channel.QueueBind(queue: _queue, exchange: "Inventory", routingKey: "");
            }
             


            Console.WriteLine("Listening");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ModuleHandle, ea) =>
            {
                Console.WriteLine("--> Event Received!");

                var body = ea.Body;
                var notificationMessage = Encoding.UTF8.GetString(body.ToArray());

                _eventProcessor.ProcessEvent(notificationMessage);
            };

            _channel.BasicConsume(queue: _queue, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }

            base.Dispose();
        }
    }
}
