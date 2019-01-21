using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Nest;
using _8anu.Api.Common.Models;
using Newtonsoft;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Enums;

namespace _8anu.Api.Managers.Services
{
    public interface IElasticService
    {
        bool AreIndexesCreated { get; }
        void CreateElasticSearchIndexesForStatistics(Dictionary<int, AreaWithStatistics> areas, 
            Dictionary<int, CragWithStatistics> crags,
            Dictionary<int, SectorWithStatistics> sectors,
            Dictionary<string, ZlaggableWithStatistics> zlaggables);
        List<SearchResult> Search(string query, string category);
        void CreateElasticSearchIndexForAscents(HashSet<AscentWithUserInfo> ascents);
        
        
        // AREAS
        AreaWithStatistics GetAreaWithStatistics(string areaSlug, string countrySlug= "");
        List<AreaWithStatistics> GetAreasWithStatistics(string countrySlug = "", int pageIndex = 0, int pageSize = 50, string sortField = "");
        List<AreaWithStatistics> GetTrendingAreas(string countrySlug = "", int limit = 5);
        List<AreaWithStatistics> GetLatestAreas(string countrySlug = "", int limit = 5);
        
        
        // CRAGS
        CragWithStatistics GetCragWithStatistics(string cragSlug, string countrySlug, ZlaggableCategoryEnum category);
        List<CragWithStatistics> GetCragsWithStatisticsByCategory(ZlaggableCategoryEnum category,
            string countrySlug = "", int pageIndex = 0, int pageSize = 50, string sortField = "");

        List<CragWithStatistics> GetTrendingCrags(string countrySlug = "", int limit = 5);
        List<CragWithStatistics> GetLatestCrags(string countrySlug = "", int limit = 5);

        List<CragWithStatistics> GetCragsWithStatisticsForArea(string areaSlug, string countrySlug,
            int pageIndex = 0, int pageSize = 50, string SortField = "");
        
        // SECTORS
        List<SectorWithStatistics> GetSectorsWithStatisticsForCrag(string cragSlug, string countrySlug, ZlaggableCategoryEnum category);

        List<SectorWithStatistics> GetSectorsWithStatisticsForCragWithPaging(string cragSlug, string cragCountry, ZlaggableCategoryEnum category,
            int pageIndex = 0,
            int pageSize = 50);
        
        
        // ZLAGGABLES
        ZlaggableWithStatistics GetZlaggableWithStatistics(string zlaggableSlug, ZlaggableCategoryEnum category, string sectorSlug);

        SearchResult GetZlaggablesWithStatisticsForCrag(string cragSlug, string countrySlug,
            ZlaggableCategoryEnum category, string sectorSlug = "", int pageIndex = 0, int pageSize = 50, string sortField = "", int? minGrade = null, int? maxGrade = null);

        SearchResult GetZlaggablesWithStatisticsForArea(string areaSlug, string countrySlug,
            int pageIndex = 0, int pageSize = 50, string sortField = "", int? minGrade = null, int? maxGrade = null);
    }
}