using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Types.Input
{
    public class FullTimeEmployeeInput : BaseEmployeeInput
    {
        public override Employee Type { get; set; } = Employee.FullTime;
        public decimal Salary { get; set; }
    }
}