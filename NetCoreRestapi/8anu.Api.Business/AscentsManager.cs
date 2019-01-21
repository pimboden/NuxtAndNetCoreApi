using System.Collections.Generic;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Enums;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Api.Managers.Interfaces;
using _8anu.Api.Managers.Services;

namespace _8anu.Api.Managers
{
    public class AscentsManager: BaseManager<Ascent>, IAscentsManager
    {

        private readonly IAscentsRepository _ascentsRepository;
        private readonly IElasticService _elasticService;
        public AscentsManager(IAscentsRepository ascentsRepository, IElasticService elasticService):base(ascentsRepository)
        {
            _ascentsRepository = ascentsRepository;
            _elasticService = elasticService;
        }

        public List<Ascent> GetAllForZlaggable(string zlaggableSlug, ZlaggableCategoryEnum category, string sectorSlug, int pageIndex = 0, string sortField = "", int pageSize = 50)
        {
            // get zlaggable from elasticsearch
            var zlaggable = _elasticService.GetZlaggableWithStatistics(zlaggableSlug, category, sectorSlug);
            if (zlaggable == null) return null;

            /*
            _elasticService.GetAscentsForZlaggable(zlaggable.DatabaseId, zlaggable.Category, pageIndex, pageSize,
                sortField);
            */
            
            return _ascentsRepository.GetAllForZlaggable(zlaggable.DatabaseId, zlaggable.Category, pageIndex, pageSize, sortField);
        }
    }
}