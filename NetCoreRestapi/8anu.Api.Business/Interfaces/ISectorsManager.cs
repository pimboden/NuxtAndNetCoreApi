using System.Collections.Generic;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Managers.Interfaces
{
    public interface ISectorsManager:IBaseManager<Sector>
    {
        List<SectorWithStatistics> GetSectorsWithStatisticsForCrag(string cragSlug, string cragCountry, ZlaggableCategoryEnum category);

        List<SectorWithStatistics> GetAllForCragWithPaging(string cragSlug, string cragCountry, ZlaggableCategoryEnum category,
            int pageIndex = 0,
            int pageSize = 50);
    }
}