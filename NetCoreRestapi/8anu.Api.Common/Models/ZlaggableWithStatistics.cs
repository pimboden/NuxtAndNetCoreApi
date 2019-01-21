using System.Reflection.Metadata.Ecma335;
using Nest;
using Newtonsoft.Json;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Enums;
using Nest.JsonNetSerializer;

namespace _8anu.Api.Common.Models
{
    [ElasticsearchType(Name = "zlaggable")]
    public class ZlaggableWithStatistics : WithStatisticsBase
    {
        public string Difficulty { get; set; }
        public int GradeIndex { get; set; }
        
        public ZlaggableWithStatistics()
        {
            // let's set zlaggablecount to 1
            TotalZlaggables = 1;
        }
        
        public int? AreaId { get; set; }
        [Keyword]
        public string AreaSlug { get; set; }
        public string AreaName { get; set; }
        public int CragId { get; set; }
        [Keyword]
        public string CragSlug { get; set; }
        public string CragName { get; set; }
        public int SectorId { get; set; }
        [Keyword]
        public string SectorSlug { get; set; }
        public string SectorName { get; set; }
        public string CountryName { get; set; }
        [Keyword]
        public string CountrySlug { get; set; }

        public ZlaggableCategoryEnum Category { get; set; }
        [Ignore, JsonIgnore]
        public SectorWithStatistics Sector
        {
            get => (SectorWithStatistics) Parent;
            set => Parent = value;
        }

        private SectorWithStatistics _parent;
        [Ignore, JsonIgnore]
        public new SectorWithStatistics Parent
        {
            get => _parent;

            set
            {
                _parent = value;
                _parent.Children.Add(this);

                AreaId = value.AreaId;
                AreaSlug = value.AreaSlug;
                AreaName = value.AreaName;
                CragId = value.CragId;
                CragSlug = value.CragSlug;
                CragName = value.CragName;
                SectorId = value.DatabaseId;
                SectorSlug = value.Slug;
                SectorName = value.Name;
                CountryName = value.Crag.CountryName;
                CountrySlug = value.Crag.CountrySlug;
            }
        }

        /*
        public new void CalculateTotals()
        {
            var totalAscentsDouble = (float) TotalAscents;
            
            AscentRate1Year = TotalAscents1Year / totalAscentsDouble;
            TotalRecommendedRate = TotalRecommended / totalAscentsDouble;
            FlashRate = TotalAscentsFlash / totalAscentsDouble;
            OnsightRate = TotalAscentsOnsight / totalAscentsDouble;
            FlashOnsightRate = (TotalAscentsFlash + TotalAscentsOnsight) / totalAscentsDouble;
            RedPointRate = TotalAscentsRedPoint / totalAscentsDouble;
            GoRate = TotalAscentsGo / totalAscentsDouble;
            TopRopeRate = TotalAscentsTopRope / totalAscentsDouble;
        }
        */
    }
}