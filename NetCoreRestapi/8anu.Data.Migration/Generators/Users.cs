using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using _8anu.Data.Migration.Model;
using System.Linq;
using _8anu.Data.Migration.Utilities;
using System.Text.RegularExpressions;
using _8anu.Api.Common.DataEntities;
using System.IO;
using System.Text;

namespace _8anu.Data.Migration.Generators
{
    public class Users : IGenerator
    {
        public Users()
        {
        }

        public string Generate(int maxRows, string staticFileName = "") {
            var context = new _8a_oldContext();
            IQueryable<_8anu.Data.Migration.Model.Userinfo> oldItems = context.Set<_8anu.Data.Migration.Model.Userinfo>();

            if (maxRows > 0)
            {
                oldItems = oldItems.Take(maxRows);
            }

            var newItems = new Dictionary<int, User>();
            var skippedCount = 0;
            var doneCount = 0;
            var skippedUserIds = new HashSet<int>();
            var addedUserIds = new HashSet<int>();

            foreach (var old in oldItems)
            {
                // todo: remove items with name and lastname "?"
                // todo: look for duplicate names with same firstname and lastname (plus id at the end) these should be preferably be converted to slug-hashtext
                // todo: look for people who don't have country in the country table. 
                // todo: check for names in the DB that have &; in their names or cities and change these to unicode
                // todo: check for users in DB with linebreak in their country code

                var newCountryId = GetCountryId(old.Country);
                if (newCountryId == -1) 
                {
                    newCountryId = SeedStore.UnknownCountry.Id.Value;
                    var s = String.Format("id: {0:-6} - {1:-30} - country: '{2:-5}' - will be using undefined country id: " + newCountryId, old.Id.ToString(), old.FName + " " + old.LName, old.Country);
                    Console.WriteLine(s);
                }
                if (newCountryId == -1)
                {
                    skippedUserIds.Add((int)old.Id);
                    var s = String.Format("id: {0:-6} - {1:-30} - country: '{2:-5}' - and that's not OK - SKIP", old.Id.ToString(), old.FName + " " + old.LName, old.Country);
                    Console.WriteLine(s);
                    skippedCount++;
                    continue;
                }
                addedUserIds.Add((int)old.Id);
                var zeroId = SeedStore.GetZeroUserId();

                // here we need to fix the ID for the 0 - user
                int newId = old.Id > 0 ? (int)old.Id : zeroId;
                var now = DateTime.Now;
                var item = new User
                {
                    Id = newId,
                    Slug = old.Slug,
                    FirstName = old.FName,
                    LastName = old.LName,
                    Gender = (Api.Common.Enums.GenderEnum)old.Sex,
                    CountryId = newCountryId,
                    DateCreated = now,
                    DateModified = now
                };
                newItems.Add(item.Id.Value, item);
                doneCount++;
            }

            SeedStore.SkippedUserIds = skippedUserIds;
            SeedStore.AddedUserIds = addedUserIds;
            SeedStore.Users = newItems;

            Console.WriteLine("done: " + doneCount.ToString() + " - skipped: " + skippedCount.ToString());

            var json = JsonConvert.SerializeObject(newItems.Values);
            return json;
        }

        private List<_8anu.Data.Migration.Model.Country> _oldCountries;
        private int GetCountryId(string countryCode)
        {
            var retval = -1;

            countryCode = Regex.Replace(countryCode.Trim(), @"\r\n?|\n", "");

            if (_oldCountries == null)
            {
                var context = new _8a_oldContext();
                _oldCountries = context.Set<Model.Country>().ToList();
            }

            var country = _oldCountries.FirstOrDefault(c => c.Short.Equals(countryCode));
            if (country != null)
            {
                retval = country.Id;
            }

            return retval;
        }
    
        public void GenerateSqlFile(string path)
        {
            var tablename = "users";
            SeedStore.AddAllSqlString(tablename);
            var head = $@"TRUNCATE TABLE `{tablename}`;
ALTER TABLE `{tablename}` DISABLE KEYS;";
            var tail = $"ALTER TABLE `{tablename}` ENABLE KEYS;";
            var insertHead = @"INSERT INTO `" + tablename + @"` (`id`, `country_id`, `date_created`, `date_modified`, `first_name`, `gender`, `last_name`, `slug`)
VALUES";

            var currentPageRow = 1;
            var rowNumber = 0;
            var maxRowCountPerInsert = SeedStore.MAX_ROW_COUNT_PER_INSERT;
            var rowCount = SeedStore.Users.Values.Count;


            using (var filestream = new FileStream(path, FileMode.Create))
            using (var sq = new StreamWriter(filestream))
            {
                sq.WriteLine(SeedStore.SQL_HEAD);
                sq.WriteLine(head);
                sq.WriteLine();
                sq.WriteLine(insertHead);
                foreach (var user in SeedStore.Users.Values)
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
                        user.Id,
                        user.CountryId,
                        user.DateCreated.ToSqlInsertString(),
                        user.DateModified.ToSqlInsertString(),
                        user.FirstName.ToSqlInsertStringEscape(false),
                        user.Gender == Api.Common.Enums.GenderEnum.Male ? 0 : 1,
                        user.LastName.ToSqlInsertStringEscape(false),
                        user.Slug.ToSqlInsertString()
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