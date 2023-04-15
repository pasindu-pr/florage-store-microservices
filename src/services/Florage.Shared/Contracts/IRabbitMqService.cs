using RabbitMQ.Client;

namespace Florage.Shared.Contracts
{
    public interface IRabbitMqService
    {
        IConnection CreateConnection();
    }
}
