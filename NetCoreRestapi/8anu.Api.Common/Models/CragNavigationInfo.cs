using Nest;

namespace _8anu.Api.Common.Models
{
    public class CragNavigationInfo
    {
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
        public int ZlaggableId { get; set; }
        [Keyword]
        public string ZlaggableSlug { get; set; }
        public string ZlaggableName { get; set; }
        public string CountryName { get; set; }
        [Keyword]
        public string CountrySlug { get; set; }        
    }
}