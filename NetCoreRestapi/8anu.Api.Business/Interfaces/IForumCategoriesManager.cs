using System.Collections.Generic;
using System.Threading.Tasks;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Managers.Interfaces
{
    public interface IForumCategoriesManager:IBaseSlugManager<ForumCategory>
    {
        Task<List<ForumCategoryWithCounts>> GetAllRootCategoriesAsync(int pageIndex = 0, int pageSize = 50);

        Task<List<ForumCategoryWithCounts>> GetSubCategoryByParentSlugAsync(string parentSlug, int pageIndex = 0,
            int pageSize = 50);


    }
}