using Microsoft.AspNetCore.Mvc;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]/{id?}")]
    public class CacheController : Controller
    {
        private readonly ICacheManager _cacheManager;

        public CacheController(ICacheManager cacheManagerr)
        {
            _cacheManager = cacheManagerr;
        
        }

        [HttpGet]
        public bool ClearCache(string pwd)
        {
            return _cacheManager.ClearCaches(pwd);
        }
    }
}