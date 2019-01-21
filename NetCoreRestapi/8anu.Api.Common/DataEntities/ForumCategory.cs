using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Common.DataEntities
{
    [Table("forum_categories")]
    public class ForumCategory : CreatedModifiedEntity, ISlugEntity
    {

        [Column("slug")]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Required]
        public string Slug { get; set; }

        [Column("name")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Column("description")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Column("user_id")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column("parent_id")]
        public int? ParentId { get; set; }
        public ForumCategory Parent { get; set; }

        public ICollection<ForumThread> ForumThreads { get; set; }
    }
}
