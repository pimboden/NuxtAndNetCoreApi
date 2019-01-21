using System;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Runtime.Caching;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Api.Managers.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Nest;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Models;
using _8anu.Api.Managers.Services;

namespace _8anu.Api.Managers
{
    public class CragsManager: BaseManager<Crag>, ICragsManager
    {
        private readonly ICragsRepository _cragsRepository;
        private readonly IObjectCache _cragsCache;
        private readonly object _cragsCacheLock;
        private IStatisticsService _statisticsService;
        private IElasticService _elasticService;

        public CragsManager(ICragsRepository cragsRepository, ICacheHandler cacheHandler, IStatisticsService statisticsService, IElasticService elasticService):base(cragsRepository)
        {
            _cragsRepository = cragsRepository;
            _cragsCache = cacheHandler.CragsCache;
            _cragsCacheLock = cacheHandler.CragsCacheLock;
            _statisticsService = statisticsService;
            _elasticService = elasticService;
        }

        public List<CragWithStatistics> GetCragsWithStatisticsByCategory(ZlaggableCategoryEnum category, string countrySlug = "", int pageIndex = 0, string sortField = "", int pageSize = 50)
        {
            return _elasticService.GetCragsWithStatisticsByCategory(category, countrySlug, pageIndex, pageSize, sortField);
            
            /*
            var allCrags = _statisticsService.GetCragStatistics();
            List<CragWithStatistics> crags = null;

            var query = allCrags.Where(c => c.Category.Equals(category));

            if (!string.IsNullOrWhiteSpace(countrySlug))
            {
                query = query.Where(c => c.CountrySlug.Equals(countrySlug));
            }
            
            crags = query.OrderByDescending(c => c.TotalAscents)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();

            return crags;
            */
        }

        public List<CragWithStatistics> GetCragsWithStatisticsForArea(string areaSlug, string areaCountrySlug, int pageIndex = 0, string sortField = "", int pageSize = 50)
        {
            return _elasticService.GetCragsWithStatisticsForArea(areaSlug, areaCountrySlug, pageIndex, pageSize, sortField);
            
            /*
            var allCrags = _statisticsService.GetCragStatistics();
            List<CragWithStatistics> crags = null;

            crags = allCrags
                .Where(c => c.Area != null && c.Area.Slug.Equals(areaSlug) && c.Area.CountrySlug.Equals(areaCountrySlug))
                .OrderByDescending(c => c.TotalAscents)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();

            return crags;
            */
        }

        public List<Crag> GetAllByCategory(string countrySlug = "", string category = "", int pageIndex = 0, int pageSize = 50)
        {
            Console.WriteLine($"get crags for countrySlug: '{countrySlug}', category: '{category}', pageIndex: '{pageIndex}', pageSize: '{pageSize}'");

            return _cragsRepository.GetAllByCategory(countrySlug, category, pageIndex, pageSize);
        }

        public CragWithStatistics GetCragWithStatistics(string cragSlug, string countrySlug, ZlaggableCategoryEnum category)
        {
            return _elasticService.GetCragWithStatistics(cragSlug, countrySlug, category);
            //_elasticService.GetCragsWithStatisticsByCategory()
            /*
            Console.WriteLine($"get crag: '{cragSlug}', category: '{category}', countrySlug: '{countrySlug}'");
            var allCrags = _statisticsService.GetCragStatistics();
            var crag = allCrags.SingleOrDefault(c => c.Category.Equals(category) && c.Slug.Equals(cragSlug) && c.CountrySlug.Equals(countrySlug));
            return crag;
            */
        }

        public List<CragWithStatistics> GetTrending(string countrySlug = "", int limit = 5)
        {
            return _elasticService.GetTrendingCrags(countrySlug, limit);

            /*
            var allCrags = _statisticsService.GetCragStatistics();
            List<CragWithStatistics> crags = null;
            var query = (IEnumerable<CragWithStatistics>) allCrags;
            
            if (!string.IsNullOrWhiteSpace(countrySlug))
            {
                query = query.Where(c => c.CountrySlug.Equals(countrySlug));
            }
            
            crags = query
                .OrderByDescending(c => c.TotalAscents1Year)
                .Take(limit)
                .ToList();

            return crags;
            */
        }

        public List<CragWithStatistics> GetLatest(string countrySlug = "", int limit = 5) 
        {
            return _elasticService.GetLatestCrags(countrySlug, limit);
            /*
            var allCrags = _statisticsService.GetCragStatistics();
            List<CragWithStatistics> crags = null;
            
            var query = (IEnumerable<CragWithStatistics>) allCrags;
            
            if (!string.IsNullOrWhiteSpace(countrySlug))
            {
                query = query.Where(c => c.CountrySlug.Equals(countrySlug));
            }
            
            crags = query
                .OrderByDescending(c => c.DateCreated)
                .Take(limit)
                .ToList();

            return crags;
            */
        }
    }
}