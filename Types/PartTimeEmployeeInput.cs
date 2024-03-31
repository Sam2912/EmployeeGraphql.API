using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class PartTimeEmployeeInput : BaseEmployeeInput
    {
        public PartTimeEmployeeInput()
        {
            Field<FloatGraphType>("hourlyRate");
        }
        public decimal HourlyRate { get; set; }
    }
}