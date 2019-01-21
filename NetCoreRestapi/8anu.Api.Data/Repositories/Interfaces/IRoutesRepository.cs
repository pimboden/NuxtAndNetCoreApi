using _8anu.Api.Common.DataEntities;
using _8anu.Data;
using System.Collections.Generic;

namespace _8anu.Api.Data.Repositories.Interfaces
{
    public interface IRoutesRepository: IRepository<Route>
    {
        List<Route> GetAllForCrag(string cragSlug, string cragCountry, string cragCategory, int? sectorId, int pageIndex = 0, int pageSize = 50);
    }
}
