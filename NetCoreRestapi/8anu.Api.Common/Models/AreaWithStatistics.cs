using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Nest;
using Nest.JsonNetSerializer;
using Newtonsoft.Json;


namespace _8anu.Api.Common.Models
{
    [ElasticsearchType(Name = "area")]
    public class AreaWithStatistics : WithStatisticsBase
    {
        public string CountryName { get; set; }
        
        [Keyword]
        public string CountrySlug { get; set; }
        public DateTime DateCreated { get; set; }

        [Ignore, JsonIgnore]
        public List<WithStatisticsBase> Crags
        {
            get => base.Children;
            set => base.Children = value;
        }

        public int TotalCrags => TotalChildren;
        public int TotalSectors
        {
            get { return Crags.Sum(c => c.Children.Count); }
        }
    }
}