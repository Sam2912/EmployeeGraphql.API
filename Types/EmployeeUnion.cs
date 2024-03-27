using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class EmployeeUnion : UnionGraphType
    {
        public EmployeeUnion()
        {
            Name = "Employee";
            Type<FullTimeEmployeeType>();
            Type<PartTimeEmployeeType>();
        }
    }
}

