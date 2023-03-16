using AspNetCore.Identity.Mongo;
using AspNetCore.Identity.Mongo.Model;

namespace Florage.Authentication.ConfigurationsRegistration
{
    public static class RegisterIdentity
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityMongoDbProvider<MongoUser, MongoRole>(identity =>
            {
                identity.Password.RequiredLength = 8;
            },
                mongo =>
            {
                mongo.ConnectionString = configuration.GetConnectionString("DefaultConnection");
            });

            return services;
        }
    }
}
