namespace _8anu.Data.Migration.Model
{
    public partial class CragAscents
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CragSectorId { get; set; }
        public int Ascents { get; set; }
        public float Rate { get; set; }
        public float TopoNum { get; set; }
        public string TopoDesc { get; set; }
        public int CragId { get; set; }
        public string GradeName { get; set; }
        public string GradeComment { get; set; }
        public int? Qindex { get; set; }
        public int? OsRate { get; set; }
    }
}
