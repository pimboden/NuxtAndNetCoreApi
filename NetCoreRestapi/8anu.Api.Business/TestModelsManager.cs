using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Runtime.Caching;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Api.Managers.Interfaces;
using _8anu.Api.Managers.Services;

namespace _8anu.Api.Managers

{
    public class TestModelsManager : BaseManager<TestModel>, ITestModelsManager
    {
        private readonly ITestModelsRepository _testModelsRepository;

        public TestModelsManager(ITestModelsRepository testModelsRepository, ICacheHandler cacheHandler):base(testModelsRepository, cacheHandler.TestModelCache, cacheHandler.TestModelCacheLock)
        {
            _testModelsRepository = testModelsRepository;
        }
    }
}
