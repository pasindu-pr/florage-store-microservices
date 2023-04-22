using Florage.Authentication.Contracts;
using Florage.Authentication.Dtos;
using Florage.Authentication.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Florage.Authentication.Controllers
{
    [Route("api/auth")]
    [ApiController]    
    public class AuthController : ControllerBase
    {


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = ("admin"))]

        private readonly IAuthService _userService;

        public AuthController(IAuthService userService)
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

        [HttpPost]
        [Route("verify")]
        public IActionResult VerifyToken(string token)
        {
            bool tokenValidationResult = _userService.ValidateToken(token);

            if (tokenValidationResult)
            {
                return Ok();
            }

            return Unauthorized();
        }
    }
}
