using ProjectManagement.Application.Repositories.Queries;

namespace ProjectManagement.Application.UnitOfWork
{
    public interface IQueryUnitOfWork
    {
        IDepartmentQueryRepository DepartmentQuery { get; }
        IEmployeeQueryRepository EmployeeQuery { get; }
        IProjectQueryRepository ProjectQuery { get; }
        IUserQueryRepository UserQuery { get; }
    }
}
