using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphql.API.Models;
using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class BaseEmployeeInput : InputObjectGraphType
    {
        public BaseEmployeeInput()
        {
            Field<IntGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<DepartmentEnumType>>("department");
            Field<NonNullGraphType<StatusEnumType>>("status");
            Field<NonNullGraphType<EmployeeEnumType>>("type");
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }
        public EmployeeTypeEnum Type { get; set; }

    }
}