namespace EmployeeGraphql.API.Models
{
    public class EmployeeInputDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }
        public EmployeeTypeEnum Type { get; set; }

        public decimal? Salary { get; set; }
        public decimal? HourlyRate { get; set; }
    }
}