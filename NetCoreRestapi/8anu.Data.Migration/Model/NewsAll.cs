using System;

namespace _8anu.Data.Migration.Model
{
    public partial class NewsAll
    {
        public uint Id { get; set; }
        public string Slug { get; set; }
        public string Rubrik { get; set; }
        public byte Kategori { get; set; }
        public DateTime Datum { get; set; }
        public string Text { get; set; }
        public byte Var { get; set; }
        public sbyte? Headline { get; set; }
        public string Country { get; set; }
        public int OnAll { get; set; }
        public string Image { get; set; }
        public sbyte KeepAlive { get; set; }
        public uint UserId { get; set; }
        public int Debate { get; set; }
        public int Video { get; set; }
        public int Hide { get; set; }
        public string Image2 { get; set; }
    }
}
