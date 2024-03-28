using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class EmployeeDeleteInput: InputObjectGraphType
    {
        public EmployeeDeleteInput()
        {
            Field<IntGraphType>("employeeId");
        }
        public int EmployeeId { get; set; }
    }
}