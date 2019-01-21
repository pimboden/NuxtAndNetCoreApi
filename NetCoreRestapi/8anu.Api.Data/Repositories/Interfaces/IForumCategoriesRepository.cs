using System.Collections.Generic;
using System.Threading.Tasks;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;
using _8anu.Data;

namespace _8anu.Api.Data.Repositories.Interfaces
{
    public interface IForumCategoriesRepository: ISlugRepository<ForumCategory>
    {

        Task<List<ForumCategoryWithCounts>> GetRootForumCategoryWithCountsAsync(int pageIndex = 0, int pageSize = 50);
        Task<List<ForumCategoryWithCounts>> GetForumCategoryWithCountsByParentSlugAsync(string parentSlug, int pageIndex = 0, int pageSize = 50);
    }
}
