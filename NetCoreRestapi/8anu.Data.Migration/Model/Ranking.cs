namespace _8anu.Data.Migration.Model
{
    public partial class Ranking
    {
        public uint UserId { get; set; }
        public int RouteScore { get; set; }
        public int BoulderScore { get; set; }
        public byte Participate { get; set; }
        public int TradScore { get; set; }
        public int AgeBonus { get; set; }
        public int OsScore { get; set; }
        public int OsScoreB { get; set; }
    }
}
