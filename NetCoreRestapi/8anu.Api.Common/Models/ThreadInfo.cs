using System;

namespace _8anu.Api.Common.Models
{
    public class ThreadInfo
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string UserFullName { get; set; }
        public string UserSlug { get; set; }
    }
}