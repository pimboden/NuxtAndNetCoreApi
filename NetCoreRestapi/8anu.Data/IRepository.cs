using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace _8anu.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Get(object[] keys);

        List<TEntity> GetAll(int pageIndex = 0, int pageSize = 50);

        List<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int pageIndex = 0, int pageSize = 50);

        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex = 0, int pageSize = 50);

        void Add(TEntity entity);

        void AddRange(List<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(List<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(List<TEntity> entities);

        int Complete();
    }
}