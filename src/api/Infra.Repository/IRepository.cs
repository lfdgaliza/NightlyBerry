using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DistroGuide.Infra.Repository
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity> : IRepository
        where TEntity : EntityBase
    {
        void Add(TEntity entity);
        void AddBulk(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveBulk(IEnumerable<TEntity> entities);
        TEntity Get(Guid key);
        List<TEntity> GetAll(bool tracking = false, params string[] includes);
        List<TEntity> Search(Expression<Func<TEntity, bool>> predicate, bool tracking = false);
        int Count(Expression<Func<TEntity, bool>> predicate);
    }
}
