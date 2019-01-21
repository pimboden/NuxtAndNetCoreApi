using _8anu.Api.Common.DataEntities;
using _8anu.Api.Data.Contexts;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace _8anu.Api.Data.Repositories
{
    public class RoutesRepository:Repository<Route>, IRoutesRepository
    {
        public RoutesRepository(DomainModelMySqlContext context) : base(context)
        {
        }

        public List<Route> GetAllForCrag(string cragSlug, string cragCountry, string cragCategory, int? sectorId, int pageIndex = 0, int pageSize = 50)
        {
            var routes = Context.Set<Route>()
                .Include(r => r.Sector)
                .Where(r => r.Sector.Crag.Slug.Equals(cragSlug) && r.Sector.Crag.Country.Slug.Equals(cragCountry) &&
                            r.Sector.Crag.Category.Equals(cragCategory))
                .AsQueryable();

            if (sectorId.HasValue)
            {
                routes = routes.Where(r => r.SectorId.Equals(sectorId));
            }
            
            routes = routes
                .OrderBy(r => r.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize);
            
            return routes.ToList();
        }
    }
}