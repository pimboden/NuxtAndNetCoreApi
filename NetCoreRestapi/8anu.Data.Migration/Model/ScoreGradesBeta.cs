namespace _8anu.Data.Migration.Model
{
    public partial class ScoreGradesBeta
    {
        public byte Id { get; set; }
        public uint Score { get; set; }
        public string FraRoutes { get; set; }
        public byte FraRoutesInput { get; set; }
        public byte FraRoutesSelector { get; set; }
        public string FraBoulders { get; set; }
        public byte FraBouldersInput { get; set; }
        public byte FraBouldersSelector { get; set; }
        public string UsaRoutes { get; set; }
        public byte UsaRoutesInput { get; set; }
        public byte UsaRoutesSelector { get; set; }
        public string UsaBoulders { get; set; }
        public byte UsaBouldersInput { get; set; }
        public byte UsaBouldersSelector { get; set; }
    }
}
