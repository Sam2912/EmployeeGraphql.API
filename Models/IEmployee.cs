namespace EmployeeGraphql.API.Models
{
    public interface IEmployee
    {
        Guid Id { get; set; }
        string? Name { get; set; }
        Department Department { get; set; }
        Status Status { get; set; }
    }
}