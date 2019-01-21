using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _8anu.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public DbContext Context => _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public TEntity Get(object[] keys)
        {
            return _context.Set<TEntity>().Find(keys);
        }

        public List<TEntity> GetAll(int pageIndex = 0, int pageSize = 50)
        {
            return _context.Set<TEntity>().Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public List<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int pageIndex = 0,
            int pageSize = 50)
        {
            return _context.Set<TEntity>().Where(predicate).Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex = 0,
            int pageSize = 50)
        {
            return _context.Set<TEntity>().Where(predicate).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(List<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(List<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity) 
        {
            _context.Set<TEntity>().Update(entity);    
        }

        public void UpdateRange(List<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
