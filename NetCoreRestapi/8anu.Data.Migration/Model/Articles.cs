using System;

namespace _8anu.Data.Migration.Model
{
    public partial class Articles
    {
        public uint Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Html { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime EditDate { get; set; }
        public uint UserId { get; set; }
        public sbyte Hide { get; set; }
        public int CategoryId { get; set; }
        public string CountryCode { get; set; }
        public string LangCountryCode { get; set; }
        public string ObjectCls { get; set; }
        public int VideoBlog { get; set; }
    }
}
