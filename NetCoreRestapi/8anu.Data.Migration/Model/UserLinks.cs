namespace _8anu.Data.Migration.Model
{
    public partial class UserLinks
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public uint CategoryId { get; set; }
        public string Country { get; set; }
        public string SubmitName { get; set; }
        public string SubmitMail { get; set; }
        public uint Rating { get; set; }
    }
}
