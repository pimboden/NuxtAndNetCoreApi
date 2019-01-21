using System.Collections.Generic;
using System.Threading.Tasks;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;
using _8anu.Data;

namespace _8anu.Api.Data.Repositories.Interfaces
{
    public interface IForumThreadsRepository: IRepository<ForumThread>
    {
        Task<int> GetThreadsCountByCategoryIdAsync(int categorId);
        Task<List<ForumThreadWithCounts>> GetForumThreadsByCategorySlugAsync(string categorySlug, int pageIndex=0, int pageSize =50);
    }
}
