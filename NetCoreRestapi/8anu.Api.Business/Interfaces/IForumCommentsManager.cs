using System.Collections.Generic;
using System.Threading.Tasks;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Managers.Interfaces
{
    public interface IForumCommentsManager:IBaseManager<ForumComment>
    {
        Task<List<ForumComment>> GetLatestCommentsByCategorySlugAsync(string categorySlug, int pageIndex = 0,
            int pageSize = 50);
        Task<List<ForumComment>> GetLatestCommentsAsync(int pageIndex = 0, int pageSize = 50);
        Task<ThreadInfo> GetThreadInfo(string categorySlug, string subcategorySlug, string threadSlug);
        Task<List<ThreadComment>> GetThreadComments(int threadInfoId, int pageIndex = 0, int pageSize = 50);
    }
}