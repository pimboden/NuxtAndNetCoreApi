using System;
using System.Collections.Generic;
using Nest;
using Newtonsoft.Json;
using _8anu.Api.Common.Enums;

namespace _8anu.Api.Common.Models
{
    [ElasticsearchType(Name = "crag")]
    public class CragWithStatistics : WithStatisticsBase
    {
        public string CountryName { get; set; }
        [Keyword]
        public string CountrySlug { get; set; }
        public ZlaggableCategoryEnum Category { get; set; }
        public DateTime DateCreated { get; set; }
        public int? AreaId { get; set; }
        [Keyword]
        public string AreaSlug { get; set; }
        public string AreaName { get; set; }
        
        [Ignore, JsonIgnore] // ignore so we don't get problems with serializing
        public List<WithStatisticsBase> Sectors
        {
            get => base.Children;
            set => base.Children = value;
        }
    
        [Ignore, JsonIgnore]
        public AreaWithStatistics Area
        {
            get => (AreaWithStatistics) Parent;
            set => Parent = value;
        }

        public int TotalSectors => TotalChildren;
    }
}