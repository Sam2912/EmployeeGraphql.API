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

    public enum EmployeeTypeEnum
    {
        FullTime,
        PartTime
    }

    public abstract class Employee : IEmployee
    {

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }
        public abstract EmployeeTypeEnum Type { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}