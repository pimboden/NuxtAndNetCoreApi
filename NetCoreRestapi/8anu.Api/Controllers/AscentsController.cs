using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Enums;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AscentsController : Controller
    {
        private IAscentsManager _ascentsManager;
        public AscentsController(IAscentsManager ascentsManager)
        {
            _ascentsManager = ascentsManager;
        }

        // GET api/values
        [HttpGet("getall")]
        public List<Ascent> GetAll()
        {  
            return _ascentsManager.GetAll();
        }

        [HttpGet("getallforroute")]
        public List<Ascent> GetAllForRoute(string zlaggableSlug, string sectorSlug, ZlaggableCategoryEnum category, int pageIndex = 0, string sortField = "date_desc")
        {
            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "date_desc";
            }
            return _ascentsManager.GetAllForZlaggable(zlaggableSlug, category, sectorSlug, pageIndex, sortField);
        }
    }
}