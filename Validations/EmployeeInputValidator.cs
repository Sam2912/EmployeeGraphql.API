using EmployeeGraphql.API.Types;
using FluentValidation;

namespace EmployeeGraphql.API.Validations
{
    public class EmployeeInputValidator : AbstractValidator<EmployeeInput>
    {
        public EmployeeInputValidator()
        {
            RuleFor(emp => emp.FullTimeEmployeeInput)
            .SetValidator(new EmployeeFullTimeInputValidator())
            .When(x => x.FullTimeEmployeeInput != null);

            RuleFor(emp => emp.PartTimeEmployeeInput)
            .SetValidator(new EmployeePartTimeInputValidator())
            .When(x => x.PartTimeEmployeeInput != null);
        }
    }
}