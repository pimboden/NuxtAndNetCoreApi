using System;

namespace _8anu.Data.Migration.Model
{
    public partial class Passlist
    {
        public uint Id { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string HashHash { get; set; }
        public DateTimeOffset? LastChanged { get; set; }
    }
}
