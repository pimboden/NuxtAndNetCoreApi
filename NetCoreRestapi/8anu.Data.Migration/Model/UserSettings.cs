namespace _8anu.Data.Migration.Model
{
    public partial class UserSettings
    {
        public uint Id { get; set; }
        public string StartPage { get; set; }
        public byte? MaxRoutes { get; set; }
        public uint LastDays { get; set; }
        public byte? GradeFrom { get; set; }
        public string Langue { get; set; }
        public byte Newsletter { get; set; }
        public byte Contact { get; set; }
        public sbyte ReceiveMessages { get; set; }
        public string ExtBlogUrl { get; set; }
        public string ExtBlogFeedUrl { get; set; }
    }
}
