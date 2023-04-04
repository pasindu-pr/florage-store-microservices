using Florage.Shared.Contracts; 
using Florage.Shared.Repositories;
using Florage.Shared.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Florage.Shared.Configurations
{
    public static class PersistanceConfigurations
    {
        public static IServiceCollection PersistanceServicesRegistration(this IServiceCollection services)
        {  
            services.AddSingleton(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var dbSettings = configuration.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();
                MongoClient mongoClient = new MongoClient(dbSettings.ConnectionString); 
                return mongoClient.GetDatabase(dbSettings.DatabaseName);
            });

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>)); 

            return services;
        }
    }
}
