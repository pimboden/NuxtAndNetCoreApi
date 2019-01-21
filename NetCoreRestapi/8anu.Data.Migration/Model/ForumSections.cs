namespace _8anu.Data.Migration.Model
{
    public partial class ForumSections
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ObjectClass { get; set; }
        public int Threads { get; set; }
        public int Posts { get; set; }
        public string LastObjectCommentInfo { get; set; }
        public sbyte Order { get; set; }
        public string Desc { get; set; }
        public string Icon { get; set; }
    }
}
