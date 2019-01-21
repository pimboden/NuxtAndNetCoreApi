using System;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Data.Contexts;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Data.Repositories
{
    public class CragsRepository:Repository<Crag>, ICragsRepository
    {
        public CragsRepository(DomainModelMySqlContext context) : base(context)
        {
        }

        public List<Crag> GetAllByCategory(string country = "", string category = "", int pageIndex = 0, int pageSize = 50)
        {
            var crags = Context.Set<Crag>().AsQueryable();

            if (category.Length > 0)
            {
                crags = crags.Where(c => c.Category.Equals(category));
            }

            if (country.Length > 0)
            {
                crags = crags.Where(c => c.Country.Slug.Equals(country));
            }

            crags = crags.OrderBy(c => c.Name)
                         .Skip(pageIndex * pageSize)
                         .Take(pageSize)
                         .Include(c => c.Country);
            
            return crags.ToList();
        }

        public Crag Get(string slug, string country, string category)
        {
            var crag = Context.Set<Crag>()
                .Include(c => c.Area)
                .Include(c => c.Country)
                .SingleOrDefault(c => c.Slug.Equals(slug)
                                      && c.Category.Equals(category)
                                      && c.Country.Slug.Equals(country));
                

            return crag;
        }

        public async Task<Dictionary<int, CragWithStatistics>> GetCragsWithStatistics(Dictionary<int, AreaWithStatistics> areas)
        {
            var rows = new Dictionary<int, CragWithStatistics>();
            var conn = Context.Database.GetDbConnection();
            
            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    const string query =
                        @"select crags.id, crags.name, crags.slug, crags.category, crags.date_created, crags.area_id, countries.slug `country_slug`, countries.name `country_name`
from crags
inner join countries on countries.id = crags.country_id";
                    
                    command.CommandText = query;
                    var reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var id = reader.GetInt32(0);
                            var name = reader.GetString(1);
                            var slug = reader.GetString(2);
                            var category = Enum.Parse<ZlaggableCategoryEnum>(reader.GetString(3), true);
                            var dateCreated = reader.GetDateTime(4);
                            var areaId = reader[5] as int? ?? 0;
                            
                            var countrySlug = reader.GetString(6);
                            var countryName = reader.GetString(7);
                            
                            var row = new CragWithStatistics
                            {
                                DatabaseId = id,
                                Name = name,
                                Slug = slug,
                                Category = category,
                                DateCreated = dateCreated,
                                CountrySlug = countrySlug,
                                CountryName = countryName
                            };

                            if (areaId > 0)
                            {
                                var area = areas[areaId];
                                area.Crags.Add(row);
                                
                                row.Parent = area;
                                row.AreaId = area.DatabaseId;
                                row.AreaSlug = area.Slug;
                                row.AreaName = area.Name;
                            }
                            
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

        public List<Crag> GetTrending(string country = "", int limit = 5)
        {
            var crags = Context.Set<Crag>().AsQueryable();

            if (country.Length > 0)
            {
                crags = crags.Where(c => c.Country.Slug.Equals(country));
            }

            crags = crags.OrderByDescending(c => c.DateCreated)
                         .Take(limit)
                         .Include(c => c.Country);

            return crags.ToList();
        }

        public List<Crag> GetLatest(string country = "", int limit = 5)
        {
            var crags = Context.Set<Crag>().AsQueryable();

            if (country.Length > 0)
            {
                crags = crags.Where(c => c.Country.Slug.Equals(country));
            }

            crags = crags.OrderByDescending(c => c.DateCreated)
                         .Take(limit)
                         .Include(c => c.Country);

            return crags.ToList();
        }
    }
}