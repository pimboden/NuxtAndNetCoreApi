using System.Threading.Tasks;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;
using _8anu.Data;

namespace _8anu.Api.Data.Repositories.Interfaces
{
    public interface IUsersRepository: IRepository<User>
    {
        Task<BasicUserProfile> GetBasicUserProfileAsync(string userSlug);
    }
}
