using ProjectManagement.Application.Repositories.Queries;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Persistence.Contexts;
using ProjectManagement.Persistence.Repositories.Queries.Base;

namespace ProjectManagement.Persistence.Repositories.Queries
{
    public class DepartmentQueryRepository : QueryRepository<Department>, IDepartmentQueryRepository
    {
        public DepartmentQueryRepository(ProjectManagementDbContext context) : base(context)
        {
        }
    }
}
