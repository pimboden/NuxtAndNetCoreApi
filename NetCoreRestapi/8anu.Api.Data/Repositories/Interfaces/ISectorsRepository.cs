using System.Collections.Generic;
using System.Threading.Tasks;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;
using _8anu.Data;

namespace _8anu.Api.Data.Repositories.Interfaces
{
    public interface ISectorsRepository: IRepository<Sector>
    {
        List<Sector> GetAllForCrag(string cragSlug, string cragCountry, string cragCategory);
        List<Sector> GetAllForCragWithPaging(string cragSlug, string cragCountry, string cragCategory, int pageIndex = 0, int pageSize = 50);
        Task<Dictionary<int, SectorWithStatistics>> GetSectorsWithStatistics(Dictionary<int, CragWithStatistics> crags);
    }
}
