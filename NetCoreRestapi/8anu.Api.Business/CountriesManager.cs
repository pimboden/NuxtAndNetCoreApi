using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Runtime.Caching;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Managers
{
    public class CountriesManager: BaseManager<Country>, ICountriesManager
    {

        private readonly ICountriesRepository _countriesRepository;
        public CountriesManager(ICountriesRepository countriesRepository, ICacheHandler cacheHandler) :base(countriesRepository, cacheHandler.CountryCache, cacheHandler.CountryCacheLock)
        {
            _countriesRepository = countriesRepository;
        }
    }
}