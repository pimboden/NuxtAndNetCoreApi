using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace _8anu.Api.Common.Runtime.Caching
{
    public class CacheHandler : ICacheHandler
    {
        private readonly IConfiguration _configuration;
        public IObjectCache ForumCategoryCache { get; private set; }
        public object ForumCategoryCacheLock { get; }

        public IObjectCache ForumCache { get; private set; }
        public object ForumCacheLock { get; }

        public IObjectCache ArticleCache { get; private set; }
        public object ArticleCacheLock { get; }

        public IObjectCache CountryCache { get; private set; }
        public object CountryCacheLock { get; }

        public IObjectCache NewsCache { get; private set; }
        public object NewsCacheLock { get; }

        public IObjectCache TestModelCache { get; private set; }
        public object TestModelCacheLock { get; }

        public IObjectCache CragsCache { get; private set; }
        public object CragsCacheLock { get; }
        
        public object ClearCacheLock { get; }

        public CacheHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            ClearCacheLock = new object();

            ForumCategoryCache = new ObjectCache(new MemoryCache(new MemoryCacheOptions()));
            ForumCategoryCacheLock = new object();

            ForumCache = new ObjectCache(new MemoryCache(new MemoryCacheOptions()));
            ForumCacheLock = new object();

            ArticleCache = new ObjectCache(new MemoryCache(new MemoryCacheOptions()));
            ArticleCacheLock = new object();

            CountryCache = new ObjectCache(new MemoryCache(new MemoryCacheOptions()));
            CountryCacheLock = new object();

            NewsCache = new ObjectCache(new MemoryCache(new MemoryCacheOptions()));
            NewsCacheLock = new object();

            TestModelCache = new ObjectCache(new MemoryCache(new MemoryCacheOptions()));
            TestModelCacheLock = new object();
            
            CragsCache = new ObjectCache(new MemoryCache(new MemoryCacheOptions()));
            CragsCacheLock = new object();
        }

        public bool ClearCaches(string password)
        {
            if (password.Equals(_configuration.GetSection("AppSettings")["ClearCachePassword"],
                StringComparison.InvariantCulture))
            {
                lock (ClearCacheLock)
                {
                    lock (ForumCategoryCacheLock)
                    {
                        ForumCategoryCache = new ObjectCache(new MemoryCache(new MemoryCacheOptions()));
                    }
                    lock (ForumCacheLock)
                    {
                        ForumCache = new ObjectCache(new MemoryCache(new MemoryCacheOptions()));
                    }
                    lock (ArticleCacheLock)
                    {
                        ArticleCache = new ObjectCache(new MemoryCache(new MemoryCacheOptions()));
                    }
                    lock (CountryCacheLock)
                    {
                        CountryCache = new ObjectCache(new MemoryCache(new MemoryCacheOptions()));
                    }
                    lock (NewsCacheLock)
                    {
                        NewsCache = new ObjectCache(new MemoryCache(new MemoryCacheOptions()));
                    }
                    lock (TestModelCacheLock)
                    {
                        TestModelCache = new ObjectCache(new MemoryCache(new MemoryCacheOptions()));
                    }

                    lock (CragsCacheLock)
                    {
                        CragsCache = new ObjectCache(new MemoryCache(new MemoryCacheOptions()));
                    }
                }

                return true;
            }

            return false;
        }
    }
}
