namespace EmployeeGraphql.API.Models
{
    public class PartTimeEmployee : BaseEmployee
    {
        public override Employee Type { get; set; } = Employee.PartTime;
        public decimal HourlyRate { get; set; }
    }
}

