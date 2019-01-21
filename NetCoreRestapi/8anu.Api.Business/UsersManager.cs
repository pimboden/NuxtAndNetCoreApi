using System.Threading.Tasks;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Managers
{
    public class UsersManager: BaseManager<User>, IUsersManager
    {
        private readonly IUsersRepository _usersRepository;
        public UsersManager(IUsersRepository usersRepository):base(usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<BasicUserProfile> GetBasicUserProfileAsync(string userSlug)
        {
            return _usersRepository.GetBasicUserProfileAsync(userSlug);
        }
    }
}