using _8anu.Api.Common.DataEntities;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Managers
{
    public class GradingSystemsManager: BaseManager<GradingSystem>, IGradingSystemsManager
    {

        private readonly IGradingSystemsRepository _gradingsystemsRepository;
        public GradingSystemsManager(IGradingSystemsRepository gradingsystemsRepository):base(gradingsystemsRepository)
        {
            _gradingsystemsRepository = gradingsystemsRepository;
        }
    }
}