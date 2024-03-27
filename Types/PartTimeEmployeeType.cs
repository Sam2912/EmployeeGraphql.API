using EmployeeGraphql.API.Models;
using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class PartTimeEmployeeType : ObjectGraphType<PartTimeEmployee>
    {
        public PartTimeEmployeeType()
        {
            Field(e => e.Id);
            Field(e => e.Name);
            Field(e => e.HourlyRate);
            Field(e => e.Department, type: typeof(DepartmentEnumType));
            Field<StatusEnumType>("status")
            .Resolve( context => context.Source.Status);
            Interface<EmployeeType>();
        }
    }

}

