using ProjectManagement.Application.Repositories.Commands.Base;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.Repositories.Commands
{
    public interface IUserCommandRepository:ICommandRepository<User>
    {
    }
}
