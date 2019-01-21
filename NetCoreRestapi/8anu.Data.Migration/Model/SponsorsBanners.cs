using System;

namespace _8anu.Data.Migration.Model
{
    public partial class SponsorsBanners
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string DestinationUrl { get; set; }
        public string Position { get; set; }
        public int SponsorId { get; set; }
        public string ObjectClass { get; set; }
        public DateTime PublishDate { get; set; }
        public string MediaType { get; set; }
        public string FrameTarget { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ClassType { get; set; }
    }
}
