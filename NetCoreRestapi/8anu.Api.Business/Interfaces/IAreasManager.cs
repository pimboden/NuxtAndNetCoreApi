using System.Collections.Generic;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Managers.Interfaces
{
    public interface IAreasManager:IBaseManager<Area>
    {
        List<AreaWithStatistics> GetAreasWithStatistics(string countrySlug = "", int pageIndex = 0, string sortField = "", int pageSize = 50);
        List<AreaWithStatistics> GetTrending(string countrySlug = "", int limit = 5);
        List<AreaWithStatistics> GetLatest(string countrySlug = "", int limit = 5);
        AreaWithStatistics GetAreaWithStatistics(string areaSlug, string countrySlug);
    }
}