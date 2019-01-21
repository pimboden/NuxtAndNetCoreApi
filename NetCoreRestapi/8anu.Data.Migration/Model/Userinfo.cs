namespace _8anu.Data.Migration.Model
{
    public partial class Userinfo
    {
        public uint Id { get; set; }
        public string Slug { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public byte Sex { get; set; }
        public byte? Height { get; set; }
        public byte? Weight { get; set; }
        public int? Started { get; set; }
        public string Competitions { get; set; }
        public string Occupation { get; set; }
        public string Sponsor1 { get; set; }
        public string Sponsor1Www { get; set; }
        public string Sponsor2 { get; set; }
        public string Sponsor2Www { get; set; }
        public string Sponsor3 { get; set; }
        public string Sponsor3Www { get; set; }
        public string BestArea { get; set; }
        public string WorstArea { get; set; }
        public string GuideArea { get; set; }
        public string OInterrests { get; set; }
        public string MyPicture { get; set; }
        public string Birth { get; set; }
        public string Presentation { get; set; }
        public int Deactivated { get; set; }
        public int Annanymous { get; set; }
        public uint BetaAccess { get; set; }
    }
}
