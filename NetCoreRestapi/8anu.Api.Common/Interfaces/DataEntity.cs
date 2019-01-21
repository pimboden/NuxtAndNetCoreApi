using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _8anu.Api.Common.Interfaces
{
    public abstract class DataEntity : IDataEntity
    {
        [Key]
        [Column("id")]
        public int? Id { get; set; }
    }
}
