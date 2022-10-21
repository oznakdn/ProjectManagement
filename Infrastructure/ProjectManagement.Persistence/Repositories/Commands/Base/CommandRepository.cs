using ProjectManagement.Application.Repositories.Commands.Base;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Persistence.Contexts;

namespace ProjectManagement.Persistence.Repositories.Commands.Base
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity, new()
    {
        protected readonly ProjectManagementDbContext context;

        public CommandRepository(ProjectManagementDbContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await context.Set<T>().AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }

        public T Update(T entity)
        {
            context.Set<T>().Update(entity);
            return entity;
        }
    }
}
