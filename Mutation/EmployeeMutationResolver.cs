using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Types;
using EmployeeGraphql.API.Types.Input;

namespace EmployeeGraphql.API.Mutation
{
    public class EmployeeMutationResolver : IEmployeeMutationResolver
    {
        public async Task<IEmployee> CreateEmployeeAsync(EmployeeInput create)
        {
            return await Task.FromResult(new FullTimeEmployee());
        }
    }
}