using Florage.Authentication.Models;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;

namespace Florage.Authentication.ConfigurationsRegistration
{
    public static class RegisterIdentity
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddMongoDbStores<ApplicationUser, ApplicationRole, ObjectId>
                (
                    configuration.GetConnectionString("DefaultConnection"),
                    "Users"
                )
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
