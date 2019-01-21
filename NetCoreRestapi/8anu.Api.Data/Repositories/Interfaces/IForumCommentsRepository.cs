using System.Collections.Generic;
using System.Threading.Tasks;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;
using _8anu.Data;

namespace _8anu.Api.Data.Repositories.Interfaces
{
    public interface IForumCommentsRepository : IRepository<ForumComment>
    {
        Task<List<ForumComment>> GetLatestCommentsByCategorySlugAsync(string categorySlug, int pageIndex = 0,
            int pageSize = 50);

        Task<ForumComment> GetLatestCommentByCategoryIdAsync(int categoryId);
        Task<ForumComment> GetLatestCommentByThreadIdAsync(int threadId);
        Task<int> GetCommentsCountByCategoryIdAsync(int categoryId);
        Task<int> GetCommentsCountByThreadIdAsync(int threadId);
        Task<List<ForumComment>> GetLatestCommentsAsync(int pageIndex = 0, int pageSize = 50);
        Task<List<ThreadComment>> GetThreadComments(int threadId, int pageIndex, int pageSize);
        Task<ThreadInfo> GetThreadInfoRootCategory(string categorySlug, string threadSlug);
        Task<ThreadInfo> GetThreadInfoSubCategory(string categorySlug, string subcategorySlug, string threadSlug);
    }
}
