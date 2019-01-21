using System;

namespace _8anu.Data.Migration.Model
{
    public partial class Punkter
    {
        public uint Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
