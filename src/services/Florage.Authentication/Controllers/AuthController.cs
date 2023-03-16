using Florage.Authentication.Contracts;
using Florage.Authentication.Dtos;
using Florage.Authentication.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Florage.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        } 

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<IdentityResult>> CreateUser(UserRegisterDto user)
        {
            IdentityResult identityResult = await _userService.RegisterAsync(user);
            
            if (identityResult.Succeeded)
            {
                return Ok(identityResult);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserTokenResponse>> Login(UserLoginDto user)
        {
            UserTokenResponse tokenResponse = await _userService.LoginAsync(user);

            if (tokenResponse.Success)
            {
                return Ok(tokenResponse);
            }

            return BadRequest(tokenResponse);
        }
    }
}
