using System;

namespace _8anu.Api.Common.Models
{
    public class ForumThreadWithCounts
    {
        public int ThreadId { get; set; }
        public string ThreadTitle { get; set; }
        public string ThreadSlug { get; set; }
        public int ThreadCategory{ get; set; }
        public int CommentsCount { get; set; }
        public DateTime? LatesCommentDate { get; set; }
        public string LatesCommentUserFullName { get; set; }
        public string LatesCommentThreadSlug { get; set; }
    }
}