using Florage.Authentication.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Florage.Authentication.Controllers
{
    [Route("api/auth/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        } 
         
        [HttpPost]
        [Route("assign-admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<IdentityResult>> AssignAdminRoleToUser(string userId)
        {
            IdentityResult identityResult = await _userService.AddUserToAdminRole(userId);

            if (identityResult.Succeeded)
            {
                return Ok(identityResult);
            }

            return BadRequest(identityResult);
        }
         
        [HttpPost]
        [Route("assign-seller")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<IdentityResult>> AssignSellerRoleToUser(string userId)
        {
            IdentityResult identityResult = await _userService.AddUserToSellerRole(userId);

            if (identityResult.Succeeded)
            {
                return Ok(identityResult);
            }

            return BadRequest(identityResult);
        }
         
        [HttpPost]
        [Route("seed-users")]
        public async Task<ActionResult<IdentityResult>> SeedsRolesAndUsers()
        {
            IdentityResult identityResult = await _userService.SeedRolesAndUsers();

            if (identityResult.Succeeded)
            {
                return Ok(identityResult);
            }

            return BadRequest(identityResult);
        }
    }
}
