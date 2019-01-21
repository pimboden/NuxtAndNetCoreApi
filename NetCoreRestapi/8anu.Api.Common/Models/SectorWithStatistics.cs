using System.Collections.Generic;
using Nest;
using Newtonsoft.Json;
using _8anu.Api.Common.Enums;

namespace _8anu.Api.Common.Models
{
    [ElasticsearchType(Name = "sector")]
    public class SectorWithStatistics : WithStatisticsBase
    {
        public int? AreaId { get; set; }
        [Keyword]
        public string AreaSlug { get; set; }
        public string AreaName { get; set; }
        public int CragId { get; set; }
        [Keyword]
        public string CragSlug { get; set; }
        public string CragName { get; set; }
        
        public string CountryName { get; set; }
        [Keyword]
        public string CountrySlug { get; set; }
        public ZlaggableCategoryEnum Category { get; set; }

        
        [Ignore, JsonIgnore]
        public CragWithStatistics Crag
        {
            get => (CragWithStatistics) Parent;
            set => Parent = value;
        }
        
        [JsonIgnore] // ignore so we don't get problems with serializing
        public List<WithStatisticsBase> Zlaggables
        {
            get => base.Children;
            set => base.Children = value;
        }
    }
}