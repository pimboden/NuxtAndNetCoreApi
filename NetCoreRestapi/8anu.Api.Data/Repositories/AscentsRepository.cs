using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Models;
using _8anu.Api.Data.Contexts;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Data;

namespace _8anu.Api.Data.Repositories
{
    public class AscentsRepository:Repository<Ascent>, IAscentsRepository
    {
        public AscentsRepository(DomainModelMySqlContext context) : base(context)
        {
        }
        
        public List<Ascent> GetAllForZlaggable(int routeId, ZlaggableCategoryEnum category, int pageIndex = 0, int pageSize = 50, string sortField = "")
        {
            var zlaggableType = category.Equals(ZlaggableCategoryEnum.Sportclimbing) ? "Route" : "Boulder";

            IQueryable<Ascent> ascents = Context.Set<Ascent>()
                .Where(a => a.ZlaggableType.Equals(zlaggableType) && a.ZlaggableId.Equals(routeId))
                .Include(a => a.User);
            
            sortField = sortField.Trim().ToLower();
            
            if (string.IsNullOrWhiteSpace(sortField))
            {
                sortField = "date_desc";
            }
            
            var sortOrderDescending = sortField.EndsWith("_desc");
            if (sortOrderDescending)
            {
                sortField = sortField.Replace("_desc", "");
            }

            switch (sortField)
            {
                case "username":
                    ascents = sortOrderDescending ? ascents.OrderByDescending(a => a.User.FirstName) : ascents.OrderBy(a => a.User.FirstName);
                    break;
                case "date":
                    ascents = sortOrderDescending ? ascents.OrderByDescending(a => a.Date) : ascents.OrderBy(a => a.Date);
                    break;
                
                case "style":
                    ascents = sortOrderDescending ? ascents.OrderByDescending(a => a.Style) : ascents.OrderBy(a => a.Style);
                    break;
                
                case "notes":
                    ascents = sortOrderDescending ? ascents.OrderByDescending(a => a.Note) : ascents.OrderBy(a => a.Note);
                    break;
                
                case "rating":
                    ascents = sortOrderDescending ? ascents.OrderByDescending(a => a.Rating) : ascents.OrderBy(a => a.Rating);
                    break;
                
                default:
                    ascents = sortOrderDescending ? ascents.OrderByDescending(a => a.Date) : ascents.OrderBy(a => a.Date);
                    break;
            }

            return ascents.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
        
        public async Task<Dictionary<string, ZlaggableWithStatistics>> GetZlaggablesWithStatistics(Dictionary<int, SectorWithStatistics> sectors)
        {            
            var routes = await Context.Set<Route>()
                .Select(r => new ZlaggableWithStatistics
                {
                    DatabaseId = r.Id.Value,
                    Slug = r.Slug,
                    Name = r.Name,
                    Category = ZlaggableCategoryEnum.Sportclimbing,
                    Difficulty = r.Difficulty,
                    GradeIndex = Convert.ToInt32(r.Grade.Substring(3)),
                    Grades = new Dictionary<int, int>() { { Convert.ToInt32(r.Grade.Substring(3)), 1 } }, // add to Grades here...
                    Parent = sectors[r.SectorId]
                })
                .ToDictionaryAsync(k => k.DatabaseId + ".0", v => v);
            
            var boulders = await Context.Set<Boulder>()
                .Select(r => new ZlaggableWithStatistics
                {
                    DatabaseId = r.Id.Value,
                    Slug = r.Slug,
                    Name = r.Name,
                    Category = ZlaggableCategoryEnum.Bouldering,
                    Difficulty = r.Difficulty,
                    GradeIndex = Convert.ToInt32(r.Grade.Substring(3)),
                    Grades = new Dictionary<int, int>() { { Convert.ToInt32(r.Grade.Substring(3)), 1 } }, // add to Grades here...
                    Parent = sectors[r.SectorId]
                })
                .ToDictionaryAsync(k => k.DatabaseId + ".1", v => v);


            var zlaggables = routes.Concat(boulders).ToDictionary(k => k.Key, v => v.Value);
            
            await FillStatistics(zlaggables);

            return zlaggables;
        }


        private async Task FillStatistics(Dictionary<string, ZlaggableWithStatistics> zlags)
        {
            var conn = Context.Database.GetDbConnection();

            try
            {
                await conn.OpenAsync();
                

                string query =
                    @"set @yearDate = DATE_SUB(CURDATE(), INTERVAL 365 DAY);
select a.zlaggable_id, 
(IF (a.zlaggable_type = 'Route', 0, 1)) `category`, 
COUNT(a.id) `total_ascents`, 
COUNT(a.date >= @yearDate OR null) `total_ascents_1year`,
COUNT(a.recommended OR NULL) `total_recommended`, 
AVG(IF (a.rating > 0, a.rating, NULL)) `average_rating`,
COUNT(a.type = 'f' OR NULL) `total_flash`,
COUNT(a.type = 'rp' OR NULL) `total_redpoint`,
COUNT(a.type = 'os' OR NULL) `total_onsight`,
COUNT(a.type = 'tr' OR NULL) `total_try`,
COUNT(a.type = 'go' OR NULL) `total_go`,
COUNT(MONTH(a.date) = '1' OR NULL) `jan`,
COUNT(MONTH(a.date) = '2' OR NULL) `feb`,
COUNT(MONTH(a.date) = '3' OR NULL) `mar`,
COUNT(MONTH(a.date) = '4' OR NULL) `apr`,
COUNT(MONTH(a.date) = '5' OR NULL) `may`,
COUNT(MONTH(a.date) = '6' OR NULL) `jun`,
COUNT(MONTH(a.date) = '7' OR NULL) `jul`,
COUNT(MONTH(a.date) = '8' OR NULL) `aug`,
COUNT(MONTH(a.date) = '9' OR NULL) `sep`,
COUNT(MONTH(a.date) = '10' OR NULL) `oct`,
COUNT(MONTH(a.date) = '11' OR NULL) `nov`,
COUNT(MONTH(a.date) = '12' OR NULL) `dec`
from ascents `a`
group by a.zlaggable_id, a.zlaggable_type
order by a.zlaggable_id, a.zlaggable_type";

                query += ";";
                
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;

                    var reader = await cmd.ExecuteReaderAsync();
                    
                    if (!reader.HasRows) return;
                    
                    while (await reader.ReadAsync())
                    {
                        var zlaggableId = reader.GetInt32(0);
                        var categoryId = reader.GetInt32(1);                      // 0 = Route, 1 = Boulder
                        
                        // get zlaggable
                        var zId = zlaggableId.ToString() + "." + categoryId.ToString();
                        if (!zlags.ContainsKey(zId))
                        {
                            Console.WriteLine("Zlaggable id: " + zId + " not found");
                            continue;
                        }
                        var zlaggable = zlags[zId];
                        
                        
                        var totalAscents = reader.GetInt32(2);                    // count of ascents in this type
                        var totalAscents1Year = reader.GetInt32(3);               // count of ascents in this type
                        var totalRecommended = reader.GetInt32(4);                // total recommended ascents

                        float? averageRating = null;
                        if (!reader.IsDBNull(5))
                        {
                            var val = reader.GetDecimal(5);
                            averageRating = Convert.ToSingle(val);
                        }

                        var totalFlash = reader.GetInt32(6);
                        var totalRedpoint = reader.GetInt32(7);
                        var totalOnsight = reader.GetInt32(8);
                        var totalTopRope = reader.GetInt32(9);
                        var totalGo = reader.GetInt32(10);

                        int[] season = { 
                            reader.GetInt32(11), //jan
                            reader.GetInt32(12), //feb
                            reader.GetInt32(13), //march
                            reader.GetInt32(14), //apr
                            reader.GetInt32(15), //may
                            reader.GetInt32(16), //jun
                            reader.GetInt32(17), //jul
                            reader.GetInt32(18), //aug
                            reader.GetInt32(19), //sep
                            reader.GetInt32(20), //oct
                            reader.GetInt32(21), //nov
                            reader.GetInt32(22) //dec
                        };

                        zlaggable.Season = season;
                        zlaggable.TotalAscents = totalAscents;
                        zlaggable.TotalAscents1Year = totalAscents1Year;
                        zlaggable.TotalRecommended = totalRecommended;
                        zlaggable.AverageRating = averageRating;
                        zlaggable.TotalAscentsFlash = totalFlash;
                        zlaggable.TotalAscentsRedPoint = totalRedpoint;
                        zlaggable.TotalAscentsOnsight = totalOnsight;
                        zlaggable.TotalAscentsTopRope = totalTopRope;
                        zlaggable.TotalAscentsGo = totalGo;
                        
                        zlaggable.CalculateTotals();
                    }

                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public HashSet<AscentWithUserInfo> GetAscentsWithUserInfo(Dictionary<string, ZlaggableWithStatistics> zlaggables)
        {
            /*
            var ascents = Context.Set<Ascent>()
                .Include(a => a.User)
                .Select(a => CreateNewAscentWithUserInfo(a, zlaggables))
                .ToHashSet();
            */

            var myascents = Context.Set<Ascent>()
                .Include(a => a.User)
                .Select(a => new AscentWithUserInfo()
                {
                    DatabaseId = a.Id.Value,
                    UserId = a.User.Id.Value,
                    UserSlug = a.User.Slug,
                    UserFirstName = a.User.FirstName,
                    UserLastName = a.User.LastName,
                    // UserImageUrl = a.User.
                    Date = a.Date,
                    Type = a.Type,
                    Rating = a.Rating,
                    Project = a.Project,
                    Tries = a.Tries,
                    Repeat = a.Repeat,
                    Difficulty = a.Difficulty,
                    Steepness = a.Steepness,
                    Protection = a.Protection,
                    Style = a.Style,
                    Comment = a.Comment,
                    ZlaggableId = a.ZlaggableId,
                    ZlaggableKey = a.ZlaggableKey,
                    ZlaggableType = a.ZlaggableType,
                    Height = a.Height,
                    Score = a.Score,
                    Sits = a.Sits,
                    ExcludeFromRanking = a.ExcludeFromRanking,
                    Chipped = a.Chipped,
                    Note = a.Note,
                    Recommended = a.Recommended,
                    LegacyId = a.LegacyId,
                    DateCreated = a.DateCreated,
                    DateModified = a.DateModified,
                });

            HashSet<AscentWithUserInfo> ascents = new HashSet<AscentWithUserInfo>();
            var _count = 0;
            foreach (var ascent in myascents)
            {
                _count++;
                if (_count % 100000 == 0)
                {
                    Console.WriteLine("got now " + _count + " ascents from DB");
                }
                
                var category = ascent.ZlaggableType.Trim().ToLower().Equals("route")
                    ? ZlaggableCategoryEnum.Sportclimbing
                    : ZlaggableCategoryEnum.Bouldering;
            
                string key = ascent.ZlaggableId + (category == ZlaggableCategoryEnum.Sportclimbing ? ".0" : ".1");
                if (!zlaggables.ContainsKey(key))
                {
                    Console.WriteLine("no zlaggable found for ascent: " + ascent.ZlaggableType + " id: " + ascent.ZlaggableId);
                    continue;
                }
                var zlaggable = zlaggables[key];

                ascent.GradeIndex = zlaggable.GradeIndex;
                ascent.NavigationInfo = GetNavigationInfo(zlaggable);
                ascent.Category = category;

                ascents.Add(ascent);
            }

            Console.WriteLine("got ascents bangers");
            
            return ascents;
        }

        private CragNavigationInfo GetNavigationInfo(ZlaggableWithStatistics zlaggable)
        {
            var info = new CragNavigationInfo()
            {
                AreaId = zlaggable.AreaId,
                AreaSlug = zlaggable.AreaSlug,
                AreaName = zlaggable.AreaName,
                CragId = zlaggable.CragId,
                CragSlug = zlaggable.CragSlug,
                CragName = zlaggable.CragName,
                SectorId = zlaggable.SectorId,
                SectorSlug = zlaggable.SectorSlug,
                SectorName = zlaggable.SectorName,
                ZlaggableId = zlaggable.DatabaseId,
                ZlaggableSlug = zlaggable.Slug,
                ZlaggableName = zlaggable.Name,
                CountrySlug = zlaggable.CountrySlug,
                CountryName = zlaggable.CountryName
            };

            return info;
        }
    }
}