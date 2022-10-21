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
    }
}
