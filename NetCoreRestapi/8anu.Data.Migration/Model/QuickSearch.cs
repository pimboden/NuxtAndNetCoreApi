using System;

namespace _8anu.Data.Migration.Model
{
    public partial class QuickSearch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sql { get; set; }
        public int ObjectId { get; set; }
        public string CountryCode { get; set; }
        public DateTime Date { get; set; }
        public string ObjectClass { get; set; }
        public int AscentType { get; set; }
    }
}
