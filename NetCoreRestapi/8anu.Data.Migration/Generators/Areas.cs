using System.Collections.Generic;
using Newtonsoft.Json;
using _8anu.Data.Migration.Model;
using System.Linq;
using _8anu.Api.Common.DataEntities;
using _8anu.Data.Migration.Utilities;
using System.IO;
using System.Text;
using _8anu.Api.Common.Utilities;

namespace _8anu.Data.Migration.Generators
{
    public class Areas : IGenerator
    {
        public Areas()
        {
        }

        private List<Area> newAreas;
        public string Generate(int maxRows, string staticFileName = "") {
            var context = new _8a_oldContext();
            IQueryable<_8anu.Data.Migration.Model.CragArea> oldAreas = context.Set<_8anu.Data.Migration.Model.CragArea>();

            if (maxRows > 0)
            {
                oldAreas = oldAreas.Take(maxRows);
            }

            newAreas = new List<Area>();
            foreach (var old in oldAreas)
            {
                var item = new Area
                {
                    Id = old.Id,
                    Slug = "",
                    Name = old.Name,
                    Published = true,
                    DateCreated = old.Date,
                    DateModified = old.Date,
                    CountryId = SeedStore.GetCountryByCountryISO3(old.CountryId).Id.Value,
                    LegacyId = old.Id
                };

                newAreas.Add(item);
            }

            var json = JsonConvert.SerializeObject(newAreas);
            return json;
        }

        public void GenerateSqlFile(string path)
        {
            var tablename = "areas";
            SeedStore.AddAllSqlString(tablename);
            var head = $@"TRUNCATE TABLE `{tablename}`;
ALTER TABLE `{tablename}` DISABLE KEYS;";
            var tail = $"ALTER TABLE `{tablename}` ENABLE KEYS;";
            var insertHead = @"INSERT INTO `" + tablename + @"` (`id`, `country_id`, `date_created`, `date_modified`, `description`, `name`, `published`, `slug`, `legacy_id`)
VALUES";

            var currentPageRow = 1;
            var rowNumber = 0;
            var maxRowCountPerInsert = SeedStore.MAX_ROW_COUNT_PER_INSERT;
            var rowCount = newAreas.Count;


            using (var filestream = new FileStream(path, FileMode.Create))
            using (var sq = new StreamWriter(filestream))
            {
                sq.WriteLine(SeedStore.SQL_HEAD);
                sq.WriteLine(head);
                sq.WriteLine();
                sq.WriteLine(insertHead);
                foreach (var area in newAreas)
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
                        area.Id,
                        area.CountryId,
                        area.DateCreated.ToSqlInsertString(),
                        area.DateModified.ToSqlInsertString(),
                        area.Description.ToSqlInsertStringEscape(),
                        area.Name.ToSqlInsertStringEscape(),
                        area.Published ? 1 : 0,
                        SeedStore.GetNewSlug().ToSqlInsertString(),
                        area.LegacyId.HasValue ? area.LegacyId.ToString() : "NULL"
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