using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.User.Commands.AddEmployeeToUser
{
    public class AddEmployeeToUserCommandHandler : IRequestHandler<AddEmployeeToUserCommandRequest, AddEmployeeToUserCommandResponse>
    {
        private readonly IQueryUnitOfWork query;
        private readonly ICommandUnitOfWork command;
        private readonly IMapper mapper;

        public AddEmployeeToUserCommandHandler(IQueryUnitOfWork query, ICommandUnitOfWork command, IMapper mapper)
        {
            this.query = query;
            this.command = command;
            this.mapper = mapper;
        }

        public async Task<AddEmployeeToUserCommandResponse> Handle(AddEmployeeToUserCommandRequest request, CancellationToken cancellationToken)
        {
            var existsUser = await query.UserQuery.GetAsync(u => u.Id == Guid.Parse(request.UserId));

            if(existsUser is null)
            {
                return new AddEmployeeToUserCommandResponse { IsSuccess = false, ResponseMessage = "User not found!" };
            }

            var user = mapper.Map(request, existsUser);
            command.UserCommand.Update(user);
            await command.SaveAsync();
            return new AddEmployeeToUserCommandResponse
            {
                IsSuccess = true,
                ResponseMessage = $"{existsUser.Id} user's employee informations was added as successfully."
            };


        }
    }
}
