using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeGraphql.API.Types.Input
{
    public interface IEmployeeInput
    {
        public PartTimeEmployeeInput? PartTimeEmployeeInput { get; set; }
        public FullTimeEmployeeInput? FullTimeEmployeeInput { get; set; }
    }
}