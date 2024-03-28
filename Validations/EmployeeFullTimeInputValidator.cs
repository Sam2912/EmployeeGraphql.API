using EmployeeGraphql.API.Types;
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