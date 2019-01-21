using System;
using _8anu.Api.Common.Interfaces;
using _8anu.Api.Common.Runtime.Caching;
using _8anu.Api.Managers.Interfaces;
using _8anu.Data;

namespace _8anu.Api.Managers
{
    public abstract class BaseSlugManager<TSlugEntity> : BaseManager<TSlugEntity>, IBaseSlugManager<TSlugEntity>
        where TSlugEntity : DataEntity, ISlugEntity
    {
        private readonly ISlugRepository<TSlugEntity> _slugRepository;
    

        protected BaseSlugManager(ISlugRepository<TSlugEntity> repository) : base(repository)
        {
            _slugRepository = repository;
        }

        protected BaseSlugManager(ISlugRepository<TSlugEntity> repository, IObjectCache cache, object cacheLock) : base(repository, cache, cacheLock)
        {
            _slugRepository = repository;
        }

        public TSlugEntity GetBySlug(string slug)
        {
            if (!HasCache) return _slugRepository.GetBySlug(slug);
            var itemCacheKey = GetCacheKey(new object[] {slug});
            lock (CacheLock)
            {
                if (Cache.Exists<TSlugEntity>(itemCacheKey))
                {
                    return Cache.Get<TSlugEntity>(itemCacheKey);
                }

                var slugEntity = _slugRepository.GetBySlug(slug);
                Cache.AddAbsolute(slugEntity, itemCacheKey, TimeSpan.FromMinutes(10));
                return slugEntity;
            }
        }
    }
}