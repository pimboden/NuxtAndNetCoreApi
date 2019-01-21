using _8anu.Api.Common.DataEntities;
using System.Collections.Generic;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Managers.Interfaces
{
    public interface ICragsManager:IBaseManager<Crag>
    {
        List<CragWithStatistics> GetCragsWithStatisticsByCategory(ZlaggableCategoryEnum category, string countrySlug = "", int pageIndex = 0, string sortField = "", int pageSize = 50);

        List<CragWithStatistics> GetCragsWithStatisticsForArea(string areaSlug, string areaCountrySlug,
            int pageIndex = 0, string sortField = "", int pageSize = 50);
        List<Crag> GetAllByCategory(string countrySlug = "", string category = "", int pageIndex = 0, int pageSize = 50);
        List<CragWithStatistics> GetTrending(string countrySlug = "", int limit = 5);
        List<CragWithStatistics> GetLatest(string countrySlug = "", int limit = 5);
        
        
        CragWithStatistics GetCragWithStatistics(string cragSlug, string countrySlug, ZlaggableCategoryEnum category);
    }
}