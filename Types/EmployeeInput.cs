using EmployeeGraphql.API.Models;
using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class EmployeeInput : InputObjectGraphType<EmployeeInputDto>
    {
        public EmployeeInput()
        {
            Name = "EmployeeInput";
            Field<IntGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<DepartmentEnumType>>("department");
            Field<NonNullGraphType<StatusEnumType>>("status");
            Field<FloatGraphType>("salary");
            Field<FloatGraphType>("hourlyRate");
            Field<NonNullGraphType<EmployeeEnumType>>("type");
        }

        
    }
}