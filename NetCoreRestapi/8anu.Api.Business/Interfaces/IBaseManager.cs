using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _8anu.Api.Managers.Interfaces
{
    public interface IBaseManager<TEntity> where TEntity : class
    {
        TEntity Get(object[] keys);
        List<TEntity> GetAll(int pageIndex = 0, int pageSize = 50);
        List<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int pageIndex = 0, int pageSize = 50);
        int SaveNew(TEntity entity);
        int SaveNew(List<TEntity> entities);
        int Remove(TEntity entity);
        int Remove(List<TEntity> entities);
        int Update(TEntity entity);
        int Update(List<TEntity> entities);
    }
}