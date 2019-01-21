using System;

namespace _8anu.Data.Migration.Model
{
    public partial class CragTopos
    {
        public int TopoId { get; set; }
        public int CragId { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
