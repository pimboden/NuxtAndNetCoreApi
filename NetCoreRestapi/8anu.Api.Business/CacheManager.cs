using _8anu.Api.Common.Runtime.Caching;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Managers
{
    public class CacheManager : ICacheManager
    {
        private readonly ICacheHandler _cacheHandler;
        public CacheManager(ICacheHandler cacheHandler)
        {
            _cacheHandler = cacheHandler;
        }

        public bool ClearCaches(string password)
        {
            return _cacheHandler.ClearCaches(password);
        }
    }
}