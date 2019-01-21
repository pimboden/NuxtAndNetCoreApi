using System.Collections.Generic;

namespace _8anu.Api.Common.Models
{
    public class SearchResult
    {
        public string Category { get; set; }
        public int Count { get; set; }
        public List<object> Items { get; set; }
    }
}