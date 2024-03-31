using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeGraphql.API.DbContext;
using EmployeeGraphql.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeGraphql.API.Authorization
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthService(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            _signInManager = serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
            _configuration = configuration;
        }

        public async Task<string> GenerateJwtToken(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null && await _signInManager.CheckPasswordSignInAsync(user, password, false) == SignInResult.Success)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "admin")
                }),
                    Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return null; // Invalid credentials
        }

        public async Task<ApplicationUser> CreateUser(CreateUserDto input)
        {
            var user = new ApplicationUser
            {
                UserName = input.UserName,
                Email = input.Email,
                // Set other user properties as needed
            };

            var result = await _userManager.CreateAsync(user, input.Password);

            if (result.Succeeded)
            {
                return user;
            }

            throw new Exception("Failed to create user.");
        }
    }
}