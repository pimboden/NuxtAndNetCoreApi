using System;
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
    public class RoutesController : Controller
    {
        private IRoutesManager _routesManager;
        public RoutesController(IRoutesManager routesManager)
        {
            _routesManager = routesManager;
        }

        // GET api/values
        [HttpGet("getall")]
        public List<Route> GetAll()
        {  
            return _routesManager.GetAll();
        }
        
        [HttpGet("get")]
        public ZlaggableWithStatistics Get(string zlaggableSlug, ZlaggableCategoryEnum category, string sectorSlug)
        {
            return _routesManager.GetZlaggableWithStatistics(zlaggableSlug, category, sectorSlug);
        }
        
        [HttpGet("getallforcrag")]
        public SearchResult GetAllForCrag(string cragSlug, string cragCountry, ZlaggableCategoryEnum category, string sectorSlug = "", int pageIndex = 0, int pageSize = 50, string sortField = "totalascents_desc", string grade = "" )
        {              
            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "totalascents_desc";
            }

            int? minGrade = null;
            int? maxGrade = null;
            if (!string.IsNullOrEmpty(grade))
            {
                var arr = grade.Split(',');
                minGrade = Convert.ToInt32(arr[0]);
                maxGrade = arr.Length > 1 ? Convert.ToInt32(arr[1]) : minGrade;
                
            }
            
            return _routesManager.GetAllForCrag(cragSlug, cragCountry, category, sectorSlug, pageIndex, pageSize, sortField, minGrade, maxGrade);
        }
        
        [HttpGet("getallforarea")]
        public SearchResult GetAllForArea(string areaSlug, string countrySlug, int pageIndex = 0, int pageSize = 50, string sortField = "totalascents_desc", string grade = "" )
        {              
            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "totalascents_desc";
            }
            
            int? minGrade = null;
            int? maxGrade = null;
            if (!string.IsNullOrEmpty(grade))
            {
                var arr = grade.Split(',');
                minGrade = Convert.ToInt32(arr[0]);
                maxGrade = arr.Length > 1 ? Convert.ToInt32(arr[1]) : minGrade;
                
            }
            
            return _routesManager.GetAllForArea(areaSlug, countrySlug, pageIndex, pageSize, sortField, minGrade, maxGrade);
        }
    }
}