using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Services;
using EmployeeGraphql.API.Types;
using EmployeeGraphql.API.Validations;
using FluentValidation;
using FluentValidation.Results;
using GraphQL;

namespace EmployeeGraphql.API.Resolver
{
    public class EmployeeResolver : IEmployeeResolver
    {
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;
        private readonly IValidator<EmployeeInput> validator;

        public EmployeeResolver(IEmployeeService employeeService, IMapper mapper,IValidator<EmployeeInput> validator)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<IEmployee?> CreateEmployeeAsync(IResolveFieldContext<object> context)
        {
            var input = context.GetArgument<EmployeeInput>("create");
            IEmployee employee = GetEmployee(input);


            ValidationResult validationResult = await this.validator.ValidateAsync(input);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    context.Errors.Add(new ExecutionError(error.ErrorMessage));

                }
                return await Task.FromResult<IEmployee>(null);
            }

            return employeeService.AddEmployee(employee);
        }

        private IEmployee GetEmployee<T>(T input)
        where T : IEmployeeInput
        {
            IEmployee employee = null;
            if (input.FullTimeEmployeeInput is not null)
            {
                employee = mapper.Map<FullTimeEmployee>(input.FullTimeEmployeeInput);
            }
            else if (input.PartTimeEmployeeInput is not null)
            {
                employee = mapper.Map<PartTimeEmployee>(input.PartTimeEmployeeInput);
            }

            return employee;
        }

        public IEmployee? UpdateEmployee(IResolveFieldContext<object> context)
        {
            var input = context.GetArgument<EmployeeUpdateInput>("update");
            IEmployee employee = GetEmployee(input);

            return employeeService.UpdateEmployee(employee);
        }

        public IEmployee? DeleteEmployee(IResolveFieldContext<object> context)
        {
            var delete = context.GetArgument<EmployeeDeleteInput>("delete");
            return employeeService.DeleteEmployee(delete.EmployeeId);
        }

    }
}