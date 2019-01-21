using System;

namespace _8anu.Data.Migration.Model
{
    public partial class ProductNews
    {
        public uint Id { get; set; }
        public string HeadText { get; set; }
        public string HeadUrl { get; set; }
        public string ImageUrl { get; set; }
        public string MoShortText { get; set; }
        public string ReviewUrl { get; set; }
        public DateTime PublishDate { get; set; }
        public string CountryCode { get; set; }
    }
}
