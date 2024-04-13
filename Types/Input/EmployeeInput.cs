using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Types.Input
{
    public class EmployeeInput
    {
        public PartTimeEmployeeInput PartTimeEmployeeType { get; set; }
        public FullTimeEmployeeInput FullTimeEmployeeType { get; set; }
    }
}