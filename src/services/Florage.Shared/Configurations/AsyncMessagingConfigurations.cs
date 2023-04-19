using Florage.Shared.Settings;
using Florage.Shared.Utils;
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
            ServiceSettings? serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

            services.AddMassTransit(x =>
            {

                x.AddConsumers(Assembly.GetEntryAssembly());

                x.UsingRabbitMq((ctx, config) =>
                {
                    config.Host(rabbbitMQSettings.HostName, Constants.VHostAddress, c => {
                        c.Username(rabbbitMQSettings.Username);
                        c.Password(rabbbitMQSettings.Password);
                    });

                    config.ConfigureEndpoints(ctx, 
                        new KebabCaseEndpointNameFormatter(serviceSettings.ServiceName, false));
                });

            });

            return services;
        }
    }
}
