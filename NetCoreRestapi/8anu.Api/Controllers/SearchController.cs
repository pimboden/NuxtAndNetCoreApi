using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;
using _8anu.Api.Managers.Interfaces;
using _8anu.Api.Managers.Services;

namespace _8anu.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SearchController : Controller
    {
        private readonly IElasticService _elasticService;
        public SearchController(IElasticService elasticService)
        {
            _elasticService = elasticService;
        }

        // GET api/values
        [HttpGet("")]
        public List<SearchResult> Search(string query, string category = "")
        {
            if (string.IsNullOrWhiteSpace(query))
                return null;
            
            var results = _elasticService.Search(query.Trim(), category);
            return results;
        }
    }
}