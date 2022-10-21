using ProjectManagement.Application.Repositories.Commands;

namespace ProjectManagement.Application.UnitOfWork
{
    public interface ICommandUnitOfWork
    {
        IDepartmentCommandRepository DepartmentCommand { get; }
        IEmployeeCommandRepository EmployeeCommand { get; }
        IProjectCommandRepository ProjectCommand { get; }
        IUserCommandRepository UserCommand { get; }

        Task<int> SaveAsync();
    }
}
