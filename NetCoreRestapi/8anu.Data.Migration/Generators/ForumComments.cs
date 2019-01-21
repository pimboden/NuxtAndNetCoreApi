using Newtonsoft.Json;
using _8anu.Data.Migration.Utilities;
using System.IO;
using System.Text;

namespace _8anu.Data.Migration.Generators
{
    public class ForumComments : IGenerator
    {
        public ForumComments()
        {
        }

        public string Generate(int maxRows, string staticFileName = "") {
            var items = SeedStore.ThreadComments.Values;
            var json = JsonConvert.SerializeObject(items);
            return json;
        }
    
        public void GenerateSqlFile(string path)
        {
            var tablename = "forum_comments";
            SeedStore.AddAllSqlString(tablename);
            var head = $@"TRUNCATE TABLE `{tablename}`;
ALTER TABLE `{tablename}` DISABLE KEYS;";
            var tail = $"ALTER TABLE `{tablename}` ENABLE KEYS;";
            var insertHead = @"INSERT INTO `" + tablename + @"` (`id`, `content`, `date_created`, `date_modified`, `forum_thread_id`, `user_id`, `legacy_id`)
VALUES";

            var currentPageRow = 1;
            var rowNumber = 0;
            var maxRowCountPerInsert = SeedStore.MAX_ROW_COUNT_PER_INSERT;
            var rowCount = SeedStore.ThreadComments.Count;


            using (var filestream = new FileStream(path, FileMode.Create))
            using (var sq = new StreamWriter(filestream))
            {
                sq.WriteLine(SeedStore.SQL_HEAD);
                sq.WriteLine(head);
                sq.WriteLine();
                sq.WriteLine(insertHead);
                foreach (var comment in SeedStore.ThreadComments.Values)
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
                        comment.Id,
                        comment.Content.ToSqlInsertStringEscape(false),
                        comment.DateCreated.ToSqlInsertString(),
                        comment.DateModified.ToSqlInsertString(),
                        comment.ForumThreadId,
                        comment.UserId,
                        comment.LegacyId.HasValue ? comment.LegacyId.ToString() : "NULL"
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