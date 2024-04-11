using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EmployeeGraphql.API.Authorization;
using EmployeeGraphql.API.Constants;
using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Services;
using HotChocolate.Authorization;
using Newtonsoft.Json.Linq;

namespace EmployeeGraphql.API.Query
{
    public class EmployeeQueryResolver : IEmployeeQueryResolver
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAuthService _authService;

        public EmployeeQueryResolver(IEmployeeService employeeService, IAuthService authService)
        {
            _employeeService = employeeService;
            _authService = authService;
        }

        public async Task<IEnumerable<IEmployee>> GetAllEmployeesAsync()
        {
            return await _employeeService.GetAllEmployeesAsync();
        }

        public async Task<IEmployee> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeeService.GetEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<IEmployee>> GetAsync(Department dept, Status status)
        {
            Expression<Func<BaseEmployee, bool>> predicate = emp => emp.Department == dept && emp.Status == status;
            return await _employeeService.GetAsync(predicate);
        }

        public async Task<AuthPayloadDto> GenerateJwtTokenAsync(string username, string password)
        {
            var token = await _authService.GenerateJwtToken(username, password);
            if (token != null)
            {
                return new AuthPayloadDto
                {
                    Token = token,
                    Success = true,
                    Errors = null
                };
            }
            else
            {
                return new AuthPayloadDto
                {
                    Token = null,
                    Success = false,
                    Errors = new List<string> { "Invalid username or password" }
                };
            }
            // // Return null or throw an exception for invalid credentials
            // throw new AuthenticationException("Invalid credentials");
        }

    }
}