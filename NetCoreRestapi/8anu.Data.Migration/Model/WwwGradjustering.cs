namespace _8anu.Data.Migration.Model
{
    public partial class WwwGradjustering
    {
        public uint Id { get; set; }
        public string Namn { get; set; }
        public byte Led { get; set; }
        public string StartGrade { get; set; }
        public string NewGrade { get; set; }
        public byte English { get; set; }
    }
}
