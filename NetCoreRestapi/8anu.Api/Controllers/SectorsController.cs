using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Models;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SectorsController : Controller
    {
        private ISectorsManager _sectorsManager;
        public SectorsController(ISectorsManager sectorsManager)
        {
            _sectorsManager = sectorsManager;
        }

        // GET api/values
        [HttpGet("getall")]
        public List<Sector> GetAll()
        {  
            return _sectorsManager.GetAll();
        }
        
        [HttpGet("getallforcrag")]
        public List<SectorWithStatistics> GetAllForCrag(string cragSlug, string countrySlug, ZlaggableCategoryEnum category)
        {  
            return _sectorsManager.GetSectorsWithStatisticsForCrag(cragSlug, countrySlug, category);
        }
        
        [HttpGet("getallforcragwithpaging")]
        public List<SectorWithStatistics> GetAllForCragWithPaging(string cragSlug, string countrySlug, ZlaggableCategoryEnum category, int pageIndex = 0, int pageSize = 50)
        {  
            return _sectorsManager.GetAllForCragWithPaging(cragSlug, countrySlug, category, pageIndex, pageSize);
        }
    }
}