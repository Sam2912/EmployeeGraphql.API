using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Query
{
    public interface IEmployeeQueryResolver
    {
        Task<IEnumerable<IEmployee>> GetAllEmployeesAsync();
        Task<IEmployee> GetEmployeeByIdAsync(Guid id);
        Task<IEnumerable<IEmployee>> GetAsync(Department dept, Status status);
        Task<AuthPayloadDto> GenerateJwtTokenAsync(string username, string password);
    }
}