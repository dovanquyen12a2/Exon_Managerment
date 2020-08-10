namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SHIFTSPAUSE")]
    public partial class SHIFTSPAUSE
    {
        [Key]
        public int ShiftPauseID { get; set; }

        public int? ShiftID { get; set; }

        public int? ShiftPauseClickTime { get; set; }

        public int? ShiftRealPauseTime { get; set; }

        public int? ShiftRestartTime { get; set; }

        public string Note { get; set; }

        public virtual SHIFT SHIFT { get; set; }
    }
}
