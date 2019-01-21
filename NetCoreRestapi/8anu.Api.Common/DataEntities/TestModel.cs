using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Common.DataEntities
{
    [Table("test_models")]
    public class TestModel: CreatedModifiedEntity
    {

        [Column("message")]
        [MaxLength(2000)]
        [DataType(DataType.Html)]
        public string Message { get; set; }
    }
}
