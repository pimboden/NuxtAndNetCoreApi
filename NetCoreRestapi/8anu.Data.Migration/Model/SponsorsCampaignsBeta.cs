using System;

namespace _8anu.Data.Migration.Model
{
    public partial class SponsorsCampaignsBeta
    {
        public uint Id { get; set; }
        public uint UserId { get; set; }
        public uint SponsorId { get; set; }
        public string Image { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Comment { get; set; }
        public uint Position { get; set; }
        public uint Type { get; set; }
        public byte Internal { get; set; }
        public byte Active { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}
