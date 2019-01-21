using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using _8anu.Data.Migration.Model;
using _8anu.Data.Migration.Utilities;
using _8anu.Api.Common.DataEntities;
using Crag = _8anu.Api.Common.DataEntities.Crag;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Text;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Utilities;


namespace _8anu.Data.Migration.Generators
{
    public static class Extensions 
    {
        public static string SafeGetString(this System.Data.Common.DbDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
    }

    public class Sectors : IGenerator
    {
        

        public Sectors()
        {
            context = new _8a_oldContext();
        }

        private _8a_oldContext context;

        public string Generate(int maxRows, string staticFileName = "")
        {
            //IQueryable<_8anu.Data.Migration.Model.CragSectors> oldSectors =
            IQueryable<_8anu.Data.Migration.Model.CragSectors> oldSectors =    context.Set<_8anu.Data.Migration.Model.CragSectors>();

            if (maxRows > 0)
            {
                oldSectors = oldSectors.Take(maxRows);
            }

            foreach (var old in oldSectors)
            {
                // let's see if our crag exists
                var myCrag = SeedStore.GetCrag(old.CragId);

                if (myCrag == null)
                {
                    Console.WriteLine("crag id: " + old.CragId + " does not exist for sector id: " + old.Id + ", name: " + old.Name);
                    continue;
                }

                double? lat = null;
                double? lng = null;
                if (!(string.IsNullOrEmpty(old.GoggleMapX.Trim()) && string.IsNullOrEmpty(old.GoggleMapY.Trim())))
                {
                    try
                    {
                        lat = double.Parse(old.GoggleMapX.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                        lng = double.Parse(old.GoggleMapY.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                    }
                    catch
                    {
                        lat = null;
                        lng = null;
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("sector: " + old.Name + " - id: " + old.Id.ToString() + "exception converting lat & longitude");
                    }

                }

                var now = DateTime.Now;
                var item = new Sector
                {
                    Id = (int)old.Id,
                    CragId = old.CragId,
                    Name = old.Name,
                    Latitude = lat,
                    Longitude = lng,
                    Category = myCrag.Category,
                    DateCreated = now,
                    DateModified = now
                };

                if (item.Id.Value > SeedStore.MaxSectorId)
                {
                    SeedStore.MaxSectorId = item.Id.Value;
                }
                try
                {
                    SeedStore.AddSector(item);
                }
                catch
                {
                    // this is propably just duplicate.. so we'll forget it    
                }

            }


            GenerateAscents();


            var json = JsonConvert.SerializeObject(SeedStore.GetSectors());
            return json;
        }

        int curPage = -1;
        private List<Score> GetScoresPage()
        {
            var pageSize = 50000;
            var scores = new List<Score>();

            if (curPage == 1)
            {
                return scores;
            }

            var conn = context.Database.GetDbConnection();
            try
            {
                conn.Open();
                const string query =
                    @"select * from score order by id limit @page, @limit;";
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.Add(new MySqlParameter("page", ++curPage));
                    command.Parameters.Add(new MySqlParameter("limit", pageSize));
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var score = new Score();

                            score.Id = (uint)reader.GetInt32(0);
                            score.UserId = (uint)reader.GetInt32(1);
                            score.Date = reader.SafeGetString(2);
                            score.Grade = reader.GetByte(3);
                            score.Altgrade = reader[4] as byte?; //here
                            score.How = reader.GetByte(5);
                            score.Name = reader.SafeGetString(6);
                            score.Crag = reader.SafeGetString(7);
                            score.Comment = reader.SafeGetString(8);
                            score.Rate = reader.GetByte(9);
                            score.What = reader.GetByte(10);
                            score.Fa = (uint)reader.GetInt32(11);
                            score.Country = reader.SafeGetString(12);
                            score.Length = reader.SafeGetString(13);
                            //score.//Variations
                            score.Steepness = reader[15] as uint?; // here
                            score.Description = reader.SafeGetString(16);
                            score.Scrag = reader.SafeGetString(17);
                            score.ObjectClass = reader.SafeGetString(18);
                            score.RecDate = reader.GetDateTime(19);

                            score.Repeat = reader.GetInt32(20) == 0 ? (sbyte)0 : (sbyte)1;

                            score.YellowId = reader.GetByte(21);
                            score.CragSector = reader.SafeGetString(22);
                            score.ProjectAscentDate = reader.SafeGetString(23);
                            score.ExcludeFromRanking = reader.GetInt32(24);
                            score.TotalScore = reader.GetInt32(25);
                            score.UserRecommended = reader.GetByte(26);
                            score.Chipped = reader.GetByte(27);


                            scores.Add(score);
                        }
                    }

                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }

            return scores;

        }

