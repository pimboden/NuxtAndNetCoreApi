using System.Collections.Generic;

namespace _8anu.Api.Common.Models
{
    public class ThreadDetail
    {
        public ThreadInfo ThreadInfo { get; set; }
        public List<ThreadComment> ThreadComments { get; set; }
    }
}