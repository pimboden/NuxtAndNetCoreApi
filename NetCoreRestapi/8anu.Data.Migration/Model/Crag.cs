using System;

namespace _8anu.Data.Migration.Model
{
    public partial class Crag
    {
        public uint Id { get; set; }
        public string Slug { get; set; }
        public string CountryId { get; set; }
        public string Name { get; set; }
        public string Sname { get; set; }
        public string City { get; set; }
        public DateTime EditDate { get; set; }
        public float Rate { get; set; }
        public int Ascents { get; set; }
        public float AscentRate { get; set; }
        public DateTime AscentEditDate { get; set; }
        public float AscentOs { get; set; }
        public int Active { get; set; }
        public float Dbscore { get; set; }
        public float TotalRate { get; set; }
        public string DriveTime { get; set; }
        public string GoggleMapX { get; set; }
        public string GoggleMapY { get; set; }
        public int Type { get; set; }
        public string AccessInfo { get; set; }
        public int CragAreaId { get; set; }
        public float AscentRate1year { get; set; }
        public int Ascents1year { get; set; }
    }
}
