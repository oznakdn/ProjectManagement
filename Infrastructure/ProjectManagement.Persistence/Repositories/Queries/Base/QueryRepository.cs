using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Repositories.Queries.Base;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Persistence.Contexts;
using System.Linq.Expressions;

namespace ProjectManagement.Persistence.Repositories.Queries.Base
{
    public class QueryRepository<T> : IQueryRepository<T> where T : BaseEntity, new()
    {
        protected readonly ProjectManagementDbContext context;

        public QueryRepository(ProjectManagementDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await context.Set<T>().Where(predicate).AnyAsync();
            return result;
        }

        public async Task<IQueryable<T>> GetAllAsync(bool isChangeTracking = false)
        {
            IQueryable<T> query = context.Set<T>();
            if(isChangeTracking)
            {
               return query = query.AsNoTracking().AsQueryable();
            }
            return await Task.Run(() => query.AsQueryable()); 


        }

        public async Task<IEnumerable<T>> GetAllWithIncludeAsync(bool isChangeTracking = false, Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();

            if (isChangeTracking)
            {
                query = predicate is null ? query.AsNoTracking()
                                          : query.Where(predicate).AsNoTracking();
                if (includes != null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    }
                }
            }
            else
            {
                query = predicate is null ? query
                                          : query.Where(predicate);
                if (includes != null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    }
                }
            }

            return await query.ToListAsync();

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool isChangeTracking = false)
        {
            IQueryable<T> query = context.Set<T>();
            if (isChangeTracking)
            {
                query = query.Where(predicate).AsNoTracking();
            }
            else
            {
                query = query.Where(predicate);
            }
            return await query.SingleAsync();
        }

        public async Task<T> GetByIdAsync(string id, bool isChangeTracking = false)
        {
            IQueryable<T> query = context.Set<T>();
            if (isChangeTracking)
            {
                query = query.Where(e => e.Id == Guid.Parse(id)).AsNoTracking();
            }
            else
            {
                query = query.Where(e => e.Id == Guid.Parse(id));
            }

            return await query.SingleAsync();
        }

        public async Task<T> GetWithIncludeAsync(bool isChangeTracking, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();

            if(isChangeTracking)
            {
                query = query.Where(predicate);
                if(includes is not null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    }
                }
            }
            else
            {
                query = query.Where(predicate).AsNoTracking();
                if(includes is not null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    }
                }
            }

            return await query.SingleOrDefaultAsync(); 

        }
    }
}
