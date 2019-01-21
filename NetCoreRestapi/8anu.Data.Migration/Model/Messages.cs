using System;

namespace _8anu.Data.Migration.Model
{
    public partial class Messages
    {
        public uint MessageId { get; set; }
        public uint ToUserId { get; set; }
        public uint FromUserId { get; set; }
        public uint? ParentMessageId { get; set; }
        public string MessageSubject { get; set; }
        public string Htmlmessage { get; set; }
        public string TextMessage { get; set; }
        public string ObjectCls { get; set; }
        public sbyte HasBeenRead { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public sbyte? FromUserDelete { get; set; }
        public sbyte? ToUserDelete { get; set; }
    }
}
