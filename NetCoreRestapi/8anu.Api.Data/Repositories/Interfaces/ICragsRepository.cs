using System.Threading.Tasks;
using System.Data.Common;
using _8anu.Api.Common.DataEntities;
using _8anu.Data;
using System.Collections.Generic;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Data.Repositories.Interfaces
{
    public interface ICragsRepository: IRepository<Crag>
    {
        List<Crag> GetAllByCategory(string country = "", string category = "sportclimbing",int pageIndex = 0, int pageSize = 50);
        List<Crag> GetTrending(string country = "", int limit = 5);
        List<Crag> GetLatest(string country = "", int limit = 5);
        
        Crag Get(string slug, string country, string category);
        Task<Dictionary<int, CragWithStatistics>> GetCragsWithStatistics(Dictionary<int, AreaWithStatistics> areas);
    }
}
