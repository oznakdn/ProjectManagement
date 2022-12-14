using FluentValidation;
using ProjectManagement.Application.Features.Project.Commands.AddProject;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Validations.ProjectValidators
{
    public class AddProjectValidator : AbstractValidator<AddProjectCommandRequest>
    {
        public AddProjectValidator()
        {
            RuleFor(p => p.ProjectTitle).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
                .Length(5, 100).WithMessage("{PropertyName} must be between 5 and 100 characters!");

            RuleFor(p => p.ProjectDetails).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
                .MinimumLength(10).WithMessage("{PropertyName} must be more then 9 characters!");

            RuleFor(p => p.ProjectStartDate).NotNull().WithMessage("{PropertyName} is required!")
                .LessThan(p => p.ProjectEndDate).WithMessage("Project starting date must be less then project end date!");

            RuleFor(p => p.ProjectEndDate).NotNull().WithMessage("{PropertyName} is required!")
                .GreaterThan(p => p.ProjectStartDate).WithMessage("Project ending date must be greater then project start date!");

        }
    }
}
