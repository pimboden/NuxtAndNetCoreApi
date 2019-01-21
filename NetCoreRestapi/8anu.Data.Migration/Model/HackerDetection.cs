using System;

namespace _8anu.Data.Migration.Model
{
    public partial class HackerDetection
    {
        public uint Id { get; set; }
        public string Ip { get; set; }
        public string Vars { get; set; }
        public string Server { get; set; }
        public string Cookies { get; set; }
        public DateTimeOffset? Date { get; set; }
    }
}
