using System;

namespace _8anu.Data.Migration.Model
{
    public partial class Score
    {
        public uint Id { get; set; }
        public uint UserId { get; set; }
        public string Date { get; set; }
        public byte Grade { get; set; }
        public byte? Altgrade { get; set; }
        public byte How { get; set; }
        public string Name { get; set; }
        public string Crag { get; set; }
        public string Comment { get; set; }
        public byte Rate { get; set; }
        public byte What { get; set; }
        public uint Fa { get; set; }
        public string Country { get; set; }
        public string Length { get; set; }
        public uint? Steepness { get; set; }
        public string Description { get; set; }
        public string Scrag { get; set; }
        public string ObjectClass { get; set; }
        public DateTime RecDate { get; set; }
        public sbyte Repeat { get; set; }
        public byte YellowId { get; set; }
        public string CragSector { get; set; }
        public string ProjectAscentDate { get; set; }
        public int ExcludeFromRanking { get; set; }
        public int TotalScore { get; set; }
        public byte UserRecommended { get; set; }
        public byte Chipped { get; set; }
    }
}
