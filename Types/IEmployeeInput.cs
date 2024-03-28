namespace EmployeeGraphql.API.Types
{
    public interface IEmployeeInput
    {
        public PartTimeEmployeeInput PartTimeEmployeeInput { get; set; }
        public FullTimeEmployeeInput FullTimeEmployeeInput { get; set; }
    }
}