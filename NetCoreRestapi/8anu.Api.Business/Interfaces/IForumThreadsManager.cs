using System.Collections.Generic;
using System.Threading.Tasks;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Managers.Interfaces
{
    public interface IForumThreadsManager:IBaseManager<ForumThread>
    {
        Task<List<ForumThreadWithCounts>> GetForumThreadsByCategorySlugAsync(string categorySlug, int pageIndex = 0, int pageSize = 50);
    }
}