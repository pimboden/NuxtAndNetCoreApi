using Microsoft.Extensions.Caching.Memory;
using System;

namespace _8anu.Api.Common.Runtime.Caching
{
    public class ObjectCache : IObjectCache
    {
        readonly IMemoryCache _memoryCache;

        public ObjectCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        ///     Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Key of cached item</param>
        /// <returns>Cached item as type or null</returns>
        public T Get<T>(string key) where T : class
        {
                return _memoryCache.TryGetValue(key, out T value) ? value : null;
        }

        /// <summary>
        ///     Insert value into the cache using
        ///     appropriate name/value pairs.
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="timeSpan">Amount of seconds to Cache the Object</param>
        public void AddAbsolute<T>(T objectToCache, string key, TimeSpan timeSpan) where T : class
        {

            _memoryCache.Set(key, objectToCache, timeSpan);
        }

        /// <summary>
        ///     Insert value into the cache using appropriate name/value pairs.
        ///     It still will exprie after 1 day
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="timeSpan">tispan for the sliding expiration.</param>
        public void AddSliding<T>(T objectToCache, string key, TimeSpan timeSpan) where T : class
        {
            var memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                SlidingExpiration = timeSpan
            };
            _memoryCache.Set(key, objectToCache, memoryCacheEntryOptions);
        }

        /// <summary>
        ///     Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        public void Clear(string key)
        {
            _memoryCache.Remove(key);
        }

        /// <summary>
        ///     Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns></returns>
        public bool Exists<T>(string key)
        {
            return _memoryCache.TryGetValue(key, out T _);
        }
    }
}
