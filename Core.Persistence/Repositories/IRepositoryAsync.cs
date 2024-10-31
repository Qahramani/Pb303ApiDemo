using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories;

public interface IRepositoryAsync<T> where T : BaseEntity
{
    Task<T?> GetAsync(int id);

    Task<T?> GetAsync(Expression<Func<T,bool>> predcate, Func<IQueryable<T>,IIncludableQueryable<T,object>>? include = null);

    Task<Paginate<T>> GetListAsync(Expression<Func<T, bool>>? predcate = null,
                                   Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                   Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                   int index = 0, int size = 10, bool enableTracking = true);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}
