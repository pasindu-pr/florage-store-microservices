using Florage.Authentication.Contracts;
using Florage.Authentication.Dtos;
using Florage.Authentication.Models;
using Microsoft.AspNetCore.Identity;

namespace Florage.Authentication.Services
{
    public class UserService: IUserService
    {
        private RoleManager<ApplicationRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private IAuthService _authService;

        public UserService(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, IAuthService authService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _authService = authService;
        }

        public async Task<IdentityResult> AddRequiredRoles()
        {

            ApplicationRole isAdminRoleExists = await _roleManager.FindByNameAsync("Admin");
            ApplicationRole isSellerRoleExists = await _roleManager.FindByNameAsync("Seller");

            if (isAdminRoleExists == null)
            {

                ApplicationRole applicationRole = new ApplicationRole();
                applicationRole.Name = "Admin";

                IdentityResult identityResult = await _roleManager.CreateAsync(applicationRole);
                return identityResult;
            }

            if (isSellerRoleExists == null)
            {

                ApplicationRole applicationRole = new ApplicationRole();
                applicationRole.Name = "Seller";

                IdentityResult identityResult = await _roleManager.CreateAsync(applicationRole);
                return identityResult;
            }

            return null;
        }

        public async Task<IdentityResult> AddUserToAdminRole(string userId)
        {
            IdentityResult identityResult = await _userManager.AddToRoleAsync(await _userManager.FindByIdAsync(userId), "Admin");
            return identityResult;
        }

        public async Task<IdentityResult> AddUserToSellerRole(string userId)
        {
            IdentityResult identityResult = await _userManager.AddToRoleAsync(await _userManager.FindByIdAsync(userId), "Admin");
            return identityResult;
        }


        public async Task<IdentityResult> SeedRolesAndUsers()
        {
            await AddRequiredRoles();
            UserRegisterDto defaultUser = new UserRegisterDto { Email = "admin@florage.com", Password = "Ss$iNhCb3FWwB8Dz%zwTg!PS" };

            IdentityResult identityResult = await _authService.RegisterAsync(defaultUser);

            var registeredUser = await _userManager.FindByEmailAsync(defaultUser.Email);

            if (identityResult.Succeeded)
            {
                identityResult = await AddUserToAdminRole(registeredUser.Id.ToString());
            }

            return identityResult;
        }
    }
}
