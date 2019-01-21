using System;

namespace _8anu.Data.Migration.Model
{
    public partial class SponsorsContestants
    {
        public int Id { get; set; }
        public int SponsorId { get; set; }
        public string CompName { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string Retail { get; set; }
        public string Answer { get; set; }
        public string Contact { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Country { get; set; }
    }
}
