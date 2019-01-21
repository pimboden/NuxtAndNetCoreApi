using System;

namespace _8anu.Data.Migration.Model
{
    public partial class CragArea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }
        public int Type { get; set; }
        public DateTime Date { get; set; }
    }
}
