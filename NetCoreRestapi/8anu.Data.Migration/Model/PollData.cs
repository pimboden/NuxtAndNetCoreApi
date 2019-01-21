using System;

namespace _8anu.Data.Migration.Model
{
    public partial class PollData
    {
        public int Id { get; set; }
        public int QId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
