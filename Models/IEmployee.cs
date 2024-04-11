namespace EmployeeGraphql.API.Models
{
    public interface IEmployee : IEntity
    {
        string? Name { get; set; }
        Department Department { get; set; }
        Status Status { get; set; }
        Employee Type { get; set; }
    }
}