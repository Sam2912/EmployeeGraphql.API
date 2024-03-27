namespace EmployeeGraphql.API.Models
{
    public interface IEmployee
    {
        int Id { get; set; }
        string? Name { get; set; }
        Department Department { get; set; }
        Status Status { get; set; }
    }
}