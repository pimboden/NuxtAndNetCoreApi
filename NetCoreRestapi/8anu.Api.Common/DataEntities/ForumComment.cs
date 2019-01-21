using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Common.DataEntities
{
    [Table("forum_comments")]
    public class ForumComment : CreatedModifiedEntity
    {
        [Column("forum_thread_id")]
        [Required]
        public int ForumThreadId { get; set; }
        public ForumThread ForumThread { get; set; }

        [Column("user_id")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column("content")]
        [Required]
        public string Content { get; set; }
        
        [Column("legacy_id")] 
        public int? LegacyId { get; set; }
    }
}
