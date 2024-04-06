using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EmployeeGraphql.API.DbContext;
using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        public async Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>> predicate)
        {
            return await base.GetAsync(predicate);
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await base.GetByIdAsync(id);
        }


        public async Task<Employee> AddAsync(Employee employee)
        {
            return await base.AddAsync(employee);
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            return await base.UpdateAsync(employee);
        }

        public async Task<Employee> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
        }


    }
}