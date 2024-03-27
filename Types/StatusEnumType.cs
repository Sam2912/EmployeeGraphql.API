using EmployeeGraphql.API.Models;
using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class StatusEnumType : EnumerationGraphType<Status>
{
    public StatusEnumType()
    {
        Name = "Status";
        Description = "Employee status";
    }
}
}