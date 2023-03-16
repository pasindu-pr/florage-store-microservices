using Florage.Authentication.Dtos;
using Florage.Authentication.Responses;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Florage.Authentication.Contracts
{
    public interface IUserService
    {
        public Task<IdentityResult> RegisterAsync(UserRegisterDto userRegisterDto);
        public Task<UserTokenResponse> LoginAsync(UserLoginDto userLoginDto);
    }
}
