using ProjectManagement.Application.Repositories.Queries;
using ProjectManagement.Application.UnitOfWork;
using ProjectManagement.Persistence.Contexts;
using ProjectManagement.Persistence.Repositories.Queries;

namespace ProjectManagement.Persistence.UnitOfWork
{
    public class QueryUnitOfWork : IQueryUnitOfWork
    {
        private readonly ProjectManagementDbContext _context;

        public QueryUnitOfWork(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public DepartmentQueryRepository _departmentQuery;
        public EmployeeQueryRepository _employeeQuery;
        public ProjectQueryRepository _projectQuery;
        public UserQueryRepository _userQuery;

        public IDepartmentQueryRepository DepartmentQuery => _departmentQuery ?? (_departmentQuery = new DepartmentQueryRepository(_context));

        public IEmployeeQueryRepository EmployeeQuery => _employeeQuery ?? (_employeeQuery = new EmployeeQueryRepository(_context));

        public IProjectQueryRepository ProjectQuery => _projectQuery ?? (_projectQuery = new ProjectQueryRepository(_context));

        public IUserQueryRepository UserQuery => _userQuery ?? (_userQuery = new UserQueryRepository(_context));
    }
}
