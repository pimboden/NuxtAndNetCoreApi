using System;

namespace _8anu.Data.Migration.Model
{
    public partial class YellowPages
    {
        public int Id { get; set; }
        public string ObjectClass { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string Info { get; set; }
        public string GoggleMapX { get; set; }
        public string GoggleMapY { get; set; }
        public DateTime Date { get; set; }
        public string Zip { get; set; }
        public string SubClass { get; set; }
    }
}
