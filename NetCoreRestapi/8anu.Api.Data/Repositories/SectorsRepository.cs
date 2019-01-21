using System.Collections.Generic;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Data.Contexts;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Data.Repositories
{
    public class SectorsRepository:Repository<Sector>, ISectorsRepository
    {
        public SectorsRepository(DomainModelMySqlContext context) : base(context)
        {
        }

        public List<Sector> GetAllForCrag(string cragSlug, string cragCountry, string cragCategory)
        {
            var sectors = Context.Set<Sector>()
                .Where(s => s.Crag.Slug.Equals(cragSlug) && s.Crag.Country.Slug.Equals(cragCountry) &&
                            s.Crag.Category.Equals(cragCategory))
                .OrderBy(c => c.Name);
            
            return sectors.ToList();
        }
        
        public List<Sector> GetAllForCragWithPaging(string cragSlug, string cragCountry, string cragCategory, int pageIndex = 0, int pageSize = 50)
        {
            var sectors = Context.Set<Sector>()
                .Where(s => s.Crag.Slug.Equals(cragSlug) && s.Crag.Country.Slug.Equals(cragCountry) &&
                            s.Crag.Category.Equals(cragCategory))
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize);
            
            return sectors.ToList();
        }

        public async Task<Dictionary<int, SectorWithStatistics>> GetSectorsWithStatistics(Dictionary<int, CragWithStatistics> crags)
        {
            var rows = new Dictionary<int, SectorWithStatistics>();
            var conn = Context.Database.GetDbConnection();
            
            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    const string query = @"select sectors.id, sectors.name, sectors.slug, crags.id
from sectors
inner join crags on crags.id = sectors.crag_id;";
                    
                    command.CommandText = query;
                    var reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var id = reader.GetInt32(0);
                            var name = reader.GetString(1);
                            var slug = reader.GetString(2);
                            var cragId = reader.GetInt32(3);
                            
                            
                            var row = new SectorWithStatistics()
                            {
                                DatabaseId = id,
                                Name = name,
                                Slug = slug
                            };

                            var crag = crags[cragId];
                            crag.Sectors.Add(row);
                            
                            row.Crag = crag;
                            row.CragId = crag.DatabaseId;
                            row.CragSlug = crag.Slug;
                            row.CragName = crag.Name;
                            row.AreaId = crag.AreaId;
                            row.AreaSlug = crag.AreaSlug;
                            row.AreaName = crag.AreaName;
                            row.Category = crag.Category;
                            row.CountryName = crag.CountryName;
                            row.CountrySlug = crag.CountrySlug;
                            
                            rows.Add(row.DatabaseId, row);
                        }
                    }
                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }
    }
}