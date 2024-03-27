using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Services
{
    public interface IEmployeeService
    {
        IEmployee? GetEmployeeById(int id);
        IEnumerable<IEmployee> GetEmployeeByDeptStatus(Department dept, Status status);
        IEnumerable<IEmployee> GetEmployees();
        IEmployee AddEmployee(IEmployee employee);
    }
}