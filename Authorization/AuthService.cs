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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            _signInManager = serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
            _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            _configuration = configuration;
        }

        public async Task<string> GenerateJwtToken(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null && await _signInManager.CheckPasswordSignInAsync(user, password, false) == SignInResult.Success)
            {
                var roles = await _userManager.GetRolesAsync(user); // Get user roles
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role)); // Add roles to claims
                }

                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return null; // Invalid credentials
        }

        public async Task<IdentityResult> CreateRole(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                var newRole = new IdentityRole(roleName);
                return await _roleManager.CreateAsync(newRole);
            }

            throw new Exception("Role already exists.");
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


        public async Task<IdentityResult> AssignRolesToUser(string userId, IList<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var result = await _userManager.AddToRolesAsync(user, roles);
            return result;
        }

    }
}