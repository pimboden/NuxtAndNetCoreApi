using System.ComponentModel.DataAnnotations.Schema;

namespace _8anu.Api.Common.DataEntities
{
    [Table("boulders")]
    public class Boulder : Zlaggable
    {
        // tinyint(4)
        [Column("sit_down_start", TypeName = "tinyint(1)")]
        public bool SitDownStart { get; set; }

        // tinyint(4)
        [Column("traverse", TypeName = "tinyint(1)")]
        public bool? Traverse { get; set; }
        
        /// <summary>
        /// id to map to VerticalLife DB
        /// </summary>
        [Column("vl_boulder_id")] 
        public int? VlBoulderId { get; set; }
    }
}
