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

        public IEmployee AddEmployee(IEmployee employee)
        {
            _employees.Add(employee);
            return employee;
        }

        public IEmployee UpdateEmployee(IEmployee employee)
        {
            _employees.Remove(employee);
            return AddEmployee(employee);
        }

        public IEnumerable<IEmployee> GetEmployeeByDeptStatus(Department dept, Status status)
        {
            return _employees.Where(x => x.Department == dept && x.Status == status);
        }

        public IEmployee? GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<IEmployee> GetEmployees()
        {
            return _employees;
        }


    }

}