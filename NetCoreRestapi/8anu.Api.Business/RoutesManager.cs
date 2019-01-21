using System;
using System.Collections.Generic;
using System.Linq;
using Nest;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Models;
using _8anu.Api.Common.Runtime.Caching;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Api.Managers.Interfaces;
using _8anu.Api.Managers.Services;

namespace _8anu.Api.Managers
{
    public class RoutesManager: BaseManager<Route>, IRoutesManager
    {

        private readonly IRoutesRepository _routesRepository;
        private readonly IObjectCache _cragsCache;
        private readonly object _cragsCacheLock;
        private readonly IStatisticsService _statisticsService;
        private readonly IElasticService _elasticService;
        public RoutesManager(IRoutesRepository routesRepository, ICacheHandler cacheHandler, IStatisticsService statisticsService, IElasticService elasticService):base(routesRepository)
        {
            _routesRepository = routesRepository;
            _cragsCache = cacheHandler.CragsCache;
            _cragsCacheLock = cacheHandler.CragsCacheLock;
            _statisticsService = statisticsService;
            _elasticService = elasticService;
        }

        public ZlaggableWithStatistics GetZlaggableWithStatistics(string zlaggableSlug, ZlaggableCategoryEnum category, string sectorSlug)
        {
            Console.WriteLine($"get zlaggable: '{zlaggableSlug}', category: '{category}'");

            return _elasticService.GetZlaggableWithStatistics(zlaggableSlug, category, sectorSlug);
            
            /*
            var crags = _statisticsService.GetCragStatistics();
            ZlaggableWithStatistics zlaggable = null;
            zlaggable = crags
                .Where(c => c.Category.Equals(category))
                .SelectMany(c => c.Sectors)
                .SelectMany(s => s.Children)
                .SingleOrDefault(z => z.Slug.Equals(zlaggableSlug)) as ZlaggableWithStatistics;
            return zlaggable;
            */
        }

        public SearchResult GetAllForCrag(string cragSlug, string country, ZlaggableCategoryEnum category, string sectorSlug = "", int pageIndex = 0, int pageSize = 50, string sortField = "", int? minGrade = null, int? maxGrade = null)
        {
            return _elasticService.GetZlaggablesWithStatisticsForCrag(cragSlug, country, category, sectorSlug,
                pageIndex, pageSize, sortField, minGrade, maxGrade);
            /*
            var crags = _statisticsService.GetCragStatistics();
            List<ZlaggableWithStatistics> zlaggables = null;
            
            var query = crags.Single(c =>
                    c.Category.Equals(category) &&
                    c.Slug.Equals(cragSlug) &&
                    c.CountrySlug.Equals(country))
                .Sectors as IEnumerable<WithStatisticsBase>;

            if (!string.IsNullOrWhiteSpace(sectorSlug))
            {
                query = query.Where(s => s.Slug.Equals(sectorSlug));
            }
                    
            zlaggables = query
                .SelectMany(s => s.Children)
                .OrderByDescending(c => c.TotalAscents)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList().ConvertAll(x => (ZlaggableWithStatistics)x);            

            return zlaggables;
            */
        }

        public SearchResult GetAllForArea(string areaSlug, string countrySlug, int pageIndex = 0, int pageSize = 50, string sortField = "", int? minGrade = null, int? maxGrade = null)
        {
            return _elasticService.GetZlaggablesWithStatisticsForArea(areaSlug, countrySlug, pageIndex, pageSize, sortField, minGrade, maxGrade);
            /*
            var crags = _statisticsService.GetCragStatistics();
            List<ZlaggableWithStatistics> zlaggables = null;
                    
            zlaggables = crags
                .Where(c => c.Area != null && c.Area.Slug.Equals(areaSlug) && c.Area.CountrySlug.Equals(countrySlug))
                .SelectMany(c => c.Sectors)
                .SelectMany(s => s.Children)
                .OrderByDescending(c => c.TotalAscents)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList().ConvertAll(x => (ZlaggableWithStatistics)x);

            return zlaggables;
            */
        }
    }
}