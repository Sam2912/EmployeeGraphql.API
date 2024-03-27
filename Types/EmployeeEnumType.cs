using EmployeeGraphql.API.Models;
using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class EmployeeEnumType : EnumerationGraphType<EmployeeTypeEnum>
    {
        public EmployeeEnumType()
        {
            Name = "Type";
        }
    }
}