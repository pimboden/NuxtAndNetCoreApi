using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using _8anu.Api.Common.Interfaces;
using _8anu.Api.Common.Runtime.Caching;
using _8anu.Api.Managers.Interfaces;
using _8anu.Data;

namespace _8anu.Api.Managers
{
    public abstract class BaseManager<TEntity> : IBaseManager<TEntity> where TEntity : DataEntity
    {
        protected readonly IRepository<TEntity> Repository;
        protected readonly IObjectCache Cache;
        protected readonly bool HasCache;
        protected object CacheLock;
        protected BaseManager(IRepository<TEntity> repository)
        {
            Repository = repository;
            Cache = null;
            CacheLock = null;
        }

        protected BaseManager(IRepository<TEntity> repository, IObjectCache cache, object cacheLock)
        {
            Repository = repository;
            Cache = cache;
            CacheLock = cacheLock;
            HasCache = true;
        }

        public TEntity Get(object[] keys)
        {
            if (!HasCache) return Repository.Get(keys);
            var itemCacheKey = GetCacheKey(keys);
            lock (CacheLock)
            {
                if (Cache.Exists<TEntity>(itemCacheKey))
                {
                    return Cache.Get<TEntity>(itemCacheKey);
                }
            }
            var tEntity = Repository.Get(keys);
            lock (CacheLock)
            {
                if (Cache.Exists<TEntity>(itemCacheKey))
                {
                    return Cache.Get<TEntity>(itemCacheKey);
                }
                else
                {
                    Cache.AddAbsolute(tEntity, itemCacheKey, TimeSpan.FromMinutes(5));

                }
            }
            return tEntity;
        }

        public List<TEntity> GetAll(int pageIndex = 0, int pageSize = 50)
        {
            if (!HasCache) return Repository.GetAll(pageIndex, pageSize).ToList();

            var allFound = Repository.GetAll(pageIndex, pageSize).ToList();

            //TODO: when all objects are only ID int, then actually just work with the interface IDataEntity
            AddEntitiesToCache(allFound);


            return allFound;
        }




        public List<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int pageIndex = 0, int pageSize = 50)
        {
            return Repository.Find(predicate, pageIndex, pageSize).ToList();
        }

        public int SaveNew(TEntity entity)
        {
            Repository.Add(entity);
            var returnValue = Repository.Complete();
            AddEntitiesToCache(new List<TEntity> {entity});
            return returnValue;
        }

        public int SaveNew(List<TEntity> entities)
        {
            Repository.AddRange(entities);
            var returnValue = Repository.Complete();
            AddEntitiesToCache(entities);
            return returnValue;
        }

        public int Remove(TEntity entity)
        {
            Repository.Remove(entity);
            RemoveEntitiesFromCache(new List<TEntity> {entity});
            return Repository.Complete();
        }

        public int Remove(List<TEntity> entities)
        {
            Repository.RemoveRange(entities);
            RemoveEntitiesFromCache(entities);
            return Repository.Complete();
        }

        public int Update(TEntity entity) 
        {
            Repository.Update(entity);
            return Repository.Complete();
        }
        public int Update(List<TEntity> entities)
        {
            Repository.UpdateRange(entities);
            return Repository.Complete();
        }

        private void RemoveEntitiesFromCache(List<TEntity> allEntities)
        {
            /*
            if (typeof(TEntity).IsSubclassOf(typeof(GuidDataEntity)))
            {
                foreach (var entity in allEntities)
                {
                    RemoveGuidDataEntityFromCache(entity);
                }
            }
            else if (typeof(TEntity).IsSubclassOf(typeof(IntDataEntity)))
            {
                foreach (var entity in allEntities)
                {
                    RemoveIntDataEntityFromCache(entity);
                }
            }
            else if (typeof(TEntity).IsSubclassOf(typeof(UIntDataEntity)))
            {
                foreach (var entity in allEntities)
                {
                    RemoveUIntDataEntityFromCache(entity);

                }
            }
            */
            foreach (var entity in allEntities)
            {
                RemoveIntDataEntityFromCache(entity);
            }
        }
        #region protected methods
        protected string GetCacheKey(object[] keys)
        {
            return keys.Aggregate("", (current, key) => $"{current}_{key}");
        }
        #endregion
        #region private methods

