using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;
using _8anu.Data.Migration.Model;
using System.Linq;
using _8anu.Data.Migration.Utilities;
using Country = _8anu.Api.Common.DataEntities.Country;
using System.IO;
using System.Text;

namespace _8anu.Data.Migration.Generators
{
    public class Countries : IGenerator
    {
        public Countries()
        {
        }

        public string Generate(int maxRows, string staticFileName = "")
        {
            var context = new _8a_oldContext();
            IQueryable<_8anu.Data.Migration.Model.Country> oldCountries = context.Set<_8anu.Data.Migration.Model.Country>();

            // for countries we always take all
            // if (maxRows > 0)
            // {
            //     oldNews = oldNews.Take(maxRows);
            // }

            var newCountries = new Dictionary<string, Country>();

            var maxCountryId = 0;
            foreach (var old in oldCountries)
            {
                var item = new Country
                {
                    Id = old.Id,
                    Name = old.Whole,
                    Slug = old.Slug,
                    ISO2 = old.Iso,
                    ISO3 = old.Short

                };
                if (item.Id > maxCountryId) 
                {
                    maxCountryId = item.Id.Value;
                }
                newCountries.Add(item.ISO3, item);
            }

            var unknown = new Country
            {
                Id = ++maxCountryId,
                Name = "Unknown",
                Slug = "unknown",
                ISO2 = "--",
                ISO3 = "---"
            };
            newCountries.Add(unknown.ISO3, unknown);

            SeedStore.UnknownCountry = unknown;
            SeedStore.Countries = newCountries;

            var json = JsonConvert.SerializeObject(newCountries.Values);
            return json;
        }

        public void GenerateSqlFile(string path) 
        {
            var tablename = "countries";
            SeedStore.AddAllSqlString(tablename);
            var head = $@"TRUNCATE TABLE `{tablename}`;
ALTER TABLE `{tablename}` DISABLE KEYS;";
            var tail = $"ALTER TABLE `{tablename}` ENABLE KEYS;";
            var insertHead = @"INSERT INTO `" + tablename + @"` (`id`, `iso2`, `iso3`, `name`, `slug`)
VALUES";

            var currentPageRow = 1;
            var rowNumber = 0;
            var maxRowCountPerInsert = SeedStore.MAX_ROW_COUNT_PER_INSERT;
            var rowCount = SeedStore.Countries.Values.Count;
            using (var filestream = new FileStream(path, FileMode.Create))
            using (var sq = new StreamWriter(filestream))
            {
                sq.WriteLine(SeedStore.SQL_HEAD);
                sq.WriteLine(head);
                sq.WriteLine();
                sq.WriteLine(insertHead);
                foreach(var country in SeedStore.Countries.Values)
                {
                    rowNumber++;

                    if (currentPageRow > maxRowCountPerInsert)
                    {
                        sq.WriteLine();
                        sq.WriteLine(insertHead);
                        currentPageRow = 1;
                    }

                    var line = new StringBuilder("(");
                    line.Append(string.Join(",", new object[] {
                        country.Id,
                        country.ISO2.ToSqlInsertString(),
                        country.ISO3.ToSqlInsertString(),
                        country.Name.ToSqlInsertStringEscape(),
                        country.Slug.ToSqlInsertString()
                    }));

                    line.Append(")");

                    currentPageRow++;

                    if (currentPageRow <= maxRowCountPerInsert && rowNumber < rowCount) 
                    {
                        line.Append(",");
                    }
                    else 
                    {
                        line.Append(";");
                    }

                    sq.WriteLine(line);
                }

                sq.WriteLine();
                sq.WriteLine(tail);
                sq.WriteLine();
                sq.WriteLine(SeedStore.SQL_TAIL);
            }
        }
    }
}
