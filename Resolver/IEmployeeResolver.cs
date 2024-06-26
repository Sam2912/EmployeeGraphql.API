using EmployeeGraphql.API.Models;
using GraphQL;

namespace EmployeeGraphql.API.Resolver
{
    public interface IEmployeeResolver
    {
        Task<IEmployee> CreateEmployeeAsync(IResolveFieldContext<object> context);
        Task<IEmployee> UpdateEmployeeAsync(IResolveFieldContext<object> context);
        Task<IEmployee> DeleteEmployeeAsync(IResolveFieldContext<object> context);
    }
}