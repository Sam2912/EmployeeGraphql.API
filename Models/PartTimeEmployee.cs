namespace EmployeeGraphql.API.Models
{
    public class PartTimeEmployee : Employee
    {
        public override EmployeeTypeEnum Type { get; set; } = EmployeeTypeEnum.PartTime;
        public decimal HourlyRate { get; set; }
    }
}

