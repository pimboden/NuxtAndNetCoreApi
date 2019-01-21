namespace _8anu.Data.Migration.Model
{
    public partial class VotingAlternatives
    {
        public uint Id { get; set; }
        public uint VotingId { get; set; }
        public string Alternative { get; set; }
        public uint Votes { get; set; }
    }
}
