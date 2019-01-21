using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Common.DataEntities
{
    [Table("sectors")]
    public class Sector : CreatedModifiedEntity
    {
        [Column("crag_id")]
        public int CragId { get; set; }
        public Crag Crag { get; set; }

        [Column("slug")]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        [Required]
        public string Slug { get; set; }
        
        [Column("name")]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [Column("notes", TypeName = "text")]
        [DataType(DataType.Text)]
        public string Notes { get; set; }

        [Column("latitude")]
        public double? Latitude { get; set; }

        [Column("longitude")]
        public double? Longitude { get; set; }

        [Column("ordering")]
        public int? Ordering { get; set; }

        [Column("category")]
        [MaxLength(255)]
        public string Category { get; set; }
        
        /// <summary>
        /// id to map to VerticalLife DB
        /// </summary>
        [Column("vl_sector_id")] 
        public int? VlSectorId { get; set; }
    }
}
