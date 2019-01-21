using System.Collections.Generic;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Models;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Api.Managers.Interfaces;
using _8anu.Api.Managers.Services;

namespace _8anu.Api.Managers
{
    public class SectorsManager: BaseManager<Sector>, ISectorsManager
    {

        private readonly ISectorsRepository _sectorsRepository;
        private readonly IElasticService _elasticService;
        
        public SectorsManager(ISectorsRepository sectorsRepository, IElasticService elasticService):base(sectorsRepository)
        {
            _sectorsRepository = sectorsRepository;
            _elasticService = elasticService;
        }


        public List<SectorWithStatistics> GetSectorsWithStatisticsForCrag(string cragSlug, string cragCountry, ZlaggableCategoryEnum category)
        {
            return _elasticService.GetSectorsWithStatisticsForCrag(cragSlug, cragCountry, category);
            // return _sectorsRepository.GetSectorsWithStatisticsForCrag(cragSlug, cragCountry, cragCategory);
        }

        public List<SectorWithStatistics> GetAllForCragWithPaging(string cragSlug, string cragCountry, ZlaggableCategoryEnum category, int pageIndex = 0,
            int pageSize = 50)
        {
            return _elasticService.GetSectorsWithStatisticsForCragWithPaging(cragSlug, cragCountry, category, pageIndex,
                pageSize);
            // return _sectorsRepository.GetAllForCragWithPaging(cragSlug, cragCountry, cragCategory, pageIndex, pageSize);
        }
    }
}