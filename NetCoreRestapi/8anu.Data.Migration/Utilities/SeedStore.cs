using System;
using System.Collections.Generic;
using _8anu.Api.Common.DataEntities;
using System.Linq;
using _8anu.Api.Common.Enums;
using _8anu.Data.Migration.Generators;

namespace _8anu.Data.Migration.Utilities
{
    public static class SeedStore
    {
        public const string CATEGORY_SPORTSCLIMBING = "sportclimbing";
        public const string CATEGORY_BOULDERING = "bouldering";
        public const string ASCENT_CATEGORY_ROUTE = "Route";
        public const string ASCENT_CATEGORY_BOULDER = "Boulder";

        public const string SQL_HEAD = @"SET FOREIGN_KEY_CHECKS = 0;
SET NAMES utf8mb4;
SET UNIQUE_CHECKS = 0;
SET AUTOCOMMIT = 0;";
        public const string SQL_TAIL = @"SET FOREIGN_KEY_CHECKS = 1;
SET UNIQUE_CHECKS = 1;
COMMIT;";

        public const int MAX_ROW_COUNT_PER_INSERT = 1000;

        public static bool GenerateSQLFiles = false;

        public static string AllSql = "";

        private static int SlugCounter = 0;
        public static Dictionary<int, HashSet<int>> routeGrades;
        public static Dictionary<int, HashSet<int>> boulderGrades;
        public static Dictionary<string, string> Settings;
        public static Dictionary<string, Country> Countries;
        public static Dictionary<int, ForumCategory> ForumCategories;
        public static Dictionary<int, ForumComment> ThreadComments;
        public static Dictionary<int, User> Users;
        public static HashSet<int> SkippedUserIds;
        public static HashSet<int> AddedUserIds;
        public static HashSet<Ascent> Ascents;
        private static Dictionary<int, Crag> Crags;
        private static Dictionary<string, int> cragsCache;
        private static Dictionary<string, int> cragsCacheWithoutCountry;
        private static Dictionary<string, Sector> Sectors;
        private static Dictionary<string, Zlaggable> Routes;
        private static Dictionary<string, Zlaggable> Boulders;
        public static List<GradingSystem> GradingSystems;
        public static int MaxCragId = 0; //current running maxcragid
        public static int MaxSectorId = 0;
        public static int MaxRouteId = 0;
        public static int MaxBoulderId = 0;
        public static int MaxAscentId = 0;
        public static Country UnknownCountry;
        public static int MaxRowsPerTable = 0;

        public static int CragCount = 0;
        public static int SectorCount = 0;
        public static int RouteCount = 0;
        public static int BoulderCount = 0;
        public static int AscentCount = 0;

        static SeedStore()
        {
            Settings = new Dictionary<string, string>();
            ThreadComments = new Dictionary<int, ForumComment>();
            Sectors = new Dictionary<string, Sector>(255000);
            Routes = new Dictionary<string, Zlaggable>(920000);
            Boulders = new Dictionary<string, Zlaggable>(522000);
            Crags = new Dictionary<int, Crag>(87000);
            cragsCache = new Dictionary<string, int>(87000);
            cragsCacheWithoutCountry = new Dictionary<string, int>(87000);
            Ascents = new HashSet<Ascent>(4700000);
            routeGrades = new Dictionary<int, HashSet<int>>();
            boulderGrades = new Dictionary<int, HashSet<int>>();
        }

        public static string GetNewSlug()
        {
            return $"test-slug-{++SlugCounter}";
        }
        
        public static void AddAllSqlString(string tableName)
        {
            AllSql += $"source {tableName}.sql;{Environment.NewLine}";
        }
        
        public static void InitializeAscentsArray(int itemCount)
        {
            if (itemCount > 0)
            {
                Ascents = new HashSet<Ascent>(itemCount);
            }
            else
            {
                Ascents = new HashSet<Ascent>();
            }
        }

        public static int GetZeroUserId()
        {
            var retval = -1;
            int.TryParse(Settings["ZeroUserId"], out retval);
            return retval;
        }

        public static Dictionary<string, Zlaggable>.ValueCollection GetBoulders() 
        {
            return Boulders.Values;    
        }
        public static Dictionary<string, Zlaggable>.ValueCollection GetRoutes()
        {
            return Routes.Values;
        }
        public static void AddRoute(Zlaggable thingie)
        {
            RouteCount++;
            AddThingie(thingie, Routes);
        }
        public static void AddBoulder(Zlaggable thingie)
        {
            BoulderCount++;
            AddThingie(thingie, Boulders);
        }
        public static void AddAscent(Ascent ascent)
        {
            AscentCount++;
            Ascents.Add(ascent);
        }

        public static void AddThingie(Zlaggable thingie, Dictionary<string, Zlaggable> coll) 
        {
            var key = string.Join("-", new object[] { thingie.SectorId, thingie.Name.Trim().ToLower() });
            coll.Add(key, thingie);
        }

        public static Zlaggable GetThingie(int sectorId, string name, int category)
        {
            Zlaggable thingie = null;
            var key = string.Join("-", new object[] { sectorId, name.Trim().ToLower() });
            var coll = category == 0 ? Routes : Boulders;
            if (coll.ContainsKey(key))
            {
                thingie = coll[key];
            }
            return thingie;
        }
        public static void AddSector(Sector sector)
        {
            SectorCount++;
            var cacheKey = string.Join("-", new object[] { sector.CragId, sector.Name.Trim().ToLower() });
            Sectors.Add(cacheKey, sector);
        }
        public static Dictionary<string, Sector>.ValueCollection GetSectors()
        {
            return Sectors.Values;
        }

