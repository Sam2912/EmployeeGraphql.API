using EmployeeGraphql.API.Models;
using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class EmployeeUpdateInput : InputObjectGraphType<EmployeeUpdateDto>
    {
        public EmployeeUpdateInput()
        {
            Name = "EmployeeUpdateInput";
            Field<NonNullGraphType<IntGraphType>>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<DepartmentEnumType>>("department");
            Field<NonNullGraphType<StatusEnumType>>("status");
            Field<FloatGraphType>("salary");
            Field<FloatGraphType>("hourlyRate");
            Field<NonNullGraphType<EmployeeEnumType>>("type");
        }


    }
}