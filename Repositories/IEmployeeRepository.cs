using System.Linq.Expressions;
using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<BaseEmployee>
    {
        Task<IEnumerable<BaseEmployee>> GetAllAsync();
        Task<IEnumerable<BaseEmployee>> GetAsync(Expression<Func<BaseEmployee, bool>> predicate);
        Task<BaseEmployee> GetByIdAsync(Guid id);
        Task<BaseEmployee> AddAsync(BaseEmployee employee);
        Task<BaseEmployee> UpdateAsync(BaseEmployee employee);
        Task<BaseEmployee> DeleteAsync(Guid id);

    }
}