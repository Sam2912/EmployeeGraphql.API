using EmployeeGraphql.API.Models;
using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class FullTimeEmployeeType : ObjectGraphType<FullTimeEmployee>
    {
        public FullTimeEmployeeType()
        {
            Field(e => e.Id);
            Field(e => e.Name);
            Field(e => e.Salary);
            Field(e => e.Department, type: typeof(DepartmentEnumType));
            Field<StatusEnumType>("status")
            .Resolve( context => context.Source.Status);
            Interface<EmployeeType>();
        }
    }

}

