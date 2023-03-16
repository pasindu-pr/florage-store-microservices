using AspNetCore.Identity.Mongo.Model;
using Florage.Authentication.Contracts;
using Florage.Authentication.Dtos;
using Florage.Authentication.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Florage.Authentication.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<MongoUser> _userManager;
        private readonly SignInManager<MongoUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<MongoUser> userManager, SignInManager<MongoUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<UserTokenResponse> LoginAsync(UserLoginDto userLoginDto)
        {
            UserTokenResponse userToken;
                
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email); 
            
            if (user != null && await _userManager.CheckPasswordAsync(user, userLoginDto.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                } 

                String tokenReponse = new JwtSecurityTokenHandler().WriteToken(GetToken(authClaims));
                return userToken = new UserTokenResponse { Token = tokenReponse, Success = true };
            }

            userToken = new UserTokenResponse { Token = null, Success = false, Message = "Email or password is incorrect." };
            
            return userToken;
        }

        public async Task<IdentityResult> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            MongoUser user = new MongoUser(userRegisterDto.Email);
            user.Email = userRegisterDto.Email;
            IdentityResult identityResult = await _userManager.CreateAsync(user, userRegisterDto.Password);
            return identityResult;
        }

        public JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
