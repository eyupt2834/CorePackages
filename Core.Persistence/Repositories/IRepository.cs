﻿using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public interface IRepository<TEntity, TEntityId> : IQuery<TEntity>
        where TEntity : Entity<TEntityId>
    {

        TEntity? Get(Expression<Func<TEntity, bool>> predicate,
         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
         bool withDeleted = false,
         bool enableTracking = true,
         CancellationToken cancellation = default
         );

        Pagination<TEntity> GetList(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellation = default
            );

        Pagination<TEntity> GetListByDynamic(
            DynamicQuery dynamic,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellation = default
            );

        bool Any(
            Expression<Func<TEntity, bool>>? predicate = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellation = default
            );

        TEntity Add(TEntity entity);

        ICollection<TEntity> AddRange(ICollection<TEntity> entity);

        TEntity Update();

        ICollection<TEntity> UpdateRange(ICollection<TEntity> entity);

        TEntity Delete(TEntity entity, bool permanent);

        ICollection<TEntity> DeleteRange(ICollection<TEntity> entity, bool permanent = false);

    }
}
