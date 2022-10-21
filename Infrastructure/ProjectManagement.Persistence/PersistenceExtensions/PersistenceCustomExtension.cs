using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Application.Repositories.Commands;
using ProjectManagement.Application.Repositories.Queries;
using ProjectManagement.Application.UnitOfWork;
using ProjectManagement.Persistence.Repositories.Commands;
using ProjectManagement.Persistence.Repositories.Queries;
using ProjectManagement.Persistence.UnitOfWork;

namespace ProjectManagement.Persistence.PersistenceExtensions
{
    public static class PersistenceCustomExtension
    {
        public static void AddPersistenceExtension(this IServiceCollection services)
        {
            services.AddScoped<IQueryUnitOfWork, QueryUnitOfWork>();
            services.AddScoped<ICommandUnitOfWork, CommandUnitOfWork>();

            services.AddScoped<IEmployeeQueryRepository, EmployeeQueryRepository>();
            services.AddScoped<IDepartmentQueryRepository, DepartmentQueryRepository>();
            services.AddScoped<IProjectQueryRepository, ProjectQueryRepository>();


            services.AddScoped<IEmployeeCommandRepository, EmployeeCommandRepository>();
            services.AddScoped<IDepartmentCommandRepository, DepartmentCommandRepository>();
            services.AddScoped<IProjectCommandRepository, ProjectCommandRepository>();

        }
    }
}