        private void GenerateAscents()
        {
            var timer = Stopwatch.StartNew();
            // what we basically do here is get ascents from the score table
            // and if there is sector & crag for the ascent, we create new route
            // for it. if not, then we create new sectore / crag for the ascent
            IQueryable<Score> oldScores = context.Set<_8anu.Data.Migration.Model.Score>()
                                                 .OrderBy(s => s.Id);

            if (SeedStore.MaxRowsPerTable > 0)
            {
                oldScores = oldScores
                    .Take(SeedStore.MaxRowsPerTable);
            }

            // initialize our ascents .. might be slightly faster
            SeedStore.InitializeAscentsArray(SeedStore.MaxRowsPerTable);

            var di = Directory.GetParent(AppContext.BaseDirectory);
            var root = di.FullName;
            var outputPath = root + Path.DirectorySeparatorChar + "output";
            var path = outputPath + Path.DirectorySeparatorChar + "ascents.json";
            File.Delete(path);
            var filestream = new FileStream(path, FileMode.Create);
            using (var sq = new StreamWriter(filestream))
                using (var json = new JsonTextWriter(sq))
            {
                json.WriteStartArray();
                var first = true;
                foreach (var score in oldScores)
                {
                    
                    var ascent = HandleScore(score);
                    if (ascent != null)
                    {
                        // save to hashtable so we got something to save our sql from
                        SeedStore.AddAscent(ascent);

                        if (!first) 
                        {
                            json.WriteRaw(",");
                        }

                        json.WriteRaw(JsonConvert.SerializeObject(ascent,Formatting.Indented));    
                    }
                    first = false;

                }
                json.WriteEndArray();
            }

            timer.Stop();
            TimeSpan timespan = timer.Elapsed;

            Console.WriteLine("scores Completed! took " + String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));
            Console.WriteLine("crags: {0}, sectors: {1}, b: {2}, r: {3}, a: {4}", new object[]{
                SeedStore.CragCount, SeedStore.SectorCount, SeedStore.BoulderCount, SeedStore.RouteCount,
                SeedStore.AscentCount});
        }

