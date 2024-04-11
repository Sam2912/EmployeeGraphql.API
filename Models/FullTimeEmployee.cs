namespace EmployeeGraphql.API.Models
{
    public class FullTimeEmployee : BaseEmployee
    {
        public override Employee Type { get; set; } = Employee.FullTime;
        
        public decimal Salary { get; set; }
    }

}

