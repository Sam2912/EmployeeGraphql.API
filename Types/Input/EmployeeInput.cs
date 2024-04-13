using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Types.Input
{
    public class EmployeeInput : IEmployeeInput
    {
        public PartTimeEmployeeInput? PartTimeEmployeeInput { get; set; }
        public FullTimeEmployeeInput? FullTimeEmployeeInput { get; set; }
    }
}