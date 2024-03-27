using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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