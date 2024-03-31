using EmployeeGraphql.API.Models;
using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class BaseEmployeeInput : InputObjectGraphType
    {
        public BaseEmployeeInput()
        {
            Field<GuidGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<DepartmentEnumType>>("department");
            Field<NonNullGraphType<StatusEnumType>>("status");
            Field<NonNullGraphType<EmployeeEnumType>>("type");
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }
        public EmployeeTypeEnum Type { get; set; }

    }
}