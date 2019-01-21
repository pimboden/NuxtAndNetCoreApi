using System;

namespace _8anu.Api.Common.Models
{
    public class ThreadComment
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }
        public string UserFullName { get; set; }
        public string UserSlug { get; set; }
    }
}