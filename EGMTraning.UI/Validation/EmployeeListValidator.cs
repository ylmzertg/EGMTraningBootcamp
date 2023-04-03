using EGMTraning.UI.Models;
using FluentValidation;

namespace EGMTraning.UI.Validation
{
    public class EmployeeListValidator :AbstractValidator<EmployeeList>
    {
        public EmployeeListValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Please not null and empty employee Name");

            RuleFor(x => x.Surname).NotEmpty().NotNull().WithMessage("Please not null and empty employee Surname");

            RuleFor(x => x.EmployeeEmail).EmailAddress().NotNull().WithMessage("Please fill email fieldss");
        }
    }
}
