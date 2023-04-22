using Florage.Authentication.Models;
using Microsoft.AspNetCore.Identity;

namespace Florage.Authentication.ConfigurationsRegistration
{
    public static class RegisterIdentity
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
                (
                    configuration.GetConnectionString("DefaultConnection"),
                    "Auth"
                )
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
