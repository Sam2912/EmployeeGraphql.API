namespace EmployeeGraphql.API.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string? UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}