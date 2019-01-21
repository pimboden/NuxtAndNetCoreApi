using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Common.DataEntities
{
    [Table("areas")]
    public class Area : CreatedModifiedEntity
    {
        [Column("slug")]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        [Required]
        public string Slug { get; set; }
        
        [Column("name")]
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [Column("description")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Column("country_id")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        
        [Column("published")]
        [Required]
        public bool Published { get; set; }

        [Column("legacy_id")] 
        public int? LegacyId { get; set; }
    }
}
