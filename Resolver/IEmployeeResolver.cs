using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphql.API.Models;
using GraphQL;

namespace EmployeeGraphql.API.Resolver
{
    public interface IEmployeeResolver
    {
        Task<IEmployee?> CreateEmployeeAsync(IResolveFieldContext<object> context);
        IEmployee? UpdateEmployee(IResolveFieldContext<object> context);
        IEmployee? DeleteEmployee(IResolveFieldContext<object> context);
    }
}