using System;

namespace _8anu.Data.Migration.Model
{
    public partial class SponsorsBannersClicks
    {
        public int Id { get; set; }
        public int SponsorId { get; set; }
        public int BannerId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
