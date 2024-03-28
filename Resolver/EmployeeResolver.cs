using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Services;
using EmployeeGraphql.API.Types;
using GraphQL;

namespace EmployeeGraphql.API.Resolver
{
    public class EmployeeResolver : IEmployeeResolver
    {
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeeResolver(IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        public IEmployee CreateEmployee(IResolveFieldContext<object?> context)
        {
            var input = context.GetArgument<EmployeeInput>("create");
            IEmployee employee = null;
            if (input.FullTimeEmployeeInput is not null)
            {
                employee = mapper.Map<FullTimeEmployee>(input.FullTimeEmployeeInput);
            }
            else if (input.PartTimeEmployeeInput is not null)
            {
                employee = mapper.Map<PartTimeEmployee>(input.PartTimeEmployeeInput);
            }

            return employeeService.AddEmployee(employee);
        }
        public IEmployee UpdateEmployee(IResolveFieldContext<object> context)
        {
            var input = context.GetArgument<EmployeeUpdateInput>("update");
            IEmployee employee = null;
            if (input.FullTimeEmployeeInput is not null)
            {
                employee = mapper.Map<FullTimeEmployee>(input.FullTimeEmployeeInput);
            }
            else if (input.PartTimeEmployeeInput is not null)
            {
                employee = mapper.Map<PartTimeEmployee>(input.PartTimeEmployeeInput);
            }

            return employeeService.UpdateEmployee(employee);
        }

        public IEmployee? DeleteEmployee(IResolveFieldContext<object> context)
        {
            var delete = context.GetArgument<EmployeeDeleteInput>("delete");
            return employeeService.DeleteEmployee(delete.EmployeeId);
        }

    }
}