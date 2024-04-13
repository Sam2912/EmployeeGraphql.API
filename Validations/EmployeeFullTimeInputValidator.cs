using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphql.API.Types.Input;
using FluentValidation;

namespace EmployeeGraphql.API.Validations
{
 public class EmployeeFullTimeInputValidator : AbstractValidator<FullTimeEmployeeInput>
    {
        public EmployeeFullTimeInputValidator()
        {
            RuleFor(emp => emp.Name).NotEmpty().WithMessage("Name is required.");
        }
    }
}