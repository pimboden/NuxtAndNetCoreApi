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
    public class ForumThreadsManager : BaseManager<ForumThread>, IForumThreadsManager
    {

        private readonly IForumThreadsRepository _forumthreadsRepository;
        private readonly IForumCommentsRepository _forumCommentsRepository;
        private readonly IObjectCache _forumCache;
        private readonly object _forumCacheLock;

        public ForumThreadsManager(IForumThreadsRepository forumthreadsRepository, IForumCommentsRepository forumCommentsRepository, ICacheHandler cacheHandler) : base(
            forumthreadsRepository)
        {
            _forumthreadsRepository = forumthreadsRepository;
            _forumCommentsRepository = forumCommentsRepository;
            _forumCache = cacheHandler.ForumCache;
            _forumCacheLock = cacheHandler.ForumCacheLock;

        }

        public async Task<List<ForumThreadWithCounts>> GetForumThreadsByCategorySlugAsync(string categorySlug, int pageIndex = 0, int pageSize = 50)
        {
            var cacheKey = $"ThreadsOfSlug_{categorySlug}_{pageIndex}_{pageSize}";
            lock (_forumCacheLock)
            {
                if (_forumCache.Exists<List<ForumThreadWithCounts>>(cacheKey))
                {
                    return _forumCache.Get<List<ForumThreadWithCounts>>(cacheKey);
                }
            }

            var foundThreads = await _forumthreadsRepository.GetForumThreadsByCategorySlugAsync(categorySlug, pageIndex, pageSize);
            lock (_forumCacheLock)
            {
                if (_forumCache.Exists<List<ForumThread>>(cacheKey))
                {
                    //Just in case at the mean time some other request already filled it up!
                    //Rather do this than block  the lock for long time
                    return _forumCache.Get<List<ForumThreadWithCounts>>(cacheKey);
                }
                _forumCache.AddAbsolute(foundThreads, cacheKey, TimeSpan.FromMinutes(15));
            }
            return foundThreads;
        }

    }
}