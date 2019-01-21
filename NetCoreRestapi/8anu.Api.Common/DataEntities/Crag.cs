using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Common.DataEntities
{
    [Table("crags")]
    public class Crag : CreatedModifiedEntity
    {
        [Column("slug")]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        [Required]
        public string Slug { get; set; }

        [Column("name")]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        // tinyint(4)
        [Column("beauty", TypeName = "tinyint(4)")]
        public sbyte? Beauty { get; set; }

        // tinyint(1)
        [Column("family_friendly", TypeName = "tinyint(1)")]
        public bool? FamilyFriendly { get; set; }

        [Column("walking_time")]
        public int? WalkingTime { get; set; }

        // tinyint(1)
        [Column("rain_safety", TypeName = "tinyint(1)")]
        public bool? RainSafety { get; set; }

        [Column("height")]
        public int? Height { get; set; }

        // tinyint(4)
        [Column("protection", TypeName = "tinyint(4)")]
        public sbyte? Protection { get; set; }

        // tinyint(4)
        [Column("parking", TypeName = "tinyint(4)")]
        public sbyte? Parking { get; set; }

        // tinyint(1)
        [Column("beginner_friendly", TypeName = "tinyint(1)")]
        public bool? BeginnerFriendly { get; set; }

        [Column("latitude")]
        public double? Latitude { get; set; }

        [Column("longitude")]
        public double? Longitude { get; set; }

        [Column("area_id")]
        public int? AreaId { get; set; }
        public Area Area { get; set; }

        [Column("season")]
        public int? Season { get; set; }

        [Column("steepness")]
        public int? Steepness { get; set; }

        [Column("exposition")]
        public int? Exposition { get; set; }

        // tinyint(1)
        [Column("seaside", TypeName = "tinyint(1)")]
        public bool? Seaside { get; set; }

        [Column("rock_quality")]
        public int? RockQuality { get; set; }

        // TODO: change this to CragCategoryEnum
        // when value conversions come with EF Core 2.1
        // https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions
        [Column("category")]
        [DataType(DataType.Text)]
        [MaxLength(255)]
        public string Category { get; set; }

        [Column("published")]
        public bool Published { get; set; }

        [Column("city")]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string City { get; set; }

        [Column("country_id")]
        public int CountryId { get; set; }
        public Country Country { get; set; }


        // vertical life translations table
        [Column("town")]
        [MaxLength(255)]
        public string Town { get; set; } 

        [Column("description", TypeName = "TEXT")]
        public string Description { get; set; }

        [Column("approach", TypeName = "TEXT")]
        public string Approach { get; set; }

        [Column("access", TypeName = "TEXT")]
        public string Access { get; set; }

        [Column("notes", TypeName = "TEXT")]
        public string Notes { get; set; }
        [Column("rock_type")]

        [MaxLength(255)]
        public string Rocktype { get; set; }


        public ICollection<Sector> Sectors { get; set; }
        
        [Column("legacy_id")] 
        public int? LegacyId { get; set; }
        
        /// <summary>
        /// id to map to VerticalLife DB
        /// </summary>
        [Column("vl_location_id")] 
        public int? VlLocationId { get; set; }
    }
}
