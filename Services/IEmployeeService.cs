using System.Linq.Expressions;
using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<IEmployee>> GetAllEmployeesAsync();
        Task<IEmployee> GetEmployeeByIdAsync(Guid id);
        Task<IEnumerable<IEmployee>> GetAsync(Expression<Func<Employee, bool>> predicate);
        Task<IEmployee> AddEmployeeAsync(Employee employee);
        Task<IEmployee> UpdateEmployeeAsync(Employee employee);
        Task<IEmployee> DeleteEmployeeAsync(Guid id);

    }
}