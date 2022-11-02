using ProjectManagement.Application.Repositories.Commands.Base;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.Repositories.Commands
{
    public interface IProjectCommandRepository:ICommandRepository<Project>
    {
        Task AddProjectEmployee(string projectId, string employeeId);
        Task DeleteEmployeeOnProject(string projectId, string employeeId);
    }
}
