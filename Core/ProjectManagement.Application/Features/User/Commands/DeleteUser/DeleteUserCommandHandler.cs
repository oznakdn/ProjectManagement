using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        private readonly ICommandUnitOfWork command;
        private readonly IQueryUnitOfWork query;

        public DeleteUserCommandHandler(ICommandUnitOfWork command, IQueryUnitOfWork query)
        {
            this.command = command;
            this.query = query;
        }

        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var existingUser = await query.UserQuery.GetByIdAsync(request.UserId);
            if (existingUser is null)
                return new DeleteUserCommandResponse(false, "User not found");


            int isSaved = 0;
            command.UserCommand.Remove(existingUser);
            isSaved = await command.SaveAsync();
            if (isSaved == 0)
                return new DeleteUserCommandResponse(false,"User couldn't deleted");
            return new DeleteUserCommandResponse(true, "User was deleted successfully.");
        }
    }
}
