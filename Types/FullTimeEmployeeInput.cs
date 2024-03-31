using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class FullTimeEmployeeInput : BaseEmployeeInput
    {
        public FullTimeEmployeeInput()
        {
            Field<FloatGraphType>("salary");
        }
        public decimal Salary { get; set; }
    }
}