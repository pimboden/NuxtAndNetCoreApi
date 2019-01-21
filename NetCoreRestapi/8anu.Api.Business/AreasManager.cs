using System;
using System.Collections.Generic;
using System.Linq;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;
using _8anu.Api.Common.Runtime.Caching;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Api.Managers.Interfaces;
using _8anu.Api.Managers.Services;

namespace _8anu.Api.Managers
{
    public class AreasManager: BaseManager<Area>, IAreasManager
    {

        private readonly IAreasRepository _areasRepository;
        private readonly IObjectCache _cragsCache;
        private readonly object _cragsCacheLock;
        private readonly IStatisticsService _statisticsService;
        private readonly IElasticService _elasticService;
        public AreasManager(IAreasRepository areasRepository, ICacheHandler cacheHandler, IStatisticsService statisticsService, IElasticService elasticService):base(areasRepository)
        {
            _areasRepository = areasRepository;
            _cragsCache = cacheHandler.CragsCache;
            _cragsCacheLock = cacheHandler.CragsCacheLock;
            _statisticsService = statisticsService;
            _elasticService = elasticService;
        }

        public List<AreaWithStatistics> GetAreasWithStatistics(string countrySlug = "", int pageIndex = 0, string sortField = "", int pageSize = 50)
        {
            return _elasticService.GetAreasWithStatistics(countrySlug, pageIndex, pageSize, sortField);
        }

        public List<AreaWithStatistics> GetTrending(string countrySlug = "", int limit = 5)
        {
            return _elasticService.GetTrendingAreas(countrySlug, limit);
        }

        public List<AreaWithStatistics> GetLatest(string countrySlug = "", int limit = 5)
        {
            return _elasticService.GetLatestAreas(countrySlug, limit);
            
        }

        public AreaWithStatistics GetAreaWithStatistics(string areaSlug, string countrySlug)
        {
            return _elasticService.GetAreaWithStatistics(areaSlug, countrySlug);
            
        }
    }
}