using AutoMapper;
using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Services;
using EmployeeGraphql.API.Types;
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

        public async Task<IEmployee> CreateEmployeeAsync(IResolveFieldContext<object> context)
        {
            var input = context.GetArgument<EmployeeInput>("create");
            Employee employee = GetEmployee(input);


            ValidationResult validationResult = await this.validator.ValidateAsync(input);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    context.Errors.Add(new ExecutionError(error.ErrorMessage));

                }
                return await Task.FromResult<IEmployee>(null);
            }

            return await employeeService.AddEmployeeAsync(employee);
        }

        public async Task<IEmployee> UpdateEmployeeAsync(IResolveFieldContext<object> context)
        {
            var input = context.GetArgument<EmployeeUpdateInput>("update");
            Employee employee = GetEmployee(input);

            return await employeeService.UpdateEmployeeAsync(employee);
        }

        public async Task<IEmployee> DeleteEmployeeAsync(IResolveFieldContext<object> context)
        {
            var delete = context.GetArgument<EmployeeDeleteInput>("delete");
            return await employeeService.DeleteEmployeeAsync(delete.EmployeeId);
        }
        private Employee GetEmployee<T>(T input)
        where T : IEmployeeInput
        {
            Employee employee = null;
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
    }
}