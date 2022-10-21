using ProjectManagement.Application.Repositories.Commands;
using ProjectManagement.Application.UnitOfWork;
using ProjectManagement.Persistence.Contexts;
using ProjectManagement.Persistence.Repositories.Commands;

namespace ProjectManagement.Persistence.UnitOfWork
{
    public class CommandUnitOfWork : ICommandUnitOfWork
    {
        private readonly ProjectManagementDbContext _context;

        public CommandUnitOfWork(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public DepartmentCommandRepository _departmentCommand;
        public EmployeeCommandRepository _employeeCommand;
        public ProjectCommandRepository _projectCommand;
        public UserCommandReposiory _userCommand;

        public IDepartmentCommandRepository DepartmentCommand => _departmentCommand ?? (_departmentCommand = new DepartmentCommandRepository(_context));

        public IEmployeeCommandRepository EmployeeCommand => _employeeCommand ?? (_employeeCommand = new EmployeeCommandRepository(_context));

        public IProjectCommandRepository ProjectCommand => _projectCommand ?? (_projectCommand = new ProjectCommandRepository(_context));

        public IUserCommandRepository UserCommand => _userCommand ?? (_userCommand = new 
            UserCommandReposiory(_context));

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
