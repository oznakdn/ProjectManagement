using FluentValidation;
using ProjectManagement.Application.Features.Employee.Commands.AddEmployee;

namespace ProjectManagement.Application.Validations.EmployeeValidators
{
    public class AddEmployeeValidator:AbstractValidator<AddEmployeeCommandRequest>
    {
        public AddEmployeeValidator()
        {
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
                .NotEmpty().NotNull().WithMessage("{PropertyName} should be not empty!")
                .Must(IsValidId).WithMessage("{PropertyName} should be 36 character!");


        }


        private bool IsValidName(string name)
        {
            return name.All(char.IsLetter);

        }

        private bool IsValidId(string DepartmentId)
        {
            return DepartmentId.Length == 36 && DepartmentId.Contains('-');
        }

    }
}
