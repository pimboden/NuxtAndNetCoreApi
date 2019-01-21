using System.Threading.Tasks;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Managers.Interfaces
{
    public interface IUsersManager:IBaseManager<User>
    {
        Task<BasicUserProfile> GetBasicUserProfileAsync(string userSlug);
    }
}