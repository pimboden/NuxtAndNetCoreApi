using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Common.DataEntities
{
    [Table("countries")]
    public class Country : DataEntity
    {
        [Column("name")]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Column("slug")]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string Slug { get; set; }

        [Column("iso2")]
        [MaxLength(2)]
        [DataType(DataType.Text)]
        public string ISO2 { get; set; }

        [Column("iso3")]
        [MaxLength(3)]
        [DataType(DataType.Text)]
        public string ISO3 { get; set; }
    }
}
