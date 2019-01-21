using System;

namespace _8anu.Data.Migration.Model
{
    public partial class ForumsLastpost
    {
        public int ForumId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Posts { get; set; }
    }
}
