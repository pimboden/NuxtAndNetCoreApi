namespace _8anu.Data.Migration.Model
{
    public partial class Traininglog
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Time { get; set; }
        public string Place { get; set; }
        public sbyte Meters { get; set; }
        public sbyte Hrs { get; set; }
        public string TopForm { get; set; }
        public sbyte FysicalQuality { get; set; }
        public sbyte Feeling { get; set; }
        public string Comment { get; set; }
        public string Adrenaline { get; set; }
        public string InOutDoor { get; set; }
        public sbyte Moves { get; set; }
    }
}
