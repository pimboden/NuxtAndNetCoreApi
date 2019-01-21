using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Common.DataEntities
{
    /// <summary>
    /// this funky class is base class for Routes and Boulders
    /// </summary>
    public abstract class Zlaggable : CreatedModifiedEntity
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

        [Column("difficulty")]
        [MaxLength(10)]
        [Required]
        public string Difficulty { get; set; }

        [Column("sector_id")]
        public int SectorId { get; set; }
        public Sector Sector { get; set; }

        [Column("topo_num")]
        [MaxLength(10)]
        public string TopoNum { get; set; }

        [Column("reference_width")]
        public int? ReferenceWidth { get; set; }

        [Column("path", TypeName = "TEXT")]
        public string Path { get; set; }

        [Column("grade")]
        [MaxLength(255)]
        public string Grade { get; set; }

        [Column("grading_system")]
        [MaxLength(255)]
        public string GradingSystem { get; set; }

        [Column("notes", TypeName = "TEXT")]
        public string Notes { get; set; }
        
        [Column("legacy_id")] 
        public int? LegacyId { get; set; }
    }
}