        public static Sector GetSector(int cragId, string name)
        {
            var cacheKey = string.Join("-", new object[] { cragId, name.ToLower().Trim() });
            Sector sector = null;
            if (Sectors.ContainsKey(cacheKey)) 
            {
                sector = Sectors[cacheKey];
            }
            return sector;
        }

        public static bool CragExists(int cragId)
        {
            return Crags.ContainsKey(cragId);
        }

        public static void AddCrag(Crag crag)
        {
            CragCount++;
            Crags.Add(crag.Id.Value, crag);

            var cacheKey = string.Join("-", new object[] { crag.Category, crag.Name.ToLower(), crag.CountryId });
            cragsCache.Add(cacheKey, crag.Id.Value);

            var cacheKeyWithoutCountry = string.Join("-", new object[] { crag.Category, crag.Name.ToLower() });
            if (!cragsCacheWithoutCountry.ContainsKey(cacheKeyWithoutCountry))
            {
                cragsCacheWithoutCountry.Add(cacheKeyWithoutCountry, crag.Id.Value);
            }
        }

        public static Dictionary<int, Crag>.ValueCollection GetCrags()
        {
            return Crags.Values;
        }

        public static Crag GetCrag(int cragId) 
        {
            Crag crag = null;
            if (CragExists(cragId)) 
            {
                crag = Crags[cragId];    
            }
            return crag;
        }

        public static Crag GetCrag(string name, string category, int countryId)
        {
            Crag crag = null;

            name = name.ToLower().Trim();
            var cacheKey = string.Join("-", new object[] { category, name.Trim().ToLower(), countryId });
            if (cragsCache.ContainsKey(cacheKey))
            {
                var cragId = cragsCache[cacheKey];
                crag = Crags[cragId];
            }

            return crag;
        }

        public static Crag GetCragOnlyByName(string name, string category) 
        {
            Crag crag = null;

            name = name.ToLower().Trim();
            var cacheKey = string.Join("-", new object[] { category, name.Trim().ToLower() });
            if (cragsCacheWithoutCountry.ContainsKey(cacheKey))
            {
                var cragId = cragsCacheWithoutCountry[cacheKey];
                crag = Crags[cragId];
            }

            return crag;
        }

        public static int GetCountryId(string iso3) 
        {
            try
            {
                var country = GetCountryByCountryISO3(iso3);
                return country.Id.Value;
            }
            catch (Exception ex) 
            {
                throw (ex);
            }
        }

        public static Country GetCountryByCountryISO3(string iso3)
        {
            Country country = null;
            if (Countries.ContainsKey(iso3)) 
            {
                country = Countries[iso3];    
            }
            return country;
        }

        public static User GetUser(int id)
        {
            if (id == 0)
            {
                id = GetZeroUserId();
            }
            User user = null;
            if (Users.ContainsKey(id)) 
            {
                user = Users[id];    
            }
            return user;
        }

        public static void AddGrade(int zlaggableId, GradingSystem gradingSystem, ZlaggableCategoryEnum category)
        {
            HashSet<int> grades;
            if (category == ZlaggableCategoryEnum.Sportclimbing)
            {
                if (routeGrades.ContainsKey(zlaggableId))
                {
                    grades = routeGrades[zlaggableId];
                }
                else
                {
                    grades = new HashSet<int>();
                    routeGrades.Add(zlaggableId, grades);
                }
            }
            else
            {
                if (boulderGrades.ContainsKey(zlaggableId))
                {
                    grades = boulderGrades[zlaggableId];
                }
                else
                {
                    grades = new HashSet<int>();
                    boulderGrades.Add(zlaggableId, grades);
                }
            }

            grades.Add(gradingSystem.VLGradeIndex);
        }

        
        
        public static void UpdateGrade(Zlaggable zlaggable)
        {
            // get amount of ascents
            // var totalAscents = Ascents.
            
            // get average of grades
            var source = zlaggable is Route ? routeGrades : boulderGrades;
            if (source.ContainsKey(zlaggable.Id.Value))
            {
                var grades = source[zlaggable.Id.Value];
                // calculate average index
                var gradeCount = grades.Count;
                var gradeIndexSum = grades.Sum();
                var avg = (int)Math.Round((decimal)gradeIndexSum / gradeCount, 0, MidpointRounding.AwayFromZero);

                var grade = GetGradigSystemByIndex(avg, zlaggable is Route);
                if (grade == null)
                {
                    Console.WriteLine("no grade found for zlaggable id: " + zlaggable.Id + "(" + zlaggable.Slug + ")");
                    return;
                }

                if (zlaggable.Grade != grade.VLGrade)
                {
                    Console.WriteLine("updating zlaggable id " + zlaggable.Id + "-" + (zlaggable is Route).ToString() + " grade from '" + zlaggable.Difficulty + "/" + zlaggable.Grade +
                                      "' to '" + grade.Grade + "/" + grade.VLGrade + "'");
                    zlaggable.Difficulty = grade.Grade;
                    zlaggable.Grade = grade.VLGrade;
                }
                
                
            }
        }

        public static Dictionary<string, GradingSystem> _gradingSystems;
        public static _8anu.Api.Common.DataEntities.GradingSystem GetGradigSystemByIndex(int index, bool isSportClimbing)
        {
            var key = (isSportClimbing ? "0" : "1") + "vl-" + index;
            if (_gradingSystems == null)
            {
                _gradingSystems = SeedStore.GradingSystems.Where(gs => gs.Type == "8a_french")
                    .ToDictionary(k => (k.Category == SeedStore.CATEGORY_SPORTSCLIMBING ? "0" : "1") + k.VLGrade, v => v);
            }

            if (_gradingSystems.ContainsKey(key))
            {
                return _gradingSystems[key];
            }
            else
            {
                return null;
            }
        }
    }
}
