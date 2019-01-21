using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nest;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Models;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]/{id?}")]
    public class CragsController : Controller
    {
        private ICragsManager _cragsManager;
        public CragsController(ICragsManager cragsManager)
        {
            _cragsManager = cragsManager;
        }

        [HttpGet]
        public List<CragWithStatistics> GetAll(ZlaggableCategoryEnum category, string country = "", int pageIndex = 0, string sortField = "totalascents_desc")
        {  
            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "totalascents_desc";
            }
            return _cragsManager.GetCragsWithStatisticsByCategory(category, country, pageIndex, sortField);
        }
        
        [HttpGet]
        public List<CragWithStatistics> GetAllForArea(string areaSlug, string countrySlug, int pageIndex = 0, string sortField = "totalascents_desc")
        {    
            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "totalascents_desc";
            }
            return _cragsManager.GetCragsWithStatisticsForArea(areaSlug, countrySlug, pageIndex, sortField);
        }
        
        [HttpGet]
        public CragWithStatistics Get(string slug, string country, ZlaggableCategoryEnum category = ZlaggableCategoryEnum.Sportclimbing)
        {              
            return _cragsManager.GetCragWithStatistics(slug, country, category);
        }

        [HttpGet]
        public List<CragWithStatistics> GetTrending(string country = "", int limit = 5)
        {
            return _cragsManager.GetTrending(countrySlug: country, limit: limit);
        }

        [HttpGet]
        public List<CragWithStatistics> GetLatest(string country = "", int limit = 5)
        {
            return _cragsManager.GetLatest(countrySlug: country, limit: limit);
        }
    }
}