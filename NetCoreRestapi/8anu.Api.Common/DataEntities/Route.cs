using System.ComponentModel.DataAnnotations.Schema;

namespace _8anu.Api.Common.DataEntities
{
    [Table("routes")]
    public class Route : Zlaggable
    {
        [Column("spit")]
        public int? Spit { get; set; }

        [Column("length")]
        public int? Length { get; set; }
        
        /// <summary>
        /// id to map to VerticalLife DB
        /// </summary>
        [Column("vl_route_id")] 
        public int? VlRouteId { get; set; }
    }
}
