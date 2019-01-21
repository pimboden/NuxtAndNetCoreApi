using System.Collections.Generic;
using Nest;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Managers.Interfaces
{
    public interface IRoutesManager:IBaseManager<Route>
    {
        ZlaggableWithStatistics GetZlaggableWithStatistics(string zlaggableSlug, ZlaggableCategoryEnum category, string sectorSlug);
        SearchResult GetAllForCrag(string cragSlug, string country, ZlaggableCategoryEnum category, string sectorSlug = "", int pageIndex = 0, int pageSize = 50, string sortField = "", int? minGrade = null, int? maxGrade = null);
        SearchResult GetAllForArea(string areaSlug, string countrySlug, int pageIndex = 0, int pageSize = 50, string sortField = "", int? minGrade = null, int? maxGrade = null);
    }
}