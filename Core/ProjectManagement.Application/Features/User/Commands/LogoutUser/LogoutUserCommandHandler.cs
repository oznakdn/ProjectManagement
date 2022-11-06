using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.User.Commands.LogoutUser
{
    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommandRequest, LogoutUserCommandResponse>
    {
        private readonly IQueryUnitOfWork query;
        private readonly ICommandUnitOfWork command;

        public LogoutUserCommandHandler(IQueryUnitOfWork query, ICommandUnitOfWork command)
        {
            this.query = query;
            this.command = command;
        }

        public async Task<LogoutUserCommandResponse> Handle(LogoutUserCommandRequest request, CancellationToken cancellationToken)
        {
            var existUser =await query.UserQuery.GetAsync(u => u.Id ==Guid.Parse(request.UserId));

            if (existUser == null)
            {
                return new LogoutUserCommandResponse { ResponseMessage = "User not found!", IsSuccess = false };

            }

            existUser.RefreshToken.Remove(0);
            var isSaved = await command.SaveAsync();
            if (isSaved == 0)
                return new LogoutUserCommandResponse { ResponseMessage = "User could not be logout", IsSuccess = false };

            return new LogoutUserCommandResponse { ResponseMessage = "User is logout", IsSuccess = true };
               
        }
    }
}
