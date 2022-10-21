using ProjectManagement.Domain.Entities;
using System.Linq.Expressions;

namespace ProjectManagement.Application.Repositories.Queries.Base
{
    public interface IQueryRepository<T> where T : BaseEntity,new()
    {
        Task<IQueryable<T>> GetAllAsync(bool isChangeTracking = false);
        Task<IEnumerable<T>> GetAllWithIncludeAsync(bool isChangeTracking = false, Expression < Func<T,bool>>predicate = null, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool isChangeTracking = false);
        Task<T> GetWithIncludeAsync(bool isChangeTracking, Expression<Func<T, bool>> predicate ,params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(string id, bool isChangeTracking = false);

        Task<bool> AnyAsync(Expression<Func<T,bool>>predicate);

    }
}
