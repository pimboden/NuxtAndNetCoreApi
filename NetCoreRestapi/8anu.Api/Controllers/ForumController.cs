using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]/{slug?}")]
    public class ForumController : Controller
    {
        private readonly IForumCategoriesManager _forumcategoriesManager;
        private readonly IForumThreadsManager _forumThreadsManager;
        private readonly IForumCommentsManager _forumcommentsManager;

        public ForumController(IForumCategoriesManager forumcategoriesManager, IForumThreadsManager forumThreadsManager, IForumCommentsManager forumcommentsManager)
        {
            _forumcategoriesManager = forumcategoriesManager;
            _forumThreadsManager = forumThreadsManager;
            _forumcommentsManager = forumcommentsManager;
        }

        [HttpGet]
        public async  Task<List<ForumCategoryWithCounts>> GetAllRootCategoriesAsync()
        {  
            //TODO: HIDE THE ID's
            return await _forumcategoriesManager.GetAllRootCategoriesAsync();
        }

        [HttpGet]
        public ForumCategory GetCategoryBySlug(string slug)
        {
            return _forumcategoriesManager.GetBySlug(slug);
        }
        [HttpGet]
        public async Task<List<ForumCategoryWithCounts>> GetSubCategoryBySlugAsync(string slug)
        {
            return await _forumcategoriesManager.GetSubCategoryByParentSlugAsync(slug);
        }
        [HttpGet]
        public async Task<List<ForumThreadWithCounts>> GetForumThreadsByCategorySlugAsync(string slug)
        {
            return await _forumThreadsManager.GetForumThreadsByCategorySlugAsync(slug);
        }

        [HttpGet()]
        public async Task<List<ForumComment>> GetLatestCommentsByCategorySlugAsync(string categorySlug)
        {
            return await _forumcommentsManager.GetLatestCommentsByCategorySlugAsync(categorySlug);
        }
        [HttpGet()]
        public async Task<List<ForumComment>> GetLatestCommentsAsync()
        {
            return await _forumcommentsManager.GetLatestCommentsAsync();
        }

        [HttpGet()]
        public async Task<ThreadDetail> GetSubcategoryThread(string categorySlug, string subcategorySlug, string threadSlug)
        {
            var threadDetail = new ThreadDetail();
           ThreadInfo threadInfo = await _forumcommentsManager.GetThreadInfo( categorySlug,  subcategorySlug,  threadSlug);
            List<ThreadComment> threadComments = await _forumcommentsManager.GetThreadComments(threadInfo.Id);
            threadDetail.ThreadInfo = threadInfo;
            threadDetail.ThreadComments = threadComments;
            return threadDetail;
        }

        [HttpGet()]
        public async Task<ThreadDetail> GetCategoryThread(string categorySlug,  string threadSlug)
        {
            var threadDetail = new ThreadDetail();
            var threadInfo = await _forumcommentsManager.GetThreadInfo(categorySlug, null, threadSlug);
            var threadComments = await _forumcommentsManager.GetThreadComments(threadInfo.Id, 0, 1000);
            threadDetail.ThreadInfo = threadInfo;
            threadDetail.ThreadComments = threadComments;
            return threadDetail;
        }
    }
}