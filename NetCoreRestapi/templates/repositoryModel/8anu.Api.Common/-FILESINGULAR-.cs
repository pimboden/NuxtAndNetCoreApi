using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;
using _8anu.Api.Common.Interfaces;
using _8anu.Api.Common.Enums;

namespace _8anu.Api.Common
{
    [Table("[L-PLURAL]")]
    public class [SINGULAR] : IntDataEntity
    {
        [Column("slug")]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        [Required]
        public string Slug { get; set; }

        /*
        [Column("crag_type")]
        public CragTypeEnum CragType { get; set; }

        [Column("name")]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [Column("city")]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string City { get; set; }

        [Column("country_id")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        [Column("latitude")]
        public double? Latitude { get; set; }

        [Column("longitude")]
        public double? Longitude { get; set; }

        [Column("date_created")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DateCreated { get; set; }
        */
    }
}
