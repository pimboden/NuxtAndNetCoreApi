namespace _8anu.Data.Migration.Model
{
    public partial class CragSectors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CragId { get; set; }
        public int Ascents { get; set; }
        public int Active { get; set; }
        public string Info { get; set; }
        public string GoggleMapX { get; set; }
        public string GoggleMapY { get; set; }
    }
}
