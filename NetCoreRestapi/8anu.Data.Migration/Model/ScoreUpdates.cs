using System;

namespace _8anu.Data.Migration.Model
{
    public partial class ScoreUpdates
    {
        public uint Id { get; set; }
        public string CountryCode { get; set; }
        public uint AscentId { get; set; }
        public DateTime Date { get; set; }
    }
}
