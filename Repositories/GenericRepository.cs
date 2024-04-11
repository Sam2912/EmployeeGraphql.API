namespace EmployeeGraphql.API.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using EmployeeGraphql.API.Models;
    using Microsoft.EntityFrameworkCore;

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _context;
        private readonly MyUserContext _myUserContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context, MyUserContext myUserContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _myUserContext = myUserContext;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedBy = _myUserContext?.User?.Identity?.Name;
            entity.CreatedDate = DateTime.Now;

            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var existingEntity = await _dbSet.FindAsync(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached; // Detach the existing entity

                entity.CreatedBy = existingEntity.CreatedBy;
                entity.CreatedDate = existingEntity.CreatedDate;
                entity.UpdatedBy = _myUserContext?.User?.Identity?.Name;
                entity.UpdatedDate = DateTime.Now;

                _dbSet.Update(entity); // Update the entity
                await _context.SaveChangesAsync(); // Save changes
                return entity;
            }
            else
            {
                throw new ArgumentException($"Entity with id {entity.Id} not found.");
            }
        }

        public async Task<TEntity> DeleteAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}