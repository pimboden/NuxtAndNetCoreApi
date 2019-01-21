using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;
using _8anu.Api.Data.Contexts;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Data;

namespace _8anu.Api.Data.Repositories
{
    public class AreasRepository:Repository<Area>, IAreasRepository
    {
        public AreasRepository(DomainModelMySqlContext context) : base(context)
        {
        }

        public async Task<Dictionary<int, AreaWithStatistics>> GetAreasWithStatistics()
        {
            var rows = new Dictionary<int, AreaWithStatistics>();
            var conn = Context.Database.GetDbConnection();
            
            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    const string query = @"select areas.id, areas.name, areas.date_created, countries.slug `country_slug`, countries.name `country_name`, areas.slug
                    from areas
                    inner join countries on countries.id = areas.country_id;";
                    
                    command.CommandText = query;
                    var reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var id = reader.GetInt32(0);
                            var name = reader.GetString(1);
                            var dateCreated = reader.GetDateTime(2);
                            var countrySlug = reader.GetString(3);
                            var countryName = reader.GetString(4);
                            var areaSlug = reader.GetString(5);
                            
                            var row = new AreaWithStatistics
                            {
                                DatabaseId = id,
                                Name = name,
                                DateCreated = dateCreated,
                                CountrySlug = countrySlug,
                                CountryName = countryName,
                                Slug = areaSlug
                            };
                            
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