using EmployeeGraphql.API.DbContext;
using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Authorization
{
    public interface IAuthService
    {
        Task<string> GenerateJwtToken(string username, string password);
        Task<ApplicationUser> CreateUser(CreateUserDto input);
    }
}