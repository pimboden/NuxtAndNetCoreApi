using System;
using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json;
using _8anu.Data.Migration.Model;
using System.Linq;
using _8anu.Data.Migration.Utilities;
using Crag = _8anu.Api.Common.DataEntities.Crag;
using System.IO;
using System.Text;

namespace _8anu.Data.Migration.Generators
{
    public class Crags : IGenerator
    {
        public Crags()
        {
        }

        public string Generate(int maxRows, string staticFileName = "")
        {
            var context = new _8a_oldContext();
            IQueryable<_8anu.Data.Migration.Model.Crag> oldCrags = context.Set<_8anu.Data.Migration.Model.Crag>();

            if (maxRows > 0)
            {
                oldCrags = oldCrags.Take(maxRows);
            }

            var newCrags = new Dictionary<int, Crag>();
            foreach (var old in oldCrags)
            {
                double? lat = null;
                double? lng = null;
                if (!(string.IsNullOrEmpty(old.GoggleMapX.Trim()) && string.IsNullOrEmpty(old.GoggleMapY.Trim()))) {
                    try
                    {
                        lat = double.Parse(old.GoggleMapX.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                        lng = double.Parse(old.GoggleMapY.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                    }
                    catch {
                        lat = null;
                        lng = null;
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("crag: " + old.Name + " - id: " + old.Id.ToString() + "exception converting lat & longitude");
                        // Console.WriteLine("exception with original lat: " + old.GoggleMapX);
                        // Console.WriteLine("exception with original lng: " + old.GoggleMapY);
                    }

                }

                var category = old.Type == 0 ? SeedStore.CATEGORY_SPORTSCLIMBING : SeedStore.CATEGORY_BOULDERING;

                var item = new Crag
                {
                    Id = (int)old.Id,
                    Slug = old.Slug,
                    Category = category,
                    Name = old.Name,
                    Town = old.City,
                    CountryId = GetCountryId(old.CountryId),
                    Latitude = lat,
                    Longitude = lng,
                    DateCreated = old.EditDate,
                    DateModified = old.EditDate,
                    Published = old.Active == 1 ? true : false,
                    Access = old.AccessInfo,
                    LegacyId = (int)old.Id
                };

                // increase maxID so we can autoincrement new crags later (sector generator)
                if (item.Id.Value > SeedStore.MaxCragId)
                {
                    SeedStore.MaxCragId = item.Id.Value; 
                }

                if (old.CragAreaId > 0) 
                {
                    item.AreaId = old.CragAreaId;    
                }


                //newCrags.Add(item.DatabaseId.Value, item);
                SeedStore.AddCrag(item);
            }

            // SeedStore.AddCragsRange(newCrags);

            //var json = JsonConvert.SerializeObject(newCrags.Values);
            //return json;
            return "";
        }

        private List<_8anu.Data.Migration.Model.Country> _oldCountries;
        private int GetCountryId(string countryCode)
        {
            var retval = -1;

            if (_oldCountries == null)
            {
                var context = new _8a_oldContext();
                _oldCountries = context.Set<Model.Country>().ToList();
            }

            var country = _oldCountries.Where(c => c.Short.Equals(countryCode)).FirstOrDefault();
            if (country != null)
            {
                retval = country.Id;
            }

            return retval;
        }

        public void GenerateSqlFile(string path)
        {
            var tablename = "crags";
            SeedStore.AddAllSqlString(tablename);
            var head = $@"TRUNCATE TABLE `{tablename}`;
ALTER TABLE `{tablename}` DISABLE KEYS;";
            var tail = $"ALTER TABLE `{tablename}` ENABLE KEYS;";
            var insertHead = @"INSERT INTO `" + tablename + @"` (`id`, `slug`, `category`, `name`, `town`, `country_id`, `latitude`, `longitude`,`date_created`,`date_modified`,`published`,`access`, `area_id`, `legacy_id`)
VALUES";

            var currentPageRow = 1;
            var rowNumber = 0;
            var maxRowCountPerInsert = SeedStore.MAX_ROW_COUNT_PER_INSERT;
            var crags = SeedStore.GetCrags();
            var rowCount = crags.Count;

            using (var filestream = new FileStream(path, FileMode.Create))
            using (var sq = new StreamWriter(filestream))
            {
                sq.WriteLine(SeedStore.SQL_HEAD);
                sq.WriteLine(head);
                sq.WriteLine();
                sq.WriteLine(insertHead);
                foreach (var crag in crags)
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
                        crag.Id,
                        crag.Slug.ToSqlInsertString(),
                        crag.Category.ToSqlInsertString(),
                        crag.Name.ToSqlInsertStringEscape(false),
                        crag.Town.ToSqlInsertStringEscape(true),
                        crag.CountryId,
                        crag.Latitude.HasValue ? crag.Latitude.ToString() : "NULL",
                        crag.Longitude.HasValue ? crag.Longitude.ToString() : "NULL",
                        crag.DateCreated.ToSqlInsertString(),
                        crag.DateModified.ToSqlInsertString(),
                        crag.Published ? 1 : 0,
                        crag.Access.ToSqlInsertStringEscape(false),
                        crag.AreaId.HasValue ? crag.AreaId.ToString() : "NULL",
                        crag.LegacyId.HasValue ? crag.LegacyId.ToString() : "NULL"
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
