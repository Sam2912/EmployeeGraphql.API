using System.Linq.Expressions;
using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Repositories
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity :class, IEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(object id);
        Task<int> SaveAsync();
    }
}