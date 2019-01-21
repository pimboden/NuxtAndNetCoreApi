using Newtonsoft.Json;
using _8anu.Data.Migration.Utilities;
using System.IO;
using System.Text;
using System;

namespace _8anu.Data.Migration.Generators
{
    public class Ascents : IGenerator
    {
        public Ascents()
        {
        }

        public string Generate(int maxRows, string staticFileName = "") {
            //var json = JsonConvert.SerializeObject(SeedStore.Ascents);
            //return json;

            /*
            // serialize JSON directly to a file
            using (var file = File.CreateText(staticFileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, SeedStore.Ascents);
            }
            */


            return "";
        }

        public void GenerateSqlFile(string path)
        {
            var tablename = "ascents";
            SeedStore.AddAllSqlString(tablename);
            var head = $@"TRUNCATE TABLE `{tablename}`;
ALTER TABLE `{tablename}` DISABLE KEYS;";
            var tail = $"ALTER TABLE `{tablename}` ENABLE KEYS;";
            var insertHead = @"INSERT INTO `" + tablename + @"` (`id`, `user_id`, `date`, `difficulty`,  `zlaggable_id`, `zlaggable_type`, `comment`, `score`, `type`, `rating`, `repeat`, `project`, `chipped`, `exclude_from_ranking`, `note`, `date_created`, `date_modified`, `recommended`, `legacy_id`)
VALUES";

            var currentPageRow = 1;
            var rowNumber = 0;
            var maxRowCountPerInsert = SeedStore.MAX_ROW_COUNT_PER_INSERT;
            var ascents = SeedStore.Ascents;
            var rowCount = ascents.Count;

            using (var filestream = new FileStream(path, FileMode.Create))
            using (var sq = new StreamWriter(filestream))
            {
                sq.WriteLine(SeedStore.SQL_HEAD);
                sq.WriteLine(head);
                sq.WriteLine();
                sq.WriteLine(insertHead);
                foreach (var item in ascents)
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
                        item.Id,
                        item.UserId,
                        item.Date.UtcDateTime.ToSqlInsertString(),
                        item.Difficulty.ToSqlInsertString(true),
                        item.ZlaggableId.Value,
                        item.ZlaggableType.ToSqlInsertString(true),
                        item.Comment.ToSqlInsertStringEscape(true),
                        item.Score.HasValue ? item.Score.Value.ToString() : "NULL",
                        item.Type.ToSqlInsertString(true),
                        item.Rating.HasValue ? item.Rating.Value.ToString() : "NULL",
                        item.Repeat.HasValue ? (item.Repeat.Value ? 1 : 0).ToString() : "NULL",
                        item.Project.HasValue ? (item.Project.Value ? 1 : 0).ToString() : "NULL",
                        item.Chipped.HasValue ? (item.Chipped.Value ? 1 : 0).ToString() : "NULL",
                        item.ExcludeFromRanking.HasValue ? (item.ExcludeFromRanking.Value ? 1 : 0).ToString() : "NULL",
                        item.Note.HasValue ? item.Note.Value.ToString() : "NULL",
                        item.DateCreated.ToSqlInsertString(),
                        item.DateModified.ToSqlInsertString(),
                        (item.Recommended ? 1 : 0).ToString(),
                        item.LegacyId.HasValue ? item.LegacyId.ToString() : "NULL"
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