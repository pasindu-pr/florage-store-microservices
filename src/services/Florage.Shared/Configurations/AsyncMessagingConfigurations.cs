using Florage.Shared.Settings;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Florage.Shared.Configurations
{
    public static class AsyncMessagingConfigurations
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {

            RabbbitMQSettings? rabbbitMQSettings = configuration.GetSection(nameof(RabbbitMQSettings)).Get<RabbbitMQSettings>();
            
            services.AddMassTransit(x =>
            {

                x.AddConsumers(Assembly.GetEntryAssembly());
                
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
