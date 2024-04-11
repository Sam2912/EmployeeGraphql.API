namespace EmployeeGraphql.API.Models
{
    public class AuthPayloadDto
    {
        public string? Token { get; set; }
        public bool Success { get; set; }
        public List<string>? Errors { get; set; }
    }
}