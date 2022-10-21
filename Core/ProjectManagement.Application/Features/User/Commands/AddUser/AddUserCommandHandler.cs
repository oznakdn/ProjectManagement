using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.User.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest, AddUserCommandResponse>
    {
        private readonly ICommandUnitOfWork command;
        private readonly IQueryUnitOfWork query;
        private readonly IMapper mapper;

        public AddUserCommandHandler(ICommandUnitOfWork command, IMapper mapper, IQueryUnitOfWork query)
        {
            this.command = command;
            this.mapper = mapper;
            this.query = query;
        }

        public async Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {

           var existUser = await query.UserQuery.AnyAsync(u=>u.Username == request.Username);
            if(existUser)
            {
                return new AddUserCommandResponse("User is already exists!");
            }
            
            var user = mapper.Map<Domain.Entities.User>(request);
            await command.UserCommand.AddAsync(user);
            await command.SaveAsync();
            return new AddUserCommandResponse("User is created.");
        }
    }
}
