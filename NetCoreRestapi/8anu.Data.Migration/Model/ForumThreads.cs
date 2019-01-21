using System;

namespace _8anu.Data.Migration.Model
{
    public partial class ForumThreads
    {
        public uint Id { get; set; }
        public string Slug { get; set; }
        public uint ObjectId { get; set; }
        public string ObjectClass { get; set; }
        public uint UserId { get; set; }
        public string Head { get; set; }
        public string Html { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int MessageCount { get; set; }
        public string CountryCode { get; set; }
        public int LastObjectCommentId { get; set; }
        public DateTime LastObjectCommentDate { get; set; }
        public string Icon { get; set; }
    }
}
