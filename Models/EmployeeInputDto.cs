using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeGraphql.API.Models
{
    public class EmployeeInputDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }
        public EmployeeTypeEnum Type { get; set; }

        public decimal? Salary { get; set; }
        public decimal? HourlyRate { get; set; }
    }
}