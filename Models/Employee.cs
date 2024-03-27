using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeGraphql.API.Models
{

    public enum Department
    {
        IT,
        HR,
        Sales,
        Marketing,
        Operations
    }

    public enum Status
    {
        Active,
        Inactive
    }

    public abstract class Employee : IEmployee
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }
    }
}