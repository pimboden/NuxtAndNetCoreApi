using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]/{id?}")]
    public class CountriesController : Controller
    {
        private ICountriesManager _countriesManager;
        public CountriesController(ICountriesManager countriesManager)
        {
            _countriesManager = countriesManager;
        }
        // GET api/values
        [HttpGet]
        public List<Country> GetAll()
        {  
            return _countriesManager.GetAll();
        }
    }
}