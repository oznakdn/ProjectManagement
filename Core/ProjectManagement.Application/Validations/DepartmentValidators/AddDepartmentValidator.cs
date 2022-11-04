using FluentValidation;
using ProjectManagement.Application.Features.Department.Commands.AddDepartment;

namespace ProjectManagement.Application.Validations.DepartmentValidators
{
    public class AddDepartmentValidator:AbstractValidator<AddDepartmentCommandRequest>
    {
        public AddDepartmentValidator()
        {
            RuleFor(d=>d.DepartmentName).NotEmpty().NotNull().WithMessage("{ProperyName} must not be empty!")
                .Length(2,50).WithMessage("{ProperyName} must be between 2 and 50 characters!");
        }
    }
}
