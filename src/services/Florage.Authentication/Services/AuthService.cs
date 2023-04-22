using Florage.Authentication.Contracts;
using Florage.Authentication.Dtos;
using Florage.Authentication.Models;
using Florage.Authentication.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Florage.Authentication.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager; 
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager; 
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
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
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
            ApplicationUser user = new ApplicationUser(userRegisterDto.Email, userRegisterDto.Email);
     
            IdentityResult identityResult = await _userManager.CreateAsync(user, userRegisterDto.Password);
            return identityResult;
        }
        
        private JwtSecurityToken GetToken(List<Claim> authClaims)
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

        public bool ValidateToken(string token)
        {
            if (token == null)
                return false;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidIssuer = _configuration["Jwt:ValidIssuer"],
                    ValidateAudience = false,
                    ValidAudience = _configuration["Jwt:ValidAudience"], 
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken); 
                
                return true;
            }
            catch
            { 
                return false;
            }
        }
    }
}
