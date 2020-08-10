namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TESTNUMBER")]
    public partial class TESTNUMBER
    {
        [Key]
        public int IDTestNumber { get; set; }

        public int? ContestantShiftID { get; set; }

        [StringLength(10)]
        public string TestNumberIndex { get; set; }
    }
}
