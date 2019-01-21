using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;
using _8anu.Api.Common.Runtime.Caching;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Managers
{
    public class ForumCommentsManager : BaseManager<ForumComment>, IForumCommentsManager
    {

        private readonly IForumCommentsRepository _forumcommentsRepository;
        private readonly IObjectCache _forumCache;
        private readonly object _forumCacheLock;

        public ForumCommentsManager(IForumCommentsRepository forumcommentsRepository, ICacheHandler cacheHandler) : base(forumcommentsRepository)
        {
            _forumcommentsRepository = forumcommentsRepository;
            _forumCache = cacheHandler.ForumCache;
            _forumCacheLock = cacheHandler.ForumCacheLock;
        }

        public async Task<List<ForumComment>> GetLatestCommentsByCategorySlugAsync(string categorySlug,
            int pageIndex = 0, int pageSize = 50)
        {
            var cacheKey = $"LatestComments_{categorySlug}_{pageIndex}_{pageSize}";
            lock (_forumCacheLock)
            {
                if (_forumCache.Exists<List<ForumComment>>(cacheKey))
                {
                    return _forumCache.Get<List<ForumComment>>(cacheKey);
                }
            }

            var found = await _forumcommentsRepository.GetLatestCommentsByCategorySlugAsync(categorySlug, pageIndex,
                pageSize);
            lock (_forumCacheLock)
            {
                if (_forumCache.Exists<List<ForumComment>>(cacheKey))
                {
                    //Just in case at the mean time some other request already filled it up!
                    //Rather do this than block  the lock for long time
                    return _forumCache.Get<List<ForumComment>>(cacheKey);
                }
                 _forumCache.AddAbsolute(found, cacheKey, TimeSpan.FromMinutes(5));
            }
            return found;
        }

        public async Task<List<ForumComment>> GetLatestCommentsAsync(int pageIndex = 0, int pageSize = 50)
        {

            var cacheKey = $"LatestComments_NoFilter_{pageIndex}_{pageSize}";
            lock (_forumCacheLock)
            {
                if (_forumCache.Exists<List<ForumComment>>(cacheKey))
                {
                    return _forumCache.Get<List<ForumComment>>(cacheKey);
                }
            }

            var found = await _forumcommentsRepository.GetLatestCommentsAsync(pageIndex, pageSize);
            lock (_forumCacheLock)
            {
                if (_forumCache.Exists<List<ForumComment>>(cacheKey))
                {
                    //Just in case at the mean time some other request already filled it up!
                    //Rather do this than block  the lock for long time
                    return _forumCache.Get<List<ForumComment>>(cacheKey);
                }
                _forumCache.AddAbsolute(found, cacheKey, TimeSpan.FromMinutes(5));
            }
            return found;
        }

        public async Task<ThreadInfo> GetThreadInfo(string categorySlug, string subcategorySlug, string threadSlug)
        {
            if (!string.IsNullOrEmpty(subcategorySlug))
            {
                return await GetThreadInfoSubCategory(categorySlug, subcategorySlug, threadSlug);
            }
            return await GetThreadInfoRootCategory(categorySlug, threadSlug);
        }
        public async Task<ThreadInfo> GetThreadInfoRootCategory(string categorySlug, string threadSlug)
        {
            var cacheKey = $"ThreadInfoRootCategory_{categorySlug}_{threadSlug}";
            lock (_forumCacheLock)
            {
                if (_forumCache.Exists<ThreadInfo>(cacheKey))
                {
                    return _forumCache.Get<ThreadInfo> (cacheKey);
                }
            }

            var found = await _forumcommentsRepository.GetThreadInfoRootCategory(categorySlug, threadSlug);
            lock (_forumCacheLock)
            {
                if (_forumCache.Exists<ThreadInfo>(cacheKey))
                {
                    //Just in case at the mean time some other request already filled it up!
                    //Rather do this than block  the lock for long time
                    return _forumCache.Get<ThreadInfo>(cacheKey);
                }
                _forumCache.AddSliding(found, cacheKey, TimeSpan.FromHours(5));
            }
            return found;
        }
        public async Task<ThreadInfo> GetThreadInfoSubCategory(string categorySlug, string subcategorySlug, string threadSlug)
        {
            var cacheKey = $"ThreadInfoSubCategory_{categorySlug}_{subcategorySlug}_{threadSlug}";
            lock (_forumCacheLock)
            {
                if (_forumCache.Exists<ThreadInfo>(cacheKey))
                {
                    return _forumCache.Get<ThreadInfo>(cacheKey);
                }
            }

            var found = await _forumcommentsRepository.GetThreadInfoSubCategory(categorySlug, subcategorySlug, threadSlug);
            lock (_forumCacheLock)
            {
                if (_forumCache.Exists<ThreadInfo>(cacheKey))
                {
                    //Just in case at the mean time some other request already filled it up!
                    //Rather do this than block  the lock for long time
                    return _forumCache.Get<ThreadInfo>(cacheKey);
                }
                _forumCache.AddSliding(found, cacheKey, TimeSpan.FromHours(5));
            }
            return found;
        }

        public async Task<List<ThreadComment>> GetThreadComments(int threadInfoId, int pageIndex = 0, int pageSize = 50)
        {
            var cacheKey = $"ThreadComments_{threadInfoId}_{pageIndex}_{pageSize}";
            lock (_forumCacheLock)
            {
                if (_forumCache.Exists<List<ThreadComment>>(cacheKey))
                {
                    return _forumCache.Get<List<ThreadComment>>(cacheKey);
                }
            }

            var found = await _forumcommentsRepository.GetThreadComments(threadInfoId, pageIndex, pageSize);     
            lock (_forumCacheLock)
            {
                if (_forumCache.Exists<List<ForumComment>>(cacheKey))
                {
                    //Just in case at the mean time some other request already filled it up!
                    //Rather do this than block  the lock for long time
                    return _forumCache.Get<List<ThreadComment>>(cacheKey);
                }
                _forumCache.AddAbsolute(found, cacheKey, TimeSpan.FromMinutes(5));
            }
            return found;
        }
    }
}