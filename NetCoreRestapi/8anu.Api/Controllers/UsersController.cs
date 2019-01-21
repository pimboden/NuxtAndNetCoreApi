using Microsoft.AspNetCore.Mvc;
using _8anu.Api.Managers.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]/{id?}")]
    public class UsersController : Controller
    {
        private IUsersManager _usersManager;

        public UsersController(IUsersManager usersManager)
        {
            _usersManager = usersManager;

        }

        [HttpGet]
        public JsonResult GetAll()
        {
            //TODO: DO WE NEE THIS???
            // this is one way to restrict the content returned to client. 
            // https://juristr.com/blog/2012/10/lessions-learned-dont-expose-ef-entities-to-the-client-directly/
            //
            // we could also create attributes dynamically for the json serializer?
            // https://blog.rsuter.com/advanced-newtonsoft-json-dynamically-rename-or-ignore-properties-without-changing-the-serialized-class/
            // 
            // or then just ignoring Iserializer completely
            // https://stackoverflow.com/questions/27197317/json-net-is-ignoring-properties-in-types-derived-from-system-exception-why/27197432#27197432
            //
            // PID: - should this be int he manager already?
            // 
            var retval = _usersManager.GetAll().Select(u => new
            {
                u.Slug,
                u.FirstName,
                u.LastName,
                u.Gender,
                u.Country.ISO2,
            });
            JsonResult jr = new JsonResult(retval);
            return jr;
        }

        [HttpGet]
        public async Task<BasicUserProfile> GetBasicUserProfileAsync(string slug)
        {
            return await _usersManager.GetBasicUserProfileAsync(slug);
        }
    }
}