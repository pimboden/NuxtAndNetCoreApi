using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;
using _8anu.Api.Common.Runtime.Caching;
using _8anu.Api.Data.Repositories.Interfaces;
using Hangfire;

namespace _8anu.Api.Managers.Services
{
    
    public class StatisticsService : IStatisticsService
    {
        private readonly IAreasRepository _areasRepository;
        private readonly ICragsRepository _cragsRepository;
        private readonly ISectorsRepository _sectorsRepository;
        private readonly IAscentsRepository _ascentsRepository;
        private readonly IObjectCache _cragsCache;
        private readonly object _cragsCacheLock;
        private readonly IElasticService _elasticService;
        private const string CragCacheKey = "crags";
        
        public StatisticsService(IAreasRepository areasRepository, 
            ICragsRepository cragsRepository, 
            ISectorsRepository sectorsRepository, 
            IAscentsRepository ascentsRepository,
            ICacheHandler cacheHandler,
            IElasticService elasticService)
        {
            _areasRepository = areasRepository;
            _cragsRepository = cragsRepository;
            _sectorsRepository = sectorsRepository;
            _ascentsRepository = ascentsRepository;
            _cragsCache = cacheHandler.CragsCache;
            _cragsCacheLock = cacheHandler.CragsCacheLock;
            _elasticService = elasticService;
        }

        
        public async Task<bool> CreateStatistics()
        {
            /*
            lock (_cragsCacheLock)
            {
                if (_cragsCache.Exists<Dictionary<int, CragWithStatistics>>(CragCacheKey))
                {
                    return false;
                }
            }
            */
            
            var timer = Stopwatch.StartNew();
            Console.WriteLine("started loading statistics...");
            
            // load areas
            Console.WriteLine("start loading areas");
            var areas = await _areasRepository.GetAreasWithStatistics();
            Console.WriteLine("end loading areas");
            
            // load crags
            Console.WriteLine("start loading crags");
            var crags = await _cragsRepository.GetCragsWithStatistics(areas);
            Console.WriteLine("end loading crags");
            
            // load sectors
            Console.WriteLine("start loading sectors");
            var sectors = await _sectorsRepository.GetSectorsWithStatistics(crags);
            Console.WriteLine("end loading sectors");

            
            
            // load zlaggables
            Console.WriteLine("start loading routes & ascents");
            var zlaggables = await _ascentsRepository.GetZlaggablesWithStatistics(sectors);
            Console.WriteLine("end loading routes & ascents");


            // go from down to up and calculate totals...
            foreach (var sector in sectors.Values)
            {
                sector.CalculateTotals();
            }

            foreach (var crag in crags.Values)
            {
                crag.CalculateTotals();
            }

            foreach (var area in areas.Values)
            {
                area.CalculateTotals();
            }
            
            VerifyTotals(areas);
            
            timer.Stop();
            var timespan = timer.Elapsed;
            
            var msg = "Completed loading statistics! took " + String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);
            Console.WriteLine(msg);
            
            // save crags to cache
            /*
            lock (_cragsCacheLock)
            {
                if (!_cragsCache.Exists<Dictionary<int, CragWithStatistics>>(CragCacheKey))
                {
                    _cragsCache.AddSliding(crags, CragCacheKey, TimeSpan.FromDays(5));
                }
            }
            */
            
            // load all ascents to elasticsearchindex
            
            _elasticService.CreateElasticSearchIndexesForStatistics(areas, crags, sectors, zlaggables);
            // CreateStatisticsForAscents(zlaggables);
            
            return true;
        }

        public void CreateStatisticsForAscents(Dictionary<string, ZlaggableWithStatistics> zlaggables)
        {
            Console.WriteLine("get ascents from DB");
            var ascents = _ascentsRepository.GetAscentsWithUserInfo(zlaggables);
            Console.WriteLine("got ascents from DB");
            _elasticService.CreateElasticSearchIndexForAscents(ascents);
        }

        private void VerifyTotals(Dictionary<int, AreaWithStatistics> areas)
        {
            var allGood = true;
            foreach (var area in areas.Values)
            {
                var sumOfSeason = area.Season.Sum();
                if (area.TotalAscents != sumOfSeason)
                {
                    Console.WriteLine("Sum of Seasons don't match for area: " + area.Name + " - " + area.DatabaseId.ToString());
                    allGood = false;
                }

                var sumOfGrades = area.Grades.Values.Sum();
                if (area.TotalZlaggables != sumOfGrades)
                {
                    Console.WriteLine("Sum of Grades don't match for area: " + area.Name + " - " + area.DatabaseId.ToString());
                    allGood = false;
                }   
            }
            
            if (allGood)
            {
                Console.WriteLine("all seasons and grades match!!!!");
            }
        }
    }
}