using System.Collections.Generic;
using Newtonsoft.Json;
using _8anu.Data.Migration.Model;
using System.Linq;
using _8anu.Api.Common.DataEntities;
using _8anu.Data.Migration.Utilities;
using System.Text;
using System.IO;

namespace _8anu.Data.Migration.Generators
{
    public class News : IGenerator
    {
        public News()
        {
        }

        List<NewsItem> newNews;
        public string Generate(int maxRows, string staticFileName = "") {
            var context = new _8a_oldContext();
            IQueryable<NewsAll> oldNews = context.Set<NewsAll>()
                                 .Where(n => n.Video == 0 && n.Country == "GLOBAL")
                                 .OrderByDescending(n => n.Datum);

            if (maxRows > 0)
            {
                oldNews = oldNews.Take(maxRows);
            }
            /*
            var myNews = new List<NewsAll>();
            if (maxRows > 0) {
                myNews = oldNews.Take(maxRows).ToList();
            }
            else {
                myNews = oldNews.ToList();
            }
            */

            newNews = new List<NewsItem>();

            foreach (var old in oldNews) 
            {
                var item = new NewsItem
                {
                    Id = (int)old.Id,
                    DateCreated = old.Datum,
                    DateModified = old.Datum,
                    DatePublished = old.Datum,
                    Title = old.Rubrik,
                    Description = old.Text,
                    Slug = old.Slug,
                    LegacyId = (int)old.Id
                };
                newNews.Add(item);
            }

            var json = JsonConvert.SerializeObject(newNews);
            return json;
        }
    
        public void GenerateSqlFile(string path)
        {
            var tablename = "news";
            SeedStore.AddAllSqlString(tablename);
            var head = $@"TRUNCATE TABLE `{tablename}`;
ALTER TABLE `{tablename}` DISABLE KEYS;";
            var tail = $"ALTER TABLE `{tablename}` ENABLE KEYS;";
            var insertHead = @"INSERT INTO `" + tablename + @"` (`id`, `date_created`, `date_modified`, `date_published`, `description`, `legacy_id`, `slug`, `title`)
VALUES";

            var currentPageRow = 1;
            var rowNumber = 0;
            var maxRowCountPerInsert = SeedStore.MAX_ROW_COUNT_PER_INSERT;
            var rowCount = newNews.Count;


            using (var filestream = new FileStream(path, FileMode.Create))
            using (var sq = new StreamWriter(filestream))
            {
                sq.WriteLine(SeedStore.SQL_HEAD);
                sq.WriteLine(head);
                sq.WriteLine();
                sq.WriteLine(insertHead);
                foreach (var news in newNews)
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
                        news.Id,
                        news.DateCreated.ToSqlInsertString(),
                        news.DateModified.ToSqlInsertString(),
                        news.DatePublished.ToSqlInsertString(),
                        news.Description.ToSqlInsertStringEscape(true),
                        news.LegacyId.HasValue ? news.LegacyId.ToString() : "NULL",
                        news.Slug.ToSqlInsertString(),
                        news.Title.ToSqlInsertStringEscape()
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
