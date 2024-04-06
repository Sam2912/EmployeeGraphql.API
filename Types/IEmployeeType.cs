using EmployeeGraphql.API.Models;
using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class IEmployeeType : InterfaceGraphType<IEmployee>
    {
        public IEmployeeType()
        {
            Name = "IEmployee";
            Field(e => e.Id);
            Field(e => e.Name);
            Field(e => e.Department, type: typeof(DepartmentEnumType));
            //Field(e=>e.Type);
            Field<StatusEnumType>("status");
        }
    }
}