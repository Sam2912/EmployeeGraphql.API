using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Services
{
    public interface IEmployeeService
    {
        Employee? GetEmployeeById(int id);
        IEnumerable<Employee> GetEmployeeByDeptStatus(Department dept, Status status);
        IEnumerable<Employee> GetEmployees();
    }
}