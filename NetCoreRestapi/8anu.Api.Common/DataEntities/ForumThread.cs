using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Common.DataEntities
{
    [Table("forum_threads")]
    public class ForumThread : CreatedModifiedEntity
    {

        [Column("slug")]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        [Required]
        public string Slug { get; set; }

        [Column("title")]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        [Required]
        public string Title { get; set; }

        [Column("forum_category_id")]
        [Required]
        public int ForumCategoryId { get; set; }
        public ForumCategory ForumCategory { get; set; }

        [Column("user_id")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<ForumComment> ForumComments { get; set; }
    }
}
