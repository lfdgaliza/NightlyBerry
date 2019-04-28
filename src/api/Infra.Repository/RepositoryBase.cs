using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DistroGuide.Infra.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        private readonly DbContext context;

        public RepositoryBase(DbContext context)
        {
            this.context = context;
        }

        protected DbSet<TEntity> EntitySet => this.context.Set<TEntity>();
        public void Add(TEntity entity) => EntitySet.Add(entity);
        public void AddBulk(IEnumerable<TEntity> entities) => EntitySet.AddRange(entities);
        public void Remove(TEntity entity) => EntitySet.Remove(entity);
        public void RemoveBulk(IEnumerable<TEntity> entities) => EntitySet.RemoveRange(entities);
        public TEntity Get(Guid key) => EntitySet.Find(key);
        public List<TEntity> GetAll(bool tracking = false, params string[] includes)
        {
            var query = EntitySet.AsQueryable();

            foreach (var include in includes ?? new string[0])
                query = query.Include(include);

            return (tracking ? query : query.AsNoTracking()).ToList();
        }
        public List<TEntity> Search(Expression<Func<TEntity, bool>> predicate, bool tracking = false)
                    => (
                    tracking
                    ? EntitySet.Where(predicate)
                    : EntitySet.Where(predicate).AsNoTracking()).ToList();

        public int Count(Expression<Func<TEntity, bool>> predicate)
            => EntitySet.Count(predicate);
    }
}
