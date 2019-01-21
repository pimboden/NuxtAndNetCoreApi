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

    public class ForumCategoriesManager: BaseSlugManager<ForumCategory>, IForumCategoriesManager
    {

        private readonly IForumCategoriesRepository _forumcategoriesRepository;
        private readonly IForumThreadsRepository _forumThreadsRepository;
        private readonly IForumCommentsRepository _forumCommentsRepository;
        private readonly IObjectCache _forumCategoryCache;
        private readonly object _forumCategoryCacheLock;
        public ForumCategoriesManager(IForumCategoriesRepository forumcategoriesRepository, IForumThreadsRepository forumThreadsRepository, IForumCommentsRepository forumCommentsRepository, ICacheHandler cacheHandler) :base(forumcategoriesRepository, cacheHandler.ForumCategoryCache, cacheHandler.ForumCategoryCacheLock)
        {
            _forumcategoriesRepository = forumcategoriesRepository;
            _forumThreadsRepository = forumThreadsRepository;
            _forumCommentsRepository = forumCommentsRepository;
            _forumCategoryCache = cacheHandler.ForumCategoryCache;
            _forumCategoryCacheLock = cacheHandler.ForumCategoryCacheLock;
        }

        public async Task<List<ForumCategoryWithCounts>> GetAllRootCategoriesAsync(int pageIndex = 0, int pageSize = 50)
        {
            var cacheKey = $"RootCategories_{pageIndex}_{pageSize}";
            lock (_forumCategoryCacheLock)
            {
                if (_forumCategoryCache.Exists<List<ForumCategoryWithCounts>>(cacheKey))
                {
                    return _forumCategoryCache.Get<List<ForumCategoryWithCounts>>(cacheKey);
                }
            }
            var foundCategories = await _forumcategoriesRepository.GetRootForumCategoryWithCountsAsync();
            lock (_forumCategoryCacheLock)
            {
                if (_forumCategoryCache.Exists<List<ForumCategoryWithCounts>>(cacheKey))
                {
                    //Just in case at the mean time some other request already filled it up!
                    //Rather do this than block  the lock for long time
                    return _forumCategoryCache.Get<List<ForumCategoryWithCounts>>(cacheKey);
                }
                _forumCategoryCache.AddAbsolute(foundCategories, cacheKey, TimeSpan.FromHours(8));
            }
            return foundCategories;
        }


        public async Task<List<ForumCategoryWithCounts>> GetSubCategoryByParentSlugAsync(string parentSlug, int pageIndex = 0, int pageSize = 50)
        {
            var cacheKey = $"Categories_{parentSlug}_{pageIndex}_{pageSize}";

            lock (_forumCategoryCacheLock)
            {
                if (_forumCategoryCache.Exists<List<ForumCategoryWithCounts>>(cacheKey))
                {
                    return _forumCategoryCache.Get<List<ForumCategoryWithCounts>>(cacheKey);
                }
            }
            var foundCategories = await _forumcategoriesRepository.GetForumCategoryWithCountsByParentSlugAsync( parentSlug);
            lock (_forumCategoryCacheLock)
            {
                if (_forumCategoryCache.Exists<List<ForumCategoryWithCounts>>(cacheKey))
                {
                    //Just in case at the mean time some other request already filled it up!
                    //Rather do this than block  the lock for long time
                    return _forumCategoryCache.Get<List<ForumCategoryWithCounts>>(cacheKey);
                }
                _forumCategoryCache.AddAbsolute(foundCategories, cacheKey, TimeSpan.FromHours(8));
            }
            return foundCategories;
        }

    }
}