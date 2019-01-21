using System.Collections.Generic;
using Newtonsoft.Json;
using _8anu.Api.Common.DataEntities;
using System;
using System.Text;
using System.IO;
using _8anu.Data.Migration.Utilities;

namespace _8anu.Data.Migration.Generators
{
    public class TestModels : IGenerator
    {
        public TestModels()
        {
        }

        List<TestModel> items;
        public string Generate(int maxRows, string staticFileName = "") {
            items = new List<TestModel>();
            var curId = 0;

            var now = DateTime.Now;
            var item = new TestModel
            {
                Id = ++curId,
                Message = "pädi is a homo",
                DateCreated = now,
                DateModified = now
            };
            items.Add(item);


            item = new TestModel
            {
                Id = ++curId,
                Message = "pädi is a gaylord",
                DateCreated = now,
                DateModified = now
            };
            items.Add(item);

            item = new TestModel
            {
                Id = ++curId,
                Message = "pädi is a paragliding gaylord",
                DateCreated = now,
                DateModified = now
            };
            items.Add(item);

            item = new TestModel
            {
                Id = ++curId,
                Message = "K is KING",
                DateCreated = now,
                DateModified = now
            };
            items.Add(item);

            item = new TestModel
            {
                Id = ++curId,
                Message = "Long live K",
                DateCreated = now,
                DateModified = now
            };
            items.Add(item);

            var json = JsonConvert.SerializeObject(items);
            return json;
        }
    
        public void GenerateSqlFile(string path)
        {
            var tablename = "test_models";
            SeedStore.AddAllSqlString(tablename);
            var head = $@"TRUNCATE TABLE `{tablename}`;
ALTER TABLE `{tablename}` DISABLE KEYS;";
            var tail = $"ALTER TABLE `{tablename}` ENABLE KEYS;";
            var insertHead = @"INSERT INTO `" + tablename + @"` (`id`, `date_created`, `date_modified`, `message`)
VALUES";

            var currentPageRow = 1;
            var rowNumber = 0;
            var maxRowCountPerInsert = SeedStore.MAX_ROW_COUNT_PER_INSERT;
            var rowCount = items.Count;


            using (var filestream = new FileStream(path, FileMode.Create))
            using (var sq = new StreamWriter(filestream))
            {
                sq.WriteLine(SeedStore.SQL_HEAD);
                sq.WriteLine(head);
                sq.WriteLine();
                sq.WriteLine(insertHead);
                foreach (var test in items)
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
                        test.Id,
                        test.DateCreated.ToSqlInsertString(),
                        test.DateModified.ToSqlInsertString(),
                        test.Message.ToSqlInsertStringEscape()
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
