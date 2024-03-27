namespace EmployeeGraphql.API.Models
{
    public class FullTimeEmployee : Employee
    {
        public EmployeeTypeEnum Type { get; set; } = EmployeeTypeEnum.FullTime;
        public decimal Salary { get; set; }
    }

}

