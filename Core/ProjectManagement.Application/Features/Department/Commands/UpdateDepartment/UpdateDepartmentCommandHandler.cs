using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommandRequest, UpdateDepartmentCommandResponse>
    {
        private readonly ICommandUnitOfWork command;
        private readonly IMapper mapper;

        public UpdateDepartmentCommandHandler(ICommandUnitOfWork command, IMapper mapper)
        {
            this.command = command;
            this.mapper = mapper;
        }

        public async Task<UpdateDepartmentCommandResponse> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {

            var department = mapper.Map<Domain.Entities.Department>(request);
            command.DepartmentCommand.Update(department);
            await command.SaveAsync();

            return new UpdateDepartmentCommandResponseMessage($"{request.Id} Department is updated successfully.")
            {
                 DepartmentName = department.DepartmentName,
                 Id = department.Id.ToString()
            };

        }
    }
}
