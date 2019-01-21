using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Nest;
using Nest.JsonNetSerializer;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Managers.Services
{
    public class ElasticService : IElasticService
    {
        private readonly IConfiguration _configuration;

        private readonly Dictionary<string, string> _indexes = new Dictionary<string, string>
        {
            {"areas", "area"},
            {"crags", "crag"},
            // {"sectors", "sector"},
            {"zlaggables", "zlaggable"}
        };
        
        public ElasticService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool AreIndexesCreated
        {
            get
            {
                // we test here if crags index is created, if not it means indexes are not created
                var client = GetElasticClient();
                var request = new IndexExistsRequest("crags");
                var exitstResult = client.IndexExists(request);
                return exitstResult.Exists;
            }
        }

        public bool IsAscentIndexCreated
        {
            get
            {
                // we test here if crags index is created, if not it means indexes are not created
                var client = GetElasticClient();
                var request = new IndexExistsRequest("ascents");
                var exitstResult = client.IndexExists(request);
                return exitstResult.Exists;
            }
        }

        private ElasticClient GetElasticClient()
        {
            var elasticUri = _configuration.GetSection("AppSettings")["ElasticSearchUri"];
            var pool = new SingleNodeConnectionPool(new Uri(elasticUri));
            var connectionSettings =
                new ConnectionSettings(pool, sourceSerializer: (builtin, settings) => new JsonNetSerializer(
                        builtin, settings,
                        () => new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Include,
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        },
                        resolver => resolver.NamingStrategy = new CamelCaseNamingStrategy()
                    ))
                    
                    .DefaultMappingFor<AreaWithStatistics>(i => i
                        .TypeName("area")
                        .IndexName("areas")
                    )
                    .DefaultMappingFor<CragWithStatistics>(i => i
                        .TypeName("crag")
                        .IndexName("crags")
                    )
                    .DefaultMappingFor<SectorWithStatistics>(i => i
                        .TypeName("sector")
                        .IndexName("sectors"))
                    .DefaultMappingFor<ZlaggableWithStatistics>(i => i
                        .TypeName("zlaggable")
                        .IndexName("zlaggables"))
                    .DefaultMappingFor<AscentWithUserInfo>(i => i
                        .TypeName("ascent")
                        .IndexName("ascents"))
                    .DefaultIndex("crags");
                    
                    
            var client = new ElasticClient(connectionSettings);
            
            return client;
        }
        
        public void CreateElasticSearchIndexesForStatistics(
            Dictionary<int, AreaWithStatistics> areas, 
            Dictionary<int, CragWithStatistics> crags,
            Dictionary<int, SectorWithStatistics> sectors,
            Dictionary<string, ZlaggableWithStatistics> zlaggables
            )
        {
            // so we're getting our info from here: 
            // https://github.com/elastic/elasticsearch-net-example/tree/5.x-netcore
            
            Console.WriteLine("start building elastic-index for statistics");
            var timer = Stopwatch.StartNew();

            var client = GetElasticClient();
            
            // for now we just check if crags exists and go on with our lives
            if (AreIndexesCreated)
            {
                Console.WriteLine("Elastic index is already created so do nothing");
                return;
            }

            var mycrags = crags.Values.ToList();
            var mysectors = sectors.Values.ToList();
            var myzlaggables = zlaggables.Values.ToList();
            var myareas = areas.Values.ToList();

            const int pageSize = 1000; // how many to buld insert at once
            
            Console.WriteLine("start adding crags to elastic index");
            client.CreateIndex("crags", c => c
                .Mappings(ms => ms
                    .Map<CragWithStatistics>(m => m.AutoMap())
                )
            );
            for (var i = 0; i < mycrags.Count; i+=pageSize)
            {
                var items = mycrags.Skip(i).Take(pageSize);
                var result = client.Bulk(b => b.IndexMany(items));
                if (!result.IsValid)
                {
                    Console.WriteLine(result.DebugInformation);
                }    
            }
            
            Console.WriteLine("start adding areas to elastic index");
            client.CreateIndex("areas", c => c
                .Mappings(ms => ms
                    .Map<AreaWithStatistics>(m => m.AutoMap())
                )
            );
            for (var i = 0; i < myareas.Count; i+=pageSize)
            {
                var items = myareas.Skip(i).Take(pageSize);
                var result = client.Bulk(b => b.IndexMany(items));
                if (!result.IsValid)
                {
                    Console.WriteLine(result.DebugInformation);
                }    
            }
            
            Console.WriteLine("start adding sectors to elastic index");
            client.CreateIndex("sectors", c => c
                .Mappings(ms => ms
                    .Map<SectorWithStatistics>(m => m.AutoMap())
                )
            );
            for (var i = 0; i < mysectors.Count; i+=pageSize)
            {
                var items = mysectors.Skip(i).Take(pageSize);
                var result = client.Bulk(b => b.IndexMany(items));
                if (!result.IsValid)
                {
                    Console.WriteLine(result.DebugInformation);
                }    
            }
            
            Console.WriteLine("start adding zlaggables to elastic index");
            client.CreateIndex("zlaggables", c => c
                .Mappings(ms => ms
                    .Map<ZlaggableWithStatistics>(m => m.AutoMap())
                )
            );
            for (var i = 0; i < myzlaggables.Count; i+=pageSize)
            {
                var items = myzlaggables.Skip(i).Take(pageSize);
                var result = client.Bulk(b => b.IndexMany(items));
                if (!result.IsValid)
                {
                    Console.WriteLine(result.DebugInformation);
                }    
            }
            
            timer.Stop();
            var timespan = timer.Elapsed;
            var msg = "Completed building elastic index for statistics! took " + String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);
            Console.WriteLine(msg);
        }

        public void CreateElasticSearchIndexForAscents(HashSet<AscentWithUserInfo> ascents)
        {
            Console.WriteLine("start building elastic-index for statistics");
            var timer = Stopwatch.StartNew();
            
            if (IsAscentIndexCreated)
            {
                Console.WriteLine("ascent index already created, do nothing");
                return;
            }
            
            var client = GetElasticClient();

            const int pageSize = 1000; // how many to buld insert at once
            
            Console.WriteLine("start adding ascents to elastic index");
            client.CreateIndex("ascents", c => c
                .Mappings(ms => ms
                    .Map<AscentWithUserInfo>(m => m.AutoMap())
                )
            );
            for (var i = 0; i < ascents.Count; i+=pageSize)
            {
                var items = ascents.Skip(i).Take(pageSize);
                var result = client.Bulk(b => b.IndexMany(items));
                if (!result.IsValid)
                {
                    Console.WriteLine(result.DebugInformation);
                }    
            }
            
            timer.Stop();
            var timespan = timer.Elapsed;
            var msg = "Completed building elastic index for ascents! took " + String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);
            Console.WriteLine(msg);
        }
        
        public List<SearchResult> Search(string query, string category = "")
        {
            var client = GetElasticClient();

            // we'll use multisearch here to get results from 
            // multiple indexes
            // https://www.elastic.co/guide/en/elasticsearch/reference/current/search-multi-search.html
            // .net example:
            // https://discuss.elastic.co/t/elasticsearch-net-and-multisearch/96602/4
            //
            // USE NEST if wanting to return strongly typed objects
            // here lowlevel client is used
            /*
            var searchResponse = client.LowLevel.Msearch<DynamicResponse>(PostData.MultiJson(new object[]
            {
                new { index = "areas" },
                new { query = new { match = new { name = query } }, from = 0, size = 5 },
                new { index = "crags" },
                new { query = new { match = new { name = query } }, from = 0, size = 5 },
                new { index = "sectors" },
                new { query = new { match = new { name = query } }, from = 0, size = 5 },
                new { index = "zlaggables" },
                new { query = new { match = new { name = query } }, from = 0, size = 5 }
            }));
            */

            // to add highlights:
            // https://stackoverflow.com/questions/28248681/highlight-all-fields-nest-elasticsearch

            
            // if category is defined, limit search to that categorys index
            var myIndexes = _indexes;
            var pageSize = 5; // by default we get 5 per category
            if (!string.IsNullOrWhiteSpace(category))
            {
                pageSize = 50; 
                myIndexes = new Dictionary<string, string>
                {
                    { category, _indexes[category] }
                };
            }
            
            // create request per index
            var requests = new Dictionary<string, ISearchRequest>();
            foreach (var index in myIndexes)
            {
                var request = GetSearchRequest(query, index.Key, pageSize);
                requests.Add(index.Key, request);
            }

            // create and execute multisearch
            var multiSearch = new MultiSearchRequest
            {
                Operations = requests
            };
            var multiResponse = (MultiSearchResponse) client.MultiSearch(multiSearch);
            
            // create searchresult objects from elastic search results
            var results = new List<SearchResult>();
            var i = -1; // we track the id for indexes. since response don't have the index name we need to get it from the collection
            foreach (var res in multiResponse.GetResponses<object>())
            {
                i++;
                results.Add(new SearchResult()
                {
                    Category = myIndexes.Keys.ToList()[i],
                    Count = (int) res.Total,
                    Items = res.Documents.ToList()
                });
            }
            return results;
        }

        private ISearchRequest GetSearchRequest(string query, string category, int pageSize = 50)
        {
            var request = new SearchRequest<dynamic>(category, _indexes[category])
            {
                Explain = false,
                // remove DefaultField = "name" if want to search all the fields
                Query = new QueryStringQuery() {Query = query, DefaultField = "name"},
                From = 0,
                Size = pageSize
            };
            return request;
        }

        #region areas
        
        public AreaWithStatistics GetAreaWithStatistics(string areaSlug, string countrySlug = "")
        {
            var client = GetElasticClient();
            var response = client.Search<AreaWithStatistics>(s => s
                .Query(q => q
                                .Term(z => z.Slug, areaSlug) && q
                                .Term(z => z.CountrySlug, countrySlug)
                ));

            return response.Documents.SingleOrDefault();
        }

        public List<AreaWithStatistics> GetAreasWithStatistics(string countrySlug = "", int pageIndex = 0,
            int pageSize = 50, string sortField = "")
        {
            var client = GetElasticClient();

            var descriptor = new SearchDescriptor<AreaWithStatistics>();
            descriptor.Query(q => q
                    .Term(z => z.CountrySlug, countrySlug)
                )
                .Size(pageSize)
                .Skip(pageIndex * pageSize);

            sortField = sortField.Trim().ToLower();
            
            if (string.IsNullOrWhiteSpace(sortField))
            {
                sortField = "totalascents_desc";
            }
            
            var sortOrder = sortField.EndsWith("_desc") ? SortOrder.Descending : SortOrder.Ascending;
            if (sortOrder == SortOrder.Descending)
            {
                sortField = sortField.Replace("_desc", "");
            }
            
            
            switch (sortField)
            {
                case "name":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.Name.Suffix("keyword")).Order(sortOrder)));
                    break;
                
                case "country":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.CountryName.Suffix("keyword")).Order(sortOrder)));
                    break;
                
                case "totalascents":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.TotalAscents).Order(sortOrder)));
                    break;
                
                case "averagerating":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.AverageRating).Order(sortOrder)));
                    break;
                
                default:
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.TotalAscents).Order(sortOrder)));
                    break;
            }
            
            var response = client.Search<AreaWithStatistics>(descriptor);

            return response.Documents.ToList();
        }
        
        public List<AreaWithStatistics> GetTrendingAreas(string countrySlug = "", int limit = 5)
        {
            var client = GetElasticClient();
            var response = client.Search<AreaWithStatistics>(s => s
                .Sort(ss => ss
                    .Field(f => f
                        .Field(c => c.TotalAscents1Year)
                        .Order(SortOrder.Descending)
                    )    
                )
                .Query(q => q.Term(z => z.CountrySlug, countrySlug))
                .Size(limit)
            );

            return response.Documents.ToList();
        }
        
        public List<AreaWithStatistics> GetLatestAreas(string countrySlug = "", int limit = 5)
        {
            var client = GetElasticClient();
            var response = client.Search<AreaWithStatistics>(s => s
                .Sort(ss => ss
                    .Field(f => f
                        .Field(c => c.DateCreated)
                        .Order(SortOrder.Descending)
                    )    
                )
                .Query(q => q.Term(z => z.CountrySlug, countrySlug))
                .Size(limit)
            );

            return response.Documents.ToList();
        }
        
        #endregion
        
        #region crags
        
        public CragWithStatistics GetCragWithStatistics(string cragSlug, string countrySlug, ZlaggableCategoryEnum category)
        {
            var client = GetElasticClient();
            var response = client.Search<CragWithStatistics>(s => s
                .Query(q => q
                                .Term(o => o.Slug, cragSlug) && q
                                .Term(o => o.CountrySlug, countrySlug) && q
                                .Term(o => o.Category, category)
                ));

            return response.Documents.SingleOrDefault();
        }
        
        public List<CragWithStatistics> GetCragsWithStatisticsByCategory(ZlaggableCategoryEnum category,
            string countrySlug = "", int pageIndex = 0, int pageSize = 50, string sortField = "")
        {
            var client = GetElasticClient();
            
            var descriptor = new SearchDescriptor<CragWithStatistics>();
            descriptor.Query(q => q
                                      .Term(c => c.Category, category) && q
                                      .Term(z => z.CountrySlug, countrySlug)

                )
                .Size(pageSize)
                .Skip(pageIndex * pageSize);

            sortField = sortField.Trim().ToLower();
            
            if (string.IsNullOrWhiteSpace(sortField))
            {
                sortField = "totalascents_desc";
            }
            
            var sortOrder = sortField.EndsWith("_desc") ? SortOrder.Descending : SortOrder.Ascending;
            if (sortOrder == SortOrder.Descending)
            {
                sortField = sortField.Replace("_desc", "");
            }
            
            
            switch (sortField)
            {
                case "name":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.Name.Suffix("keyword")).Order(sortOrder)));
                    break;
                
                case "country":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.CountryName.Suffix("keyword")).Order(sortOrder)));
                    break;
                
                case "totalascents":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.TotalAscents).Order(sortOrder)));
                    break;
                
                case "averagerating":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.AverageRating).Order(sortOrder)));
                    break;
                
                default:
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.TotalAscents).Order(sortOrder)));
                    break;
            }
            
            var response = client.Search<CragWithStatistics>(descriptor);
            
            return response.Documents.ToList();
        }

        public List<CragWithStatistics> GetTrendingCrags(string countrySlug = "", int limit = 5)
        {
            var client = GetElasticClient();
            var response = client.Search<CragWithStatistics>(s => s
                .Sort(ss => ss
                    .Field(f => f
                        .Field(c => c.TotalAscents1Year)
                        .Order(SortOrder.Descending)
                    )    
                )
                .Query(q => q.Term(z => z.CountrySlug, countrySlug))
                .Size(limit)
            );

            return response.Documents.ToList();
        }
        
        public List<CragWithStatistics> GetLatestCrags(string countrySlug = "", int limit = 5)
        {
            var client = GetElasticClient();
            var response = client.Search<CragWithStatistics>(s => s
                .Sort(ss => ss
                    .Field(f => f
                        .Field(c => c.DateCreated)
                        .Order(SortOrder.Descending)
                    )    
                )
                .Query(q => q.Term(z => z.CountrySlug, countrySlug))
                .Size(limit)
            );

            return response.Documents.ToList();
        }

        public List<CragWithStatistics> GetCragsWithStatisticsForArea(string areaSlug, string countrySlug = "",
            int pageIndex = 0, int pageSize = 50, string sortField = "")
        {   
            var client = GetElasticClient();
            
            var descriptor = new SearchDescriptor<CragWithStatistics>();
            descriptor.Query(q => q
                                      .Term(c => c.AreaSlug, areaSlug) && q
                                      .Term(z => z.CountrySlug, countrySlug)

                )
                .Size(pageSize)
                .Skip(pageIndex * pageSize);

            sortField = sortField.Trim().ToLower();
            
            if (string.IsNullOrWhiteSpace(sortField))
            {
                sortField = "totalascents_desc";
            }
            
            var sortOrder = sortField.EndsWith("_desc") ? SortOrder.Descending : SortOrder.Ascending;
            if (sortOrder == SortOrder.Descending)
            {
                sortField = sortField.Replace("_desc", "");
            }
            
            
            switch (sortField)
            {
                case "name":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.Name.Suffix("keyword")).Order(sortOrder)));
                    break;
                
                case "country":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.CountryName.Suffix("keyword")).Order(sortOrder)));
                    break;
                
                case "totalascents":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.TotalAscents).Order(sortOrder)));
                    break;
                
                case "averagerating":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.AverageRating).Order(sortOrder)));
                    break;
                
                default:
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.TotalAscents).Order(sortOrder)));
                    break;
            }
            
            var response = client.Search<CragWithStatistics>(descriptor);
            
            return response.Documents.ToList();
        }
        
        #endregion
        
        #region zlaggables
        
        public ZlaggableWithStatistics GetZlaggableWithStatistics(string zlaggableSlug, ZlaggableCategoryEnum category, string sectorSlug)
        {
            var client = GetElasticClient();
            var response = client.Search<ZlaggableWithStatistics>(s => s
                .Query(q => q
                                .Term(z => z.Slug, zlaggableSlug) && q
                                .Term(z => z.SectorSlug, sectorSlug) && q
                                .Term(z => z.Category, category)
                ));

            return response.Documents.SingleOrDefault();
        }

        public SearchResult GetZlaggablesWithStatisticsForCrag(string cragSlug, string countrySlug, ZlaggableCategoryEnum category,
            string sectorSlug = "", int pageIndex = 0, int pageSize = 50, string sortField = "", int? minGrade = null, int? maxGrade = null)
        {
            var client = GetElasticClient();
            
            
            var descriptor = new SearchDescriptor<ZlaggableWithStatistics>();
            
           descriptor
                .Size(pageSize)
                .Skip(pageIndex * pageSize);

            if (minGrade.HasValue && maxGrade.HasValue)
            {
                descriptor.Query(q => q
                  .Term(o => o.CragSlug, cragSlug) && q
                  .Term(o => o.SectorSlug, sectorSlug) && q
                  .Term(o => o.CountrySlug, countrySlug) && q
                  .Term(o => o.Category, category) && q
                    .Range(c => c
                    .Field(z => z.GradeIndex)
                    .GreaterThanOrEquals(minGrade.Value)
                    .LessThanOrEquals(maxGrade.Value)));
            }
            else
            {
                descriptor.Query(q => q
                                          .Term(o => o.CragSlug, cragSlug) && q
                                          .Term(o => o.SectorSlug, sectorSlug) && q
                                          .Term(o => o.CountrySlug, countrySlug) && q
                                          .Term(o => o.Category, category)
                );
            }
                       
            sortField = sortField.Trim().ToLower();
            
            if (string.IsNullOrWhiteSpace(sortField))
            {
                sortField = "totalascents_desc";
            }
            
            var sortOrder = sortField.EndsWith("_desc") ? SortOrder.Descending : SortOrder.Ascending;
            if (sortOrder == SortOrder.Descending)
            {
                sortField = sortField.Replace("_desc", "");
            }
            
            
            switch (sortField)
            {
                case "grade":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.GradeIndex).Order(sortOrder)));
                    break;
                case "name":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.Name.Suffix("keyword")).Order(sortOrder)));
                    break;
                
                case "totalascents":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.TotalAscents).Order(sortOrder)));
                    break;
                
                case "ratio":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.FlashOnsightRate).Order(sortOrder)));
                    break;
                
                case "recommended":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.TotalRecommendedRate).Order(sortOrder)));
                    break;
                
                case "stars":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.AverageRating).Order(sortOrder)));
                    break;
                
                default:
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.TotalAscents).Order(sortOrder)));
                    break;
            }
            
            var response = client.Search<ZlaggableWithStatistics>(descriptor);

            var result = new SearchResult()
            {
                Count = (int) response.Total,
                Items = response.Documents.ToList<object>()
            };
            
            return result;
        }

        public SearchResult GetZlaggablesWithStatisticsForArea(string areaSlug, string countrySlug, int pageIndex = 0, int pageSize = 50, string sortField = "", int? minGrade = null, int? maxGrade = null)
        {
            var client = GetElasticClient();
            
            
            var descriptor = new SearchDescriptor<ZlaggableWithStatistics>();
            descriptor
                .Size(pageSize)
                .Skip(pageIndex * pageSize);

            
            if (minGrade.HasValue && maxGrade.HasValue)
            {
                descriptor.Query(q => q
                  .Term(o => o.AreaSlug, areaSlug) && q
                  .Term(o => o.CountrySlug, countrySlug) && q
                  .Range(c => c
                      .Field(z => z.GradeIndex)
                      .GreaterThanOrEquals(minGrade.Value)
                      .LessThanOrEquals(maxGrade.Value)));
            }
            else
            {
                descriptor.Query(q => q
                      .Term(o => o.AreaSlug, areaSlug) && q
                      .Term(o => o.CountrySlug, countrySlug)
                );
            }
            
            sortField = sortField.Trim().ToLower();
            
            if (string.IsNullOrWhiteSpace(sortField))
            {
                sortField = "totalascents_desc";
            }
            
            var sortOrder = sortField.EndsWith("_desc") ? SortOrder.Descending : SortOrder.Ascending;
            if (sortOrder == SortOrder.Descending)
            {
                sortField = sortField.Replace("_desc", "");
            }
            
            
            switch (sortField)
            {
                case "grade":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.GradeIndex).Order(sortOrder)));
                    break;
                case "name":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.Name.Suffix("keyword")).Order(sortOrder)));
                    break;
                
                case "totalascents":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.TotalAscents).Order(sortOrder)));
                    break;
                
                case "ratio":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.FlashOnsightRate).Order(sortOrder)));
                    break;
                
                case "recommended":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.TotalRecommendedRate).Order(sortOrder)));
                    break;
                
                case "stars":
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.AverageRating).Order(sortOrder)));
                    break;
                
                default:
                    descriptor.Sort(ss => ss.Field(f => f.Field(c => c.TotalAscents).Order(sortOrder)));
                    break;
            }
            
            var response = client.Search<ZlaggableWithStatistics>(descriptor);

            var result = new SearchResult()
            {
                Count = (int) response.Total,
                Items = response.Documents.ToList<object>()
            };
            
            return result;
        }

        #endregion
        
        #region sectors

        public List<SectorWithStatistics> GetSectorsWithStatisticsForCrag(string cragSlug, string countrySlug, ZlaggableCategoryEnum category)
        {
            var client = GetElasticClient();
            var response = client.Search<SectorWithStatistics>(s => s
                .Sort(ss => ss
                    .Field(f => f
                        .Field(c => c.Name.Suffix("keyword"))
                        .Order(SortOrder.Ascending)
                    )
                )
                .Query(q => q
                    .Term(o => o.CragSlug, cragSlug) && q
                    .Term(o => o.CountrySlug, countrySlug) && q
                    .Term(o => o.Category, category)

                )
                .Size(10000)
            );
            
            return response.Documents.ToList();
        }

        public List<SectorWithStatistics> GetSectorsWithStatisticsForCragWithPaging(string cragSlug, string cragCountry, ZlaggableCategoryEnum category,
            int pageIndex = 0, int pageSize = 50)
        {
            var client = GetElasticClient();
            var response = client.Search<SectorWithStatistics>(s => s
                .Sort(ss => ss
                    .Field(f => f
                        .Field(c => c.Name)
                        .Order(SortOrder.Ascending)
                    )    
                )
                .Query(q => q
                                .Term(o => o.CragSlug, cragSlug) && q
                                .Term(o => o.CountrySlug, cragCountry) && q
                                .Term(o => o.Category, category)
                
                )
                .Size(pageSize)
                .Skip(pageIndex * pageSize)
            );

            return response.Documents.ToList();
        }

        #endregion
    }
}