        int ind = 0;
        int logTimes = 0;
        int currentScoreId = 0;
        private Api.Common.DataEntities.Ascent HandleScore(Score score)
        {
            currentScoreId = Convert.ToInt32(score.Id);

            ind++;

            if (ind % 10000 == 0)
            {
                Console.Write(". " + (++logTimes * 10000).ToString("#,##0"));
                Console.WriteLine("crags: {0}, sectors: {1}, b: {2}, r: {3}, a: {4}", new object[]{
                    SeedStore.CragCount, SeedStore.SectorCount, SeedStore.BoulderCount, SeedStore.RouteCount,
                    SeedStore.AscentCount
                });
            }
            else if (ind % 10000 == 0)
            {
                Console.Write(".");
            }

            // todo: unicode crag name, look for &234 without ; and remove spaces
            // todo: only do the unicode check if we create a new one
            // todo: find out does old 8a get routes difficulty from the first ascent in score DB?

            Crag crag = null;
            Sector sector = null;
            Zlaggable thingie = null;

            var scoreHasCountry = false;
            var scoreHasRouteOrBoulderName = false;
            var scoreHasCragName = false;
            var scoreHasSectorName = false;

            var cragName = getValue(score.Crag, "Unknown Crag", out scoreHasCragName);
            var sectorName = getValue(score.CragSector, "Unknown Sector", out scoreHasSectorName);
            var routeName = getValue(score.Name, "Unknown ", out scoreHasRouteOrBoulderName);
            if (!scoreHasRouteOrBoulderName)
            {
                var ending = score.What == 0 ? "route" : "boulder";
                routeName += ending;
            }
            var verticalCategory = score.What == 0 ? SeedStore.CATEGORY_SPORTSCLIMBING : SeedStore.CATEGORY_BOULDERING;
            var verticalAscentCategory = score.What == 0 ? SeedStore.ASCENT_CATEGORY_ROUTE : SeedStore.ASCENT_CATEGORY_BOULDER;
            var scoreHasCrag = false;
            var scoreHasSector = false;
            var scoreHasRouteOrBoulder = false;
            var countryId = -1;

            // get user
            var user = SeedStore.GetUser(Convert.ToInt32(score.UserId));
            if (user == null)
            {
                Console.WriteLine("score id: " + score.Id.ToString() + " USER DatabaseId: " + score.UserId.ToString() + " NOT FOUND!");
                return null;
            }

            //
            // get country - default to users country
            //
            var countryISO3 = score.Country;
            try
            {
                if (!string.IsNullOrEmpty(countryISO3))
                {
                    countryId = SeedStore.GetCountryId(score.Country);
                    scoreHasCountry = true;
                }
                else
                {
                    // if scores country is null, get users country
                    // this will be used if we create new crag
                    countryId = user.CountryId;
                }
            }
            catch
            {
                Console.WriteLine("trouble getting country for score id: " + score.Id + " - countryISO3: " + countryISO3);
                countryId = user.CountryId;
            }

            if (scoreHasCragName)
            {
                // get crag by name only
                crag = SeedStore.GetCragOnlyByName(score.Crag, verticalCategory);
            }
            else
            {
                crag = SeedStore.GetCrag(cragName, verticalCategory, countryId);
            }

            /*
            // get existing crag
            if (scoreHasCountry && scoreHasCragName)
            {
                // look for crag first by country
                crag = SeedStore.GetCrag(score.Crag, verticalCategory, countryId);

                scoreHasCrag |= crag != null;

                // todo:
                // optional: get existing crag with different category
            }
            else if (scoreHasCragName)
            {
                // score has no country defined .. so we just look for the crag name
                crag = SeedStore.GetCragOnlyByName(score.Crag, verticalCategory);
            }
            */


            // im here with my performance tests:
            // return null;

            // create crag if we still don't have one
            if (crag == null)
            {
                var cragId = ++SeedStore.MaxCragId;
                var now = DateTime.Now;
                crag = new Crag
                {
                    Id = cragId,
                    Slug = cragName.ToSlug(postString: cragId.ToString()),
                    Category = verticalCategory,
                    Name = cragName,
                    CountryId = countryId,
                    DateCreated = now,
                    DateModified = now,
                    Published = true
                };
                SeedStore.AddCrag(crag);
            }

            // get existing sector if score happens to have a crag
            //if (scoreHasCrag)
            //{
            sector = SeedStore.GetSector(crag.Id.Value, sectorName);
            scoreHasSector |= sector != null;
            //}

            // create sector if nothing found
            if (sector == null)
            {
                var now = DateTime.Now;
                // create new sector
                var sectorId = ++SeedStore.MaxSectorId;
                sector = new Sector
                {
                    Id = sectorId,
                    Slug = "",
                    CragId = crag.Id.Value,
                    Name = sectorName,
                    Category = verticalCategory,
                    DateCreated = now,
                    DateModified = now
                };
                SeedStore.AddSector(sector);
            }

            // only try to get existing "climbablethingie" if there is already a sector
            //if (scoreHasSector)
            //{
            thingie = SeedStore.GetThingie(sector.Id.Value, routeName, score.What);
            scoreHasRouteOrBoulder |= thingie != null;
            //}

            // get grading system to be used for using with route/boulder and ascent
            var gradingSystem = getGradingSystem(score.Grade, score.What);
            
            // no thingie (route or boulder) so we make new one
            if (thingie == null)
            {
                var now = DateTime.Now;
                if (score.What == 0) // could check for category but let's speed things up
                {
                    //if (!scoreHasRouteOrBoulderName)
                    //{
                    //    routeName += "route";
                    //}

                    var routeId = ++SeedStore.MaxRouteId;
                    thingie = new Route
                    {
                        Id = routeId,
                        Name = routeName,
                        Slug = "",
                        SectorId = sector.Id.Value
                    };
                    SeedStore.AddRoute(thingie);
                }
                else
                {
                    //if (!scoreHasRouteOrBoulderName)
                    //{
                    //    routeName += "boulder";
                    //}
                    var boulderId = ++SeedStore.MaxBoulderId;
                    thingie = new Boulder
                    {
                        Id = boulderId,
                        Name = routeName,
                        Slug = "",
                        SectorId = sector.Id.Value
                    };
                    SeedStore.AddBoulder(thingie);
                }
                thingie.DateCreated = now;
                thingie.DateModified = now;
                thingie.Difficulty = gradingSystem.Grade;   // 6a+
                thingie.Grade = gradingSystem.VLGrade;      // vl-1-39
                thingie.GradingSystem = gradingSystem.Type; // french
            }

            SeedStore.AddGrade(thingie.Id.Value, gradingSystem, score.What == 0 ? ZlaggableCategoryEnum.Sportclimbing : ZlaggableCategoryEnum.Bouldering);
            
            
            var objectClassLength = score.ObjectClass.Length;
            // comparing lenghts so it's a bit faster
            // lengths
            // 14 = CLS_UserAscent
            // 22 = CLS_UserAscent_Project
            // 18 = CLS_UserAscent_Try


            var type = "";  
            if (objectClassLength != 18)
            {
                type = getVerticalAscentType(score.How);
            }
            else
            {
                type = "go";
            }

            var isProject = objectClassLength == 22;

            // create ascent
            var ascent = new Ascent
            {
                Id = ++SeedStore.MaxAscentId,
                UserId = user.Id.Value,
                Date = ParseScoreDate(score.Date),      // climbed that shit date
                Difficulty = gradingSystem.Grade,       // eg. 8a+
                ZlaggableId = thingie.Id,               // ID of route or boulder
                ZlaggableType = verticalAscentCategory, // route / boulder
                Comment = score.Comment,                // user comment
                Score = score.TotalScore,
                Type = type,      // f, os, tr, rp, go
                Rating = score.Rate,
                Repeat = score.Repeat == 1 ? true : false,
                Project = isProject,
                Chipped = score.Chipped == 1,
                ExcludeFromRanking = score.ExcludeFromRanking == 1,
                Note = Convert.ToInt32(score.Fa),
                DateCreated = score.RecDate,
                DateModified = score.RecDate,
                Recommended = score.UserRecommended == 1,
                LegacyId = (int)score.Id
                
                // todo: userRecommended to Route "likes"
                // todo: what to do with projectAscentDate?
                // todo: what to do with YellowId

                // variations -> not used
                // steepness -> not used
                // altgrade -> not used
            };

            //SeedStore.Ascents.Add(ascent);
            return ascent;

        }

