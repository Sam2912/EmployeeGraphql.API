using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeGraphql.API.Types.Input
{
    public interface IEmployeeInput
    {
        public PartTimeEmployeeInputType PartTimeEmployeeInput { get; set; }
        public FullTimeEmployeeInputType FullTimeEmployeeInput { get; set; }
    }
}