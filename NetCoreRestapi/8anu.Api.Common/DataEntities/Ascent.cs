using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Common.DataEntities
{
    [Table("ascents")]
    public class Ascent : CreatedModifiedEntity
    {
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }

        // TIMESTAMP
        // have to add TypeName with DEFAULT... otherwise column gets also ON UPDATE value for some reason...go figure
        [Column("date", TypeName = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP")]
        public DateTimeOffset Date { get; set; }

        // TODO: change this to enumeration and make value conversion 
        // with enumeration attribute (check from old 8a code how to implement)
        // when value conversions come with EF Core 2.1
        // https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions
        /// <summary>
        /// Gets or sets the type.
        /// value can be: f, os, tr, rp, go
        /// f = flash, os = onsight, tr = toprope, rp = redpoint, go = go
        /// </summary>
        /// <value>The type.</value>
        [Column("type")]
        [MaxLength(2)]
        public string Type { get; set; }

        [Column("rating")]
        public int? Rating { get; set; }

        // tinyint(1)
        [Column("project", TypeName = "tinyint(1)")]
        public bool? Project { get; set; }

        [Column("tries")]
        public int? Tries { get; set; }

        [Column("repeat", TypeName = "tinyint(1)")]
        public bool? Repeat { get; set; }

        [Column("difficulty")]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        public string Difficulty { get; set; }

        [Column("steepness")]
        public int? Steepness { get; set; }

        [Column("protection")]
        public int? Protection { get; set; }

        [Column("style")]
        [MaxLength(6)]
        [DataType(DataType.Text)]
        public string Style { get; set; }

        [Column("comment", TypeName = "TEXT")]
        public string Comment { get; set; }

        [Column("zlaggable_id")]
        public int? ZlaggableId { get; set; }

        [Column("zlaggable_type")]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        public string ZlaggableType { get; set; }

        [Column("height")]
        public int? Height { get; set; }

        [Column("zlaggable_key")]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        public string ZlaggableKey { get; set; }

        [Column("score")]
        public int? Score { get; set; }

        [Column("sits")]
        public int? Sits { get; set; }

        [Column("exclude_from_ranking", TypeName = "tinyint(1)")]
        public bool? ExcludeFromRanking { get; set; }

        [Column("chipped", TypeName = "tinyint(1)")]
        public bool? Chipped { get; set; }

        [Column("note")]
        public int? Note { get; set; }

        [Column("recommended", TypeName = "tinyint(1)")]
        public bool Recommended { get; set; }
        
        [Column("legacy_id")] 
        public int? LegacyId { get; set; }
    }
}
