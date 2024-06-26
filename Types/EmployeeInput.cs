using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class EmployeeInput : InputObjectGraphType, IEmployeeInput
    {
        public EmployeeInput()
        {
            Name = "EmployeeInput";
            Field<FullTimeEmployeeInput>("fullTimeEmployeeInput");
            Field<PartTimeEmployeeInput>("partTimeEmployeeInput");
        }

        public PartTimeEmployeeInput PartTimeEmployeeInput { get; set; }
        public FullTimeEmployeeInput FullTimeEmployeeInput { get; set; }
    }
}