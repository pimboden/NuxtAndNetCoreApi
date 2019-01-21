using Newtonsoft.Json;
using _8anu.Data.Migration.Utilities;
using System.IO;
using System.Text;

namespace _8anu.Data.Migration.Generators
{
    public class Routes : IGenerator
    {
        public Routes()
        {
        }

        public string Generate(int maxRows, string staticFileName = "") {

            foreach (var route in SeedStore.GetRoutes())
            {
                SeedStore.UpdateGrade(route);
            }
            
            
            var json = JsonConvert.SerializeObject(SeedStore.GetRoutes());
            return json;
        }
    
        public void GenerateSqlFile(string path)
        {
            var tablename = "routes";
            SeedStore.AddAllSqlString(tablename);
            var head = $@"TRUNCATE TABLE `{tablename}`;
ALTER TABLE `{tablename}` DISABLE KEYS;";
            var tail = $"ALTER TABLE `{tablename}` ENABLE KEYS;";
            var insertHead = @"INSERT INTO `" + tablename + @"` (`id`, `date_created`, `date_modified`, `difficulty`, `grade`, `grading_system`, `length`, `name`, `notes`, `path`, `reference_width`, `sector_id`, `spit`, `topo_num`, `slug`, `legacy_id`)
VALUES";

            var currentPageRow = 1;
            var rowNumber = 0;
            var maxRowCountPerInsert = SeedStore.MAX_ROW_COUNT_PER_INSERT;
            var routes = SeedStore.GetRoutes();
            var rowCount = routes.Count;

            using (var filestream = new FileStream(path, FileMode.Create))
            using (var sq = new StreamWriter(filestream))
            {
                sq.WriteLine(SeedStore.SQL_HEAD);
                sq.WriteLine(head);
                sq.WriteLine();
                sq.WriteLine(insertHead);
                foreach (var thingie in routes)
                {
                    var item = thingie as _8anu.Api.Common.DataEntities.Route;
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
                        item.Length.HasValue ? item.Length.Value.ToString() : "NULL",
                        item.Name.ToSqlInsertStringEscape(true),
                        item.Notes.ToSqlInsertStringEscape(true),
                        item.Path.ToSqlInsertStringEscape(true),
                        item.ReferenceWidth.HasValue ? item.ReferenceWidth.Value.ToString() : "NULL",
                        item.SectorId, 
                        item.Spit.HasValue ? item.Spit.Value.ToString() : "NULL",
                        item.TopoNum.ToSqlInsertStringEscape(true),
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