using Florage.Authentication.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Florage.Authentication.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("add-admin")]
        public async Task<ActionResult<IdentityResult>> AddRole()
        {
            IdentityResult identityResult = await _userService.AddAdminRole();

            if(identityResult != null && identityResult.Succeeded)
            {
                return Ok(identityResult);
            }

            return BadRequest(identityResult);
        }

        [Authorize]
        [HttpPost]
        [Route("assign-admin")]
        public async Task<ActionResult<IdentityResult>> AssignAdminRoleToUser(string userId)
        {
            IdentityResult identityResult = await _userService.AddUserToAdminRole(userId);

            if (identityResult.Succeeded)
            {
                return Ok(identityResult);
            }

            return BadRequest(identityResult);
        }
    }
}