        private string getVerticalAscentType(int how)
        {
            /// f = flash, os = onsight, tr = toprope, rp = redpoint, go = go
            return how == 1 ? "rp" : how == 2 ? "f" : how == 3 ? "os" : how == 4 ? "tr" : how == 5 ? "os" : "go";
        }

        private DateTime ParseScoreDate(string sdate)
        {
            DateTime date;
            try 
            {
                var syear = sdate.Substring(0, 4);
                var year = Convert.ToInt32(syear);
                var month = Convert.ToInt32(sdate.Substring(5, 2));
                var day = Convert.ToInt32(sdate.Substring(8,2));
                date = new DateTime(year, month, day, 0, 0, 0).ToUniversalTime();
            }
            catch (Exception ex) 
            {
                Console.WriteLine("exception at parsing date string: '" + sdate + "'");
                throw ex;
            }
            return date;
        }

        private Dictionary<string, GradingSystem> _gradingSystems;
        private GradingSystem getGradingSystem(byte oldGradeId, int cat)
        {
            // let's change zero grade to 1 ... 
            if (oldGradeId == 0)
            {
                oldGradeId = 5;
            }

            var oldGrade = getOldGrade(oldGradeId, cat);

            if (_gradingSystems == null)
            {
                _gradingSystems = new Dictionary<string, GradingSystem>();
                var temp = SeedStore.GradingSystems.Where(gs => gs.Type == "8a_french").ToList();

                temp.ForEach(g =>
                {

                    var newkey = string.Join("-", new object[] { g.Category == SeedStore.CATEGORY_SPORTSCLIMBING ? 0 : 1, g.Grade.ToLower() });
                    if (!_gradingSystems.ContainsKey(newkey))
                    {
                        _gradingSystems.Add(newkey, g);
                    }


                });
            }

            var key = string.Join("-", new object[] { cat, oldGrade });
            GradingSystem system = null;

            if (_gradingSystems.ContainsKey(key))
            {
                system = _gradingSystems[key];
            }

            if (system == null)
            {
                throw new Exception("gradingystem is null for oldGradeId: " + oldGradeId.ToString());
            }
            return system;
        }

