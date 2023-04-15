using Florage.Shared.Contracts;
using Florage.Shared.Settings;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Florage.Shared.Services
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IConfiguration _configuration;

        public RabbitMqService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConnection CreateChannel()
        {
            RabbbitMQSettings? rabbbitMQSettings = _configuration.GetSection(nameof(RabbbitMQSettings)).Get<RabbbitMQSettings>();

            ConnectionFactory connection = new ConnectionFactory()
            {
                UserName = rabbbitMQSettings.Username,
                Password = rabbbitMQSettings.Password,
                HostName = rabbbitMQSettings.HostName
            };

            connection.DispatchConsumersAsync = true;
            var channel = connection.CreateConnection();
            return channel;
        }
    }
}
