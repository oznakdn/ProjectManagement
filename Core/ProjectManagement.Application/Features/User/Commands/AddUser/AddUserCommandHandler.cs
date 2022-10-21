using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using ProjectManagement.Application.Extensions;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.User.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest, AddUserCommandResponse>
    {
        private readonly ICommandUnitOfWork command;
        private readonly IQueryUnitOfWork query;
        private readonly IMapper mapper;
        private IConfiguration configuration;

        public AddUserCommandHandler(ICommandUnitOfWork command, IMapper mapper, IQueryUnitOfWork query, IConfiguration configuration)
        {
            this.command = command;
            this.mapper = mapper;
            this.query = query;
            this.configuration = configuration;
        }

        public async Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {

            var existUser = await query.UserQuery.AnyAsync(u => u.Username == request.Username);
            if (existUser)
            {
                return new AddUserCommandResponse("User is already exists!") { IsSuccess = false };
            }

            var user = mapper.Map<Domain.Entities.User>(request);
            user.Password = PasswordGeneratorExtension.PasswordHashGenerate(configuration,user.Password);
            await command.UserCommand.AddAsync(user);
            await command.SaveAsync();
            return new AddUserCommandResponse("User is created.") { IsSuccess = true };
        }
    }
}
