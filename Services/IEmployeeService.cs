using System.Linq.Expressions;
using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<IEmployee>> GetAllEmployeesAsync();
        Task<IEmployee> GetEmployeeByIdAsync(Guid id);
        Task<IEnumerable<IEmployee>> GetAsync(Expression<Func<BaseEmployee, bool>> predicate);
        Task<IEmployee> AddEmployeeAsync(BaseEmployee employee);
        Task<IEmployee> UpdateEmployeeAsync(BaseEmployee employee);
        Task<IEmployee> DeleteEmployeeAsync(Guid id);

    }
}