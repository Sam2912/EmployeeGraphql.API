using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class FullTimeEmployeeInput : BaseEmployeeInput
    {
        public FullTimeEmployeeInput()
        {
            Field<FloatGraphType>("salary");
        }
        public decimal Salary { get; set; }
    }
}