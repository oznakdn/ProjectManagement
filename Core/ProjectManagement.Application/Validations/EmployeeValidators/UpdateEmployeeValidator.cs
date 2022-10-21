using FluentValidation;
using ProjectManagement.Application.Features.Employee.Commands.UpdateEmployee;

namespace ProjectManagement.Application.Validations.EmployeeValidators
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommandRequest>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(e => e.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().NotEmpty().WithMessage("{PropertyName} should be not empty!")
                .Must(IsValidId).WithMessage("{PropertyName} should be 36 character!");

            RuleFor(e => e.EmployeeName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().NotEmpty().WithMessage("{PropertyName} should be not empty!")
                .Length(3, 30).WithMessage("{PropertyName} should be between 3 and 30 characters!")
                .Must(IsValidName).WithMessage("{PropertyName} should not use number character!");

            RuleFor(e => e.EmployeeLastname)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().NotEmpty().WithMessage("{PropertyName} should be not empty!")
                .Length(3, 40).WithMessage("{PropertyName} should be between 3 and 30 characters!")
                .Must(IsValidName).WithMessage("{PropertyName} should not use number character!");

            RuleFor(e => e.EmployeeBirthDate)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().NotEmpty().WithMessage("{PropertyName} should be not empty!")
                .LessThan(new DateTime(2000, 01, 01)).WithMessage("{PropertyName} should be less than 2000");

            RuleFor(e => e.DepartmentId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().NotNull().WithMessage("{PropertyName} should be not empty!")
                .Must(IsValidId).WithMessage("{PropertyName} should be 36 character!");
        }

        private bool IsValidName(string name)
        {
            return name.All(char.IsLetter);

        }

        private bool IsValidId(string id)
        {
            if (id.Length == 36 && id.Contains('-'))
            {
                return true;
            }
            return false;
        }
    }
}
