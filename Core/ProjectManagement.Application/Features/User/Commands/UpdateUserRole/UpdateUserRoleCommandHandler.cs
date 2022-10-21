using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.User.Commands.UpdateUserRole
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommandRequest, UpdateUserRoleCommandResponse>
    {
        private readonly ICommandUnitOfWork command;
        private readonly IQueryUnitOfWork query;
        private readonly IMapper mapper;

        public UpdateUserRoleCommandHandler(ICommandUnitOfWork command, IQueryUnitOfWork query, IMapper mapper)
        {
            this.command = command;
            this.query = query;
            this.mapper = mapper;
        }

        public async Task<UpdateUserRoleCommandResponse> Handle(UpdateUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var existsUser = await query.UserQuery.GetAsync(u => u.Id == Guid.Parse(request.Id));

            if(existsUser is null)
            {
                return new UpdateUserRoleCommandResponse { IsSuccess = false, ResponseMessage="User not found!"};
            }

            var user = mapper.Map(request, existsUser);
            command.UserCommand.Update(user);
            await command.SaveAsync();
            return new UpdateUserRoleCommandResponse { IsSuccess = true, ResponseMessage = $"{existsUser.Id} user updated successfully." };




        }
    }
}
