namespace EmployeeGraphql.API.Models
{
    public class PartTimeEmployee : Employee
    {
        public EmployeeTypeEnum Type { get; set; } = EmployeeTypeEnum.PartTime;
        public decimal HourlyRate { get; set; }
    }

}

