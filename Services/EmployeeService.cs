using System.Linq.Expressions;
using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Repositories;

namespace EmployeeGraphql.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<IEmployee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<IEmployee> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IEmployee>> GetAsync(Expression<Func<Employee, bool>> predicate)
        {
            return await _employeeRepository.GetAsync(predicate);
        }

        public async Task<IEmployee> AddEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.AddAsync(employee);
        }

        public async Task<IEmployee> UpdateEmployeeAsync(Employee employee)
        {
           return await _employeeRepository.UpdateAsync(employee);
        }

        public async Task<IEmployee> DeleteEmployeeAsync(Guid id)
        {
           return await _employeeRepository.DeleteAsync(id);
        }
    }
}