using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.Repositories.Commands.Base
{
    public interface ICommandRepository<T> where T : BaseEntity, new()
    {
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        T Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
