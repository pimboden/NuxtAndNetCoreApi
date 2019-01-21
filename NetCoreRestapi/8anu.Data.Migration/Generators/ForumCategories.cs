using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using _8anu.Data.Migration.Model;
using System.Linq;
using _8anu.Api.Common.DataEntities;
using _8anu.Data.Migration.Utilities;
using System.IO;
using System.Text;

namespace _8anu.Data.Migration.Generators
{
    public class ForumCategories : IGenerator
    {
        public ForumCategories()
        {
        }

        public string Generate(int maxRows, string staticFileName = "")
        {
            var now = DateTime.Now;

            var items = new Dictionary<int, ForumCategory>();

            var zeroUserId = SeedStore.GetZeroUserId();

            var general = new ForumCategory
            {
                Id = 1,
                Slug = "general",
                Name = "Open forum",
                UserId = zeroUserId,
                DateCreated = now,
                DateModified = now
            };
            items.Add(general.Id.Value, general);

            var dr8a = new ForumCategory
            {
                Id = 2,
                Slug = "dr8a",
                Name = "Dr 8a",
                UserId = zeroUserId,
                DateCreated = now,
                DateModified = now
            };
            items.Add(dr8a.Id.Value, dr8a);


            var countryGroup = new ForumCategory
            {
                Id = 3,
                Slug = "country",
                Name = "Country specific forums",
                UserId = zeroUserId,
                DateCreated = now,
                DateModified = now
            };
            items.Add(countryGroup.Id.Value, countryGroup);

            CreateCountryGroups(3, items);
            //items.AddRange(CreateCountryGroups(3));

            SeedStore.ForumCategories = items;

            var json = JsonConvert.SerializeObject(items.Values);
            return json;
        }

        private void CreateCountryGroups(int parentCategory, Dictionary<int, ForumCategory> items) {
            //var items = new List<ForumCategory>();

            var curId = parentCategory;

            var context = new _8a_oldContext();
            var countries = context.Set<Model.ForumThreads>().Where(f => f.CountryCode != "GLOBAL" && f.ObjectClass == "CLS_ForumGeneral").Select(f => f.CountryCode).Distinct().ToList();

            foreach (var countryISO3 in countries) {
                var country = SeedStore.GetCountryByCountryISO3(countryISO3);
                if (country == null) {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("countrycode: '" + countryISO3 + "' not found. Skipped creating this country");
                    continue;
                }
                var now = DateTime.Now;
                var newGroup = new ForumCategory
                {
                    Id = ++curId,
                    Slug = country.Slug,
                    Name = country.Name,
                    UserId = SeedStore.GetZeroUserId(),
                    DateCreated = now,
                    DateModified = now,
                    ParentId = parentCategory
                };
                items.Add(newGroup.Id.Value, newGroup);
            }

            //return items;
        }
    
        public void GenerateSqlFile(string path)
        {
            var tablename = "forum_categories";
            SeedStore.AddAllSqlString(tablename);
            var head = $@"TRUNCATE TABLE `{tablename}`;
ALTER TABLE `{tablename}` DISABLE KEYS;";
            var tail = $"ALTER TABLE `{tablename}` ENABLE KEYS;";
            var insertHead = @"INSERT INTO `" + tablename + @"` (`id`, `date_created`, `date_modified`, `description`, `name`, `parent_id`, `slug`, `user_id`)
VALUES";

            var currentPageRow = 1;
            var rowNumber = 0;
            var maxRowCountPerInsert = SeedStore.MAX_ROW_COUNT_PER_INSERT;
            var rowCount = SeedStore.ForumCategories.Count;


            using (var filestream = new FileStream(path, FileMode.Create))
            using (var sq = new StreamWriter(filestream))
            {
                sq.WriteLine(SeedStore.SQL_HEAD);
                sq.WriteLine(head);
                sq.WriteLine();
                sq.WriteLine(insertHead);
                foreach (var cat in SeedStore.ForumCategories.Values)
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
                        cat.Id,
                        cat.DateCreated.ToSqlInsertString(),
                        cat.DateModified.ToSqlInsertString(),
                        cat.Description.ToSqlInsertStringEscape(true),
                        cat.Name.ToSqlInsertStringEscape(false),
                        cat.ParentId.HasValue ? cat.ParentId.Value.ToString() : "NULL",
                        cat.Slug.ToSqlInsertString(),
                        cat.UserId
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