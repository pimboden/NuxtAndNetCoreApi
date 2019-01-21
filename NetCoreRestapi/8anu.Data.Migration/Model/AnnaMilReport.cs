namespace _8anu.Data.Migration.Model
{
    public partial class AnnaMilReport
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Customer { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int Active { get; set; }
        public int Dist { get; set; }
    }
}
