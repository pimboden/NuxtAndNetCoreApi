using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]/{id?}")]
    public class AreasController : Controller
    {
        private IAreasManager _areasManager;
        public AreasController(IAreasManager areasManager)
        {
            _areasManager = areasManager;
        }

        [HttpGet]
        public List<AreaWithStatistics> GetAll(string country = "", int pageIndex = 0, string sortField = "totalascents_desc")
        {
            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "";
            }
            return _areasManager.GetAreasWithStatistics(country, pageIndex, sortField);
        }
        
        [HttpGet]
        public AreaWithStatistics Get(string slug, string country)
        {              
            return _areasManager.GetAreaWithStatistics(slug, country);
        }

        [HttpGet]
        public List<AreaWithStatistics> GetTrending(string country = "", int limit = 5)
        {
            return _areasManager.GetTrending(countrySlug: country, limit: limit);
        }

        [HttpGet]
        public List<AreaWithStatistics> GetLatest(string country = "", int limit = 5)
        {
            return _areasManager.GetLatest(countrySlug: country, limit: limit);
        }
    }
}