using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public class EfRepositoryBase<TEntity, TEntityId, TContext> : IAsyncRepository<TEntity, TEntityId>, IRepository<TEntity, TEntityId>
        where TEntity : Entity<TEntityId>
        where TContext : DbContext
    {
        private readonly TContext Context;

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {

        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public ICollection<TEntity> AddRange(ICollection<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                entity.CreatedDate = DateTime.UtcNow;
            await Context.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
            return entities;
        }

        public bool Any(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public TEntity Delete(TEntity entity, bool permanent)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> DeleteAsync(TEntity entity, bool permanent)
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> DeleteRange(ICollection<TEntity> entity, bool permanent = false)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false)
        {
            throw new NotImplementedException();
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public Pagination<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public Pagination<TEntity> GetListByDynamic(DynamicQuery dynamic, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<TEntity>> GetListByDynamicAsync(DynamicQuery dynamic, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Query()
        {
            throw new NotImplementedException();
        }

        public TEntity Update()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> UpdateRange(ICollection<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities)
        {
        }
    }
}
