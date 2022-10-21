using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.Department.Commands.AddDepartment
{
    public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommandRequest, AddDepartmentCommandResponse>
    {
        private readonly ICommandUnitOfWork command;
        private readonly IMapper mapper;

        public AddDepartmentCommandHandler(ICommandUnitOfWork command, IMapper mapper)
        {
            this.command = command;
            this.mapper = mapper;
        }

        public async Task<AddDepartmentCommandResponse> Handle(AddDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            var department = mapper.Map<Domain.Entities.Department>(request);
            await command.DepartmentCommand.AddAsync(department);
            await command.SaveAsync();
            return new AddDepartmentCommandResponse("Department is added successfully.");
        }
    }
}
