using Newtonsoft.Json;
using _8anu.Data.Migration.Utilities;
using System.IO;
using System.Text;

namespace _8anu.Data.Migration.Generators
{
    public class Boulders : IGenerator
    {
        public Boulders()
        {
        }

        public string Generate(int maxRows, string staticFileName = "") {
            foreach (var boulder in SeedStore.GetBoulders())
            {
                SeedStore.UpdateGrade(boulder);
            }
            
            var json = JsonConvert.SerializeObject(SeedStore.GetBoulders());
            return json;
        }

        public void GenerateSqlFile(string path)
        {
            var tablename = "boulders";
            SeedStore.AddAllSqlString(tablename);
            var head = $@"TRUNCATE TABLE `{tablename}`;
ALTER TABLE `{tablename}` DISABLE KEYS;";
            var tail = $"ALTER TABLE `{tablename}` ENABLE KEYS;";
            var insertHead = @"INSERT INTO `" + tablename + @"` (`id`, `date_created`, `date_modified`, `difficulty`, `grade`, `grading_system`, `name`, `notes`, `path`, `reference_width`, `sector_id`, `sit_down_start`, `topo_num`, `traverse`, `slug`, `legacy_id`)
VALUES";

            var currentPageRow = 1;
            var rowNumber = 0;
            var maxRowCountPerInsert = SeedStore.MAX_ROW_COUNT_PER_INSERT;
            var boulders = SeedStore.GetBoulders();
            var rowCount = boulders.Count;

            using (var filestream = new FileStream(path, FileMode.Create))
            using (var sq = new StreamWriter(filestream))
            {
                sq.WriteLine(SeedStore.SQL_HEAD);
                sq.WriteLine(head);
                sq.WriteLine();
                sq.WriteLine(insertHead);
                foreach (var thingie in boulders)
                {
                    var item = thingie as _8anu.Api.Common.DataEntities.Boulder;
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
                        item.DateCreated.ToSqlInsertString(),
                        item.DateModified.ToSqlInsertString(),
                        item.Difficulty.ToSqlInsertString(),
                        item.Grade.ToSqlInsertString(),
                        item.GradingSystem.ToSqlInsertString(),
                        item.Name.ToSqlInsertStringEscape(true),
                        item.Notes.ToSqlInsertStringEscape(true),
                        item.Path.ToSqlInsertStringEscape(true),
                        item.ReferenceWidth.HasValue ? item.ReferenceWidth.Value.ToString() : "NULL",
                        item.SectorId,
                        item.SitDownStart ? 1 : 0,
                        item.TopoNum.ToSqlInsertStringEscape(true),
                        item.Traverse.HasValue ? (item.Traverse.Value ? "1" : "0") : "NULL",
                        SeedStore.GetNewSlug().ToSqlInsertString(),
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