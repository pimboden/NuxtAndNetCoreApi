namespace _8anu.Data.Migration.Model
{
    public partial class Userloggedin
    {
        public int UserId { get; set; }
        public int? Timestamp { get; set; }
        public string Ip { get; set; }
        public string NetSessionId { get; set; }
    }
}
