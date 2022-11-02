using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Repositories.Commands;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Persistence.Contexts;
using ProjectManagement.Persistence.Repositories.Commands.Base;

namespace ProjectManagement.Persistence.Repositories.Commands
{
    public class ProjectCommandRepository : CommandRepository<Project>, IProjectCommandRepository
    {
        public ProjectCommandRepository(ProjectManagementDbContext context) : base(context)
        {

        }

        public async Task AddProjectEmployee(string projectId, string employeeId)
        {
            var project = await context.Projects.Include(p => p.Employees).SingleOrDefaultAsync(x => x.Id == Guid.Parse(projectId));
            var employee = await context.Employees.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Guid.Parse(employeeId));

            project.Employees.Add(employee);
        }

        public async Task DeleteEmployeeOnProject(string projectId, string employeeId)
        {
            var project = await context.Projects.Include(p => p.Employees).SingleOrDefaultAsync(x => x.Id == Guid.Parse(projectId));
            var deletedEmployee = project.Employees.SingleOrDefault(e => e.Id == Guid.Parse(employeeId));
            project.Employees.Remove(deletedEmployee);
        }
    }
}
