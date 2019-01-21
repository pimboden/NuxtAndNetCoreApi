using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Common.DataEntities
{
    [Table("grading_systems")]
    public class GradingSystem : DataEntity
    {
        [Column("vl_grade")]
        [MaxLength(5)]
        public string VLGrade { get; set; }

        [Column("type")]
        [MaxLength(50)]
        public string Type { get; set; }

        [Column("grade")]
        [MaxLength(25)]
        public string Grade { get; set; }

        [Column("category")]
        [MaxLength(50)]
        public string Category { get; set; }
 
        public int VLGradeIndex
        {
            get
            {
                var retval = 0;
                if (VLGrade.Length > 3)
                {
                    retval = int.Parse(VLGrade.Substring(3));
                }

                return retval;
            }
        }
    }
}
