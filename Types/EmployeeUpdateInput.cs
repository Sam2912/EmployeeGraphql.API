using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class EmployeeUpdateInput : InputObjectGraphType, IEmployeeInput
    {
        public EmployeeUpdateInput()
        {
            Name = "EmployeeUpdateInput";
            Field<FullTimeEmployeeInput>("fullTimeEmployeeInput");
            Field<PartTimeEmployeeInput>("partTimeEmployeeInput");

        }

        public FullTimeEmployeeInput FullTimeEmployeeInput { get; set; }
        public PartTimeEmployeeInput PartTimeEmployeeInput { get; set; }
    }
}