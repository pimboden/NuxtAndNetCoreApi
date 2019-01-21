using System;

namespace _8anu.Api.Common.Runtime.Caching
{
    public interface IObjectCache
    {
        void AddAbsolute<T>(T objectToCache, string key, TimeSpan timeSpan) where T : class;
        void AddSliding<T>(T objectToCache, string key, TimeSpan timeSpan) where T : class;
        void Clear(string key);
        bool Exists<T>(string key);
        T Get<T>(string key) where T : class;
    }
}