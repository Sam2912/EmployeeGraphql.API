using EmployeeGraphql.API.Models;
using GraphQL;

namespace EmployeeGraphql.API.Resolver
{
    public interface IEmployeeResolver
    {
        Task<IEmployee> CreateEmployeeAsync(IResolveFieldContext<object> context);
        Task<IEmployee> UpdateEmployee(IResolveFieldContext<object> context);
        Task<IEmployee> DeleteEmployee(IResolveFieldContext<object> context);
    }
}