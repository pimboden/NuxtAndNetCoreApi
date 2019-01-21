namespace _8anu.Data.Migration.Model
{
    public partial class CragUserRating
    {
        public int CragId { get; set; }
        public int UserId { get; set; }
        public int Scenary { get; set; }
        public int Rock { get; set; }
        public int Warmup { get; set; }
        public int Protection { get; set; }
        public int Walk { get; set; }
        public int Ground { get; set; }
    }
}
