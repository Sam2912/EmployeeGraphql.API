using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees;

        public EmployeeService()
        {
            // Initialize employees (FullTimeEmployee and PartTimeEmployee instances)
            _employees = new List<Employee>();
            _employees.Add(new FullTimeEmployee
            {
                Id = 1,
                Name = "Laxman",
                Salary = 5000m,
                Department = Department.IT,
                Status = Status.Active
            });

            _employees.Add(new PartTimeEmployee
            {
                Id = 2,
                Name = "Jiya",
                HourlyRate = 1000m,
                Department = Department.HR,
                Status = Status.Active


            });

            _employees.Add(new FullTimeEmployee
            {
                Id = 3,
                Name = "Pahal",
                Salary = 2000m,
                Department = Department.IT,
                Status = Status.Inactive


            });
        }

        public IEnumerable<Employee> GetEmployeeByDeptStatus(Department dept, Status status)
        {
            return _employees.Where(x => x.Department == dept && x.Status == status);
        }

        public Employee? GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }
    }

}