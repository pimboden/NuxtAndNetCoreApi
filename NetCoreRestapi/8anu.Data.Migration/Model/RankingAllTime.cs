namespace _8anu.Data.Migration.Model
{
    public partial class RankingAllTime
    {
        public uint UserId { get; set; }
        public ushort RouteScore { get; set; }
        public ushort BoulderScore { get; set; }
        public byte Participate { get; set; }
        public int TradScore { get; set; }
    }
}
