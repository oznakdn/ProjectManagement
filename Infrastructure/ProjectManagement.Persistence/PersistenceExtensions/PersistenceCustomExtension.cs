using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Application.Abstracts;
using ProjectManagement.Application.Repositories.Commands;
using ProjectManagement.Application.Repositories.Queries;
using ProjectManagement.Application.UnitOfWork;
using ProjectManagement.Persistence.Concretes;
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
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();




            services.AddScoped<IEmployeeCommandRepository, EmployeeCommandRepository>();
            services.AddScoped<IDepartmentCommandRepository, DepartmentCommandRepository>();
            services.AddScoped<IProjectCommandRepository, ProjectCommandRepository>();
            services.AddScoped<IUserCommandRepository, UserCommandReposiory>();

            services.AddScoped<ITokenHandler, TokenHandler>();


        }
    }
}
