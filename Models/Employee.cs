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

        public int Id { get; set; }
        public string? Name { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }
    }
}