using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphql.API.Types.Input;
using FluentValidation;

namespace EmployeeGraphql.API.Validations
{
 public class EmployeePartTimeInputValidator : AbstractValidator<PartTimeEmployeeInput>
    {
        public EmployeePartTimeInputValidator()
        {
            RuleFor(emp => emp.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(emp => emp.HourlyRate)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Salary should be greater than 0");
        }
    }
}