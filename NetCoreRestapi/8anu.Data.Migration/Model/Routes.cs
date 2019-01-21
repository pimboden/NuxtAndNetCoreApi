using System;

namespace _8anu.Data.Migration.Model
{
    public partial class Routes
    {
        public uint Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public uint? Grade { get; set; }
        public uint? How { get; set; }
        public string Country { get; set; }
        public string Crag { get; set; }
        public string Name { get; set; }
        public uint? Soft { get; set; }
        public uint? Hard { get; set; }
    }
}
