using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Services;
using EmployeeGraphql.API.Types;
using EmployeeGraphql.API.Types.Input;
using FluentValidation;
using FluentValidation.Results;
using HotChocolate.AspNetCore;
using HotChocolate.Resolvers;

namespace EmployeeGraphql.API.Mutation
{
    public class EmployeeMutationResolver : IEmployeeMutationResolver
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly IValidator<EmployeeInput> _validator;

        public EmployeeMutationResolver(IEmployeeService employeeService, IMapper mapper,
        IValidator<EmployeeInput> validator )
        {
            _validator = validator;
            _employeeService = employeeService;
            _mapper = mapper;
        }
        public async Task<IEmployee> CreateEmployeeAsync(EmployeeInput create,IResolverContext resolverContext)
        {

            ValidationResult validationResult = await _validator.ValidateAsync(create);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    resolverContext.ReportError(error.ErrorMessage);
                }
                return await Task.FromResult<IEmployee>(null);
            }

            BaseEmployee employee = GetEmployee(create);

            return await _employeeService.AddEmployeeAsync(employee);
        }

        private BaseEmployee GetEmployee<T>(T input)
       where T : IEmployeeInput
        {
            BaseEmployee employee = null;
            if (input.FullTimeEmployeeInput is not null)
            {
                employee = _mapper.Map<FullTimeEmployee>(input.FullTimeEmployeeInput);
            }
            else if (input.PartTimeEmployeeInput is not null)
            {
                employee = _mapper.Map<PartTimeEmployee>(input.PartTimeEmployeeInput);
            }

            return employee;
        }
    }
}