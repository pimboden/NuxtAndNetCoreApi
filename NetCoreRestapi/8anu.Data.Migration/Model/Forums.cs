using System;

namespace _8anu.Data.Migration.Model
{
    public partial class Forums
    {
        public int ForumId { get; set; }
        public int SectionId { get; set; }
        public string ForumSub { get; set; }
        public int UserId { get; set; }
        public DateTime ForumDate { get; set; }
        public string ForumMsg { get; set; }
        public int ForumThread { get; set; }
        public int ForumChild { get; set; }
        public int UserType { get; set; }
        public string Icon { get; set; }
        public int Hits { get; set; }
        public string Country { get; set; }
        public int ObjectId { get; set; }
    }
}
