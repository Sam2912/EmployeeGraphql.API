using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Types;
using EmployeeGraphql.API.Types.Input;
using HotChocolate.Resolvers;

namespace EmployeeGraphql.API.Mutation
{
    public interface IEmployeeMutationResolver
    {
        Task<IEmployee> CreateEmployeeAsync(EmployeeInput create,IResolverContext resolverContext);
    }
}