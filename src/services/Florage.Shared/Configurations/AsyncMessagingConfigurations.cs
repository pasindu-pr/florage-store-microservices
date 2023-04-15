using Florage.Shared.Contracts;
using Florage.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Florage.Shared.Configurations
{
    public static class AsyncMessagingConfigurations
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services)
        {
            services.AddSingleton<IRabbitMqService, RabbitMqService>();
            return services;
        }
    }
}
