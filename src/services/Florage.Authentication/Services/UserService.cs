using Florage.Authentication.Contracts;
using Florage.Authentication.Models;
using Microsoft.AspNetCore.Identity;

namespace Florage.Authentication.Services
{
    public class UserService: IUserService
    {
        private RoleManager<ApplicationRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;

        public UserService(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddAdminRole()
        {

            ApplicationRole isRoleExists = await _roleManager.FindByNameAsync("Admin");
            
            if (isRoleExists == null)
            {

                ApplicationRole applicationRole = new ApplicationRole();
                applicationRole.Name = "admin";


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
    }
}