        private Dictionary<byte, string[]> oldGrades;
        private string getOldGrade(byte oldGradeId, int what)
        {
            // var context = new _8a_oldContext();
            if (oldGrades == null)
            {
                using (var db = new _8a_oldContext())
                {
                    oldGrades = db.Set<ScoreGrades>().ToDictionary(g => g.Id, g => new string[] { g.FraGrade.ToLower(), g.FraBoulder.ToLower() });
                }
            }

            return oldGrades[oldGradeId][what];
        }

        private string getValue(string value, string defaultValue, out bool hasValue)
        {
            var retval = defaultValue;
            hasValue = false;
            if (value != null && value.Trim().Length > 0)
            {
                retval = value.Trim();
                hasValue = true;
            }
            return retval;
        }

        public void GenerateSqlFile(string path)
        {
            var tablename = "sectors";
            SeedStore.AddAllSqlString(tablename);
            var head = $@"TRUNCATE TABLE `{tablename}`;
ALTER TABLE `{tablename}` DISABLE KEYS;";
            var tail = $"ALTER TABLE `{tablename}` ENABLE KEYS;";
            var insertHead = @"INSERT INTO `" + tablename + @"` (`id`, `category`, `crag_id`, `date_created`, `date_modified`, `latitude`, `longitude`, `name`, `notes`, `ordering`, `slug`)
VALUES";

            var currentPageRow = 1;
            var rowNumber = 0;
            var maxRowCountPerInsert = SeedStore.MAX_ROW_COUNT_PER_INSERT;
            var sectors = SeedStore.GetSectors();
            var rowCount = sectors.Count;

            using (var filestream = new FileStream(path, FileMode.Create))
            using (var sq = new StreamWriter(filestream))
            {
                sq.WriteLine(SeedStore.SQL_HEAD);
                sq.WriteLine(head);
                sq.WriteLine();
                sq.WriteLine(insertHead);
                foreach (var sector in sectors)
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
                        sector.Id,
                        sector.Category.ToSqlInsertString(),
                        sector.CragId,
                        sector.DateCreated.ToSqlInsertString(),
                        sector.DateModified.ToSqlInsertString(),
                        sector.Latitude.HasValue ? sector.Latitude.ToString() : "NULL",
                        sector.Longitude.HasValue ? sector.Longitude.ToString() : "NULL",
                        sector.Name.ToSqlInsertStringEscape(false),
                        sector.Notes.ToSqlInsertStringEscape(true),
                        sector.Ordering.HasValue ? sector.Ordering.ToString() : "NULL",
                        SeedStore.GetNewSlug().ToSqlInsertString()
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