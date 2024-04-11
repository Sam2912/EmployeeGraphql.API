namespace EmployeeGraphql.API.Models
{

    public enum Department
    {
        IT,
        HR,
        Sales,
        Marketing,
        Operations
    }

    public enum Status
    {
        Active,
        Inactive
    }

    public enum Employee
    {
        FullTime,
        PartTime
    }

    public abstract class BaseEmployee : IEmployee
    {

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }
        public abstract Employee Type { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}