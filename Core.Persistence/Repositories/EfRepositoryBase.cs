using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories;

public class EfRepositoryBase<TEntity, TContext> : IRepositoryAsync<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    protected TContext Context { get; }

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public async Task<TEntity?> GetAsync(int id)
    {
        var entity = await Context.Set<TEntity>().FindAsync(id);

        return entity;
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predcate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {

        var query = Context.Set<TEntity>().AsQueryable();

        if (include != null)
            query = include(query);

        var entity = await query.FirstOrDefaultAsync(predcate);

        return entity;

    }

    public async Task<Paginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, 
                                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, 
                                               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
                                               int index = 0, int size = 10, bool enableTracking = true)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if(!enableTracking) query = query.AsNoTracking();

        if (predicate != null) query = query.Where(predicate);

        if(include != null) query = include(query);

        if(orderBy != null) query = orderBy(query);

        var entityList = await query.ToPaginateAsync(index, size);

        return entityList;
    }
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        //Context.Entry(entity).State = EntityState.Added;
        
        var entityEntry =  await Context.Set<TEntity>().AddAsync(entity);

        await Context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
         var entityEntry =  Context.Set<TEntity>().Update(entity);

        await Context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        var entityEntry = Context.Set<TEntity>().Remove(entity);

        await Context.SaveChangesAsync();

        return entityEntry.Entity;
    }
}
