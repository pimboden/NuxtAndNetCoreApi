using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Common.DataEntities
{
    [Table("users")]
    public class User : CreatedModifiedEntity
    {

        [Column("slug")]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        [Required]
        public string Slug { get; set; }

        [Column("first_name")]
        [MaxLength(30)]
        [DataType(DataType.Text)]
        [Required]
        public string FirstName { get; set; }

        [Column("last_name")]
        [MaxLength(30)]
        [DataType(DataType.Text)]
        [Required]
        public string LastName { get; set; }

        [Column("gender")]
        public GenderEnum Gender { get; set; }

        [Column("country_id")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        // store rest of the properties as JSON
        // https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql
        //public JsonObject<List<string>> Tags { get; set; } // Json storage (MySQL 5.7 only)
    }
}
