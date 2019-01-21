using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]/{id?}")]
    public class NewsController : Controller
    {
        private INewsManager _newsManager;
        public NewsController(INewsManager newsManager)
        {
            _newsManager = newsManager;
        }
        // GET api/values
        [HttpGet]
        [Authorize]
        public List<NewsItem> GetAll()
        {
            var user = HttpContext.User;
            return _newsManager.GetAll();
        }

        // GET api/values
        [HttpGet]
        [Authorize]
        public List<NewsItem> GetLatest()
        {
            var user = HttpContext.User;
            return _newsManager.GetLatestNews();
        }
      
    }
}