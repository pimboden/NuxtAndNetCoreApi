using System;

namespace _8anu.Data.Migration.Model
{
    public partial class ObjectXml
    {
        public uint Id { get; set; }
        public int ObjectId { get; set; }
        public string ObjectClass { get; set; }
        public string Xml { get; set; }
        public DateTime Date { get; set; }
    }
}
