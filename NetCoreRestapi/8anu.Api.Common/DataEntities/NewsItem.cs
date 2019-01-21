using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Common.DataEntities
{
    [Table("news")]
    public class NewsItem : CreatedModifiedEntity
    {

        [Column("slug")]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        public string Slug { get; set; }

        [Column("title")]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Column("description")]
        [DataType(DataType.Html)]
        public string Description { get; set; }

        [Column("date_published")]
        [DataType(DataType.DateTime)]
        public DateTime DatePublished { get; set; }

        [Column("legacy_id")]
        public int? LegacyId { get; set; }
    }
}
