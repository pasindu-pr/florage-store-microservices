using Florage.Authentication.Dtos;
using Florage.Authentication.Responses;
using Microsoft.AspNetCore.Identity;

namespace Florage.Authentication.Contracts
{
    public interface IUserService
    {
        public Task<IdentityResult> RegisterAsync(UserRegisterDto userRegisterDto);
        public Task<UserTokenResponse> LoginAsync(UserLoginDto userLoginDto);
        public bool ValidateToken(string token);
    }
}
