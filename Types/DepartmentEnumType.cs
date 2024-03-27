using EmployeeGraphql.API.Models;
using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class DepartmentEnumType : EnumerationGraphType<Department>
    {
        public DepartmentEnumType()
        {
            Name = "Department";
        }
    }
}