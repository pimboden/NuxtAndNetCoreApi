using System;

namespace _8anu.Api.Common.Models
{
    public class ForumCategoryWithCounts
    {
        public int CategoryId { get; set; }
        public string CategorySlug { get; set; }
        public string CategoryName { get; set; }
        public int CommentsCount { get; set; }
        public int ThreadsCount { get; set; }
        public DateTime? LatesCommentDate { get; set; }
        public string LatesCommentUserFullName { get; set; }
        public string LatesCommentThreadSlug { get; set; }
    }
}