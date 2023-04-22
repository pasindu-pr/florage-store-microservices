using Microsoft.AspNetCore.Identity;

namespace Florage.Authentication.Contracts
{
    public interface IUserService
    { 
        Task<IdentityResult> AddRequiredRoles();
        Task<IdentityResult> AddUserToAdminRole(string userId);
        Task<IdentityResult> AddUserToSellerRole(string userId);
        Task<IdentityResult> SeedRolesAndUsers();
    }
}
