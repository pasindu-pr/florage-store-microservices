using Florage.Shared.Settings;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Florage.Shared.Configurations
{
    public static class AsyncMessagingConfigurations
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {

            RabbbitMQSettings? rabbbitMQSettings = configuration.GetSection(nameof(RabbbitMQSettings)).Get<RabbbitMQSettings>();

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((ctx, config) =>
                {
                    config.Host(rabbbitMQSettings.HostName, "/", c => {
                        c.Username(rabbbitMQSettings.Username);
                        c.Password(rabbbitMQSettings.Password);
                    });
                });
            }); 
            
            return services;
        }
    }
}
