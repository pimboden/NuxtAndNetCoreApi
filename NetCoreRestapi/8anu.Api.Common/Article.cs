using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Common
{
    [Table("articles")]
    public class Article: GuidDataEntity
    {

        [Column("title")]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Column("description")]
        [MaxLength(2000)]
        [DataType(DataType.Html)]
        public string Description { get; set; }

        [Column("date_published")]
        [MaxLength(2000)]
        [DataType(DataType.DateTime)]
        public DateTime DatePublished { get; set; }
    }
}
