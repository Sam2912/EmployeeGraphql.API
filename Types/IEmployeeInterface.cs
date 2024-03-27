using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphql.API.Models;
using GraphQL.Types;

namespace EmployeeGraphql.API.Types
{
    public class IEmployeeInterface : InterfaceGraphType<IEmployee>
    {
        public IEmployeeInterface()
        {
            Name = "IEmployee";
            Field(e => e.Id);
            Field(e => e.Name);
            Field(e => e.Department, type: typeof(DepartmentEnumType));
            Field<StatusEnumType>("status");
        }
    }
}