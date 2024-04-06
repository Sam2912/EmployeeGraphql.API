using EmployeeGraphql.API.DbContext;
using EmployeeGraphql.API.Models;
using Microsoft.AspNetCore.Identity;

namespace EmployeeGraphql.API.Authorization
{
    public interface IAuthService
    {
        Task<string> GenerateJwtToken(string username, string password);
        Task<IdentityResult> CreateRole(string roleName);
        Task<ApplicationUser> CreateUser(CreateUserDto input);
        Task<IdentityResult> AssignRolesToUser(string userId, IList<string> roles);
    }
}