        /*
        private void RemoveUIntDataEntityFromCache(TEntity entity)
        {
            var dataEntity = entity as UIntDataEntity;
            if (dataEntity != null)
            {
                // ReSharper disable once PossibleInvalidOperationException
                var itemCacheKey = GetCacheKey(new object[] {dataEntity.DatabaseId.Value});
                lock (CacheLock)
                {
                    Cache.Clear(itemCacheKey);
                }
            }
        }
        */

        private void RemoveIntDataEntityFromCache(TEntity entity)
        {
            // var dataEntity = entity as IntDataEntity;
            var dataEntity = entity;
            if (dataEntity != null)
            {
                // ReSharper disable once PossibleInvalidOperationException
                var itemCacheKey = GetCacheKey(new object[] {dataEntity.Id.Value});
                lock (CacheLock)
                {
                    Cache.Clear(itemCacheKey);
                }
            }
        }

        /*
        private void RemoveGuidDataEntityFromCache(TEntity entity)
        {
            var dataEntity = entity as GuidDataEntity;
            if (dataEntity != null)
            {
                // ReSharper disable once PossibleInvalidOperationException
                var itemCacheKey = GetCacheKey(new object[] {dataEntity.DatabaseId.Value});
                lock (CacheLock)
                {
                    Cache.Clear(itemCacheKey);
                }
               
            }
        }
        */
        private void AddEntitiesToCache(List<TEntity> allEntities)
        {
            /*
            if (typeof(TEntity).IsSubclassOf(typeof(GuidDataEntity)))
            {
                foreach (var entity in allEntities)
                {
                    AddCacheGuidDataEntity(entity);
                }
            }
            else if (typeof(TEntity).IsSubclassOf(typeof(IntDataEntity)))
            {
                foreach (var entity in allEntities)
                {
                    AddCacheIntDataEntity(entity);
                }
            }
            else if (typeof(TEntity).IsSubclassOf(typeof(UIntDataEntity)))
            {
                foreach (var entity in allEntities)
                {
                    AddCacheUIntDataEntity(entity);

                }
            }
            */
            foreach (var entity in allEntities)
            {
                AddCacheIntDataEntity(entity);
            }
        }

        /*
        private void AddCacheUIntDataEntity(TEntity entity)
        {
            var dataEntity = entity as UIntDataEntity;
            if (dataEntity != null)
            {
                // ReSharper disable once PossibleInvalidOperationException
                var itemCacheKey = GetCacheKey(new object[] {dataEntity.DatabaseId.Value});
                lock (CacheLock)
                {
                    Cache.Clear(itemCacheKey);
                    Cache.AddSliding(entity, itemCacheKey, TimeSpan.FromMinutes(5));
                }
            }
        }
        */

        private void AddCacheIntDataEntity(TEntity entity)
        {
            //var dataEntity = entity as IntDataEntity;
            var dataEntity = entity;
            if (dataEntity != null)
            {
                // ReSharper disable once PossibleInvalidOperationException
                var itemCacheKey = GetCacheKey(new object[] {dataEntity.Id.Value});
                lock (CacheLock)
                {
                    Cache.Clear(itemCacheKey);
                    Cache.AddSliding(entity, itemCacheKey, TimeSpan.FromMinutes(5));
                }
            }
        }

        /*
        private void AddCacheGuidDataEntity(TEntity entity)
        {
            var dataEntity = entity as GuidDataEntity;
            if (dataEntity != null)
            {
                // ReSharper disable once PossibleInvalidOperationException
                var itemCacheKey = GetCacheKey(new object[] {dataEntity.DatabaseId.Value});
                lock (CacheLock)
                {
                    Cache.Clear(itemCacheKey);
                    Cache.AddSliding(entity, itemCacheKey, TimeSpan.FromMinutes(5));
                }
            }
        }
        */

       

        #endregion
    }
}