using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using _8anu.Data.Migration.Utilities;
using _8anu.Api.Common.DataEntities;
using System.Text;

namespace _8anu.Data.Migration.Generators
{
    public class Gradingsystems : IGenerator
    {
        public Gradingsystems()
        {
        }

        public string Generate(int maxRows, string staticFilename = "") 
        {
            // read preconfigured grading systems from file
            var json = File.ReadAllText(staticFilename);

            // create class to save to store for later use with the scores etc
            var gradingSystems = (List<GradingSystem>)JsonConvert.DeserializeObject(json, typeof(List<GradingSystem>));
            SeedStore.GradingSystems = gradingSystems;

            // get maxId
            var maxId = gradingSystems.Max(gs => gs.Id).Value;

            // add 8a grading system
            var input = getInput();
            var newRoutes = new List<GradingSystem>();
            var newBoulders = new List<GradingSystem>();
            var routeId = 0;
            var boulderId = 1;
            var vlId = 2;
            using (StringReader reader = new StringReader(input)) 
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var vals = line.Split(',');
                    var vl = vals[vlId];
                    var newBoulder = createNewGradingSystem(vals[boulderId], vl, "bouldering");
                    newBoulder.Id = ++maxId;
                    newBoulders.Add(newBoulder);
                    var newRoute = createNewGradingSystem(vals[routeId], vl, "sportclimbing");
                    newRoute.Id = ++maxId;
                    newRoutes.Add(newRoute);
                }
            }

            gradingSystems.AddRange(newRoutes);
            gradingSystems.AddRange(newBoulders);

            json = JsonConvert.SerializeObject(gradingSystems);
            return json;
        }

        private GradingSystem createNewGradingSystem(string grade, string vl, string category)
        {
            return new GradingSystem
            {
                VLGrade = vl,
                Type = "8a_french",
                Grade = grade,
                Category = category
            };
        }

        private string getInput() 
        {
            return @"1,1,vl-1
2,2,vl-2
3a,3A,vl-3
3b,3B,vl-4
3c,3C,vl-5
4a,4A,vl-6
4b,4B,vl-7
4b,4B,vl-8
4c,4C,vl-9
5a,5A,vl-11
5a,5A,vl-10
5b,5B,vl-12
5b,5B,vl-13
5c,5C,vl-14
5c,5C,vl-15
6a,6A,vl-16
6a+,6A+,vl-17
6b,6B,vl-18
6b+,6B+,vl-19
6c,6C,vl-20
6c+,6C+,vl-21
7a,7A,vl-22
7a+,7A+,vl-23
7b,7B,vl-24
7b+,7B+,vl-25
7c,7C,vl-26
7c+,7C+,vl-27
8a,8A,vl-28
8a+,8A+,vl-29
8b,8B,vl-30
8b+,8B+,vl-31
8c,8C,vl-32
8c+,8C+,vl-33
9a,9A,vl-34
9a+,9A+,vl-35
9b,9B,vl-36
9b+,9B+,vl-37
9c,9C,vl-38
8c/+,8C/+,vl-39
8c+/9a,8C+/9A,vl-40
9a/+,9A/+,vl-41
9a+/9b,9A+/9B,vl-42";    
        }
    
        public void GenerateSqlFile(string path)
        {
            var tablename = "grading_systems";
            SeedStore.AddAllSqlString(tablename);
            var head = $@"TRUNCATE TABLE `{tablename}`;
ALTER TABLE `{tablename}` DISABLE KEYS;";
            var tail = $"ALTER TABLE `{tablename}` ENABLE KEYS;";
            var insertHead = @"INSERT INTO `" + tablename + @"` (`id`, `category`, `grade`, `type`, `vl_grade`)
VALUES";

            var currentPageRow = 1;
            var rowNumber = 0;
            var maxRowCountPerInsert = SeedStore.MAX_ROW_COUNT_PER_INSERT;
            var rowCount = SeedStore.GradingSystems.Count;


            using (var filestream = new FileStream(path, FileMode.Create))
            using (var sq = new StreamWriter(filestream))
            {
                sq.WriteLine(SeedStore.SQL_HEAD);
                sq.WriteLine(head);
                sq.WriteLine();
                sq.WriteLine(insertHead);
                foreach (var grade in SeedStore.GradingSystems)
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
                        grade.Id,
                        grade.Category.ToSqlInsertString(),
                        grade.Grade.ToSqlInsertString(),
                        grade.Type.ToSqlInsertString(),
                        grade.VLGrade.ToSqlInsertString()
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