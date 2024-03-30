using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private List<IEmployee> _employees;

        public EmployeeService()
        {
            // Initialize employees (FullTimeEmployee and PartTimeEmployee instances)
            _employees = new List<IEmployee>();
            _employees.Add(new FullTimeEmployee
            {
                Id = Guid.Parse("2bcd868d-27e8-4c03-afa8-9fffd2f4b295"),
                Name = "Laxman",
                Salary = 5000m,
                Department = Department.IT,
                Status = Status.Active
            });

            _employees.Add(new PartTimeEmployee
            {
                Id = Guid.Parse("35d5b785-7d5b-43b6-9302-971a44dc588e"),
                Name = "Jiya",
                HourlyRate = 1000m,
                Department = Department.HR,
                Status = Status.Active


            });

            _employees.Add(new FullTimeEmployee
            {
                Id = Guid.Parse("7cfa39d8-16e4-485c-96c0-48ef1e6b083c"),
                Name = "Pahal",
                Salary = 2000m,
                Department = Department.IT,
                Status = Status.Inactive


            });
        }

        public IEnumerable<IEmployee> GetEmployeeByDeptStatus(Department dept, Status status)
        {
            return _employees.Where(x => x.Department == dept && x.Status == status);
        }

        public IEmployee? GetEmployeeById(Guid id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<IEmployee> GetEmployees()
        {
            return _employees;
        }

        public IEmployee AddEmployee(IEmployee employee)
        {
            _employees.Add(employee);
            return employee;
        }

        public IEmployee UpdateEmployee(IEmployee employee)
        {
            DeleteEmployee(employee.Id);
            return AddEmployee(employee);
        }

        public IEmployee? DeleteEmployee(Guid employeeId)
        {
            IEmployee? employee = _employees.FirstOrDefault(x => x.Id == employeeId);
            if (employee is not null)
            {
                _employees.Remove(employee);
                return employee;
            }
            return null;
        }
    }

}