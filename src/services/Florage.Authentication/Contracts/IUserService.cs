using Microsoft.AspNetCore.Identity;

namespace Florage.Authentication.Contracts
{
    public interface IUserService
    {
        Task<IdentityResult> AddAdminRole();
        Task<IdentityResult> AddUserToAdminRole(string userId);
    }
}
