using System;

namespace _8anu.Data.Migration.Model
{
    public partial class ImagesFirstpage
    {
        public uint Id { get; set; }
        public string HeadText { get; set; }
        public string HeadUrl { get; set; }
        public string ImageUrl { get; set; }
        public string FootText { get; set; }
        public string FootUrl { get; set; }
        public DateTime PublishDate { get; set; }
        public string CountryCode { get; set; }
        public int Hide { get; set; }
    }
}
