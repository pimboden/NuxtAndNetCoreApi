using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _8anu.Api.Common.Interfaces
{
    public class CreatedModifiedEntity : DataEntity
    {
        // TODO: should we add createdby and modifiedby?

        // have to add TypeName with DEFAULT... otherwise column gets also ON UPDATE value for some reason...go figure
        [Column("date_created")]
        //[Required]
        public DateTime DateCreated { get; set; }

        [Column("date_modified")]
        //[Required]
        public DateTime DateModified { get; set; }
    }
}
