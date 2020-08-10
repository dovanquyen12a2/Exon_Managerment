namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DIVSIONSHIFT_PAUSE
    {
        [Key]
        public int DivisionShiftPauseID { get; set; }

        public int? DivisionShiftID { get; set; }

        public int? DivisionShiftPauseClickTime { get; set; }

        public int? DivisionShiftRealPauseTime { get; set; }

        public int? DivisionShiftRestartTime { get; set; }

        public string Note { get; set; }

        public virtual DIVISION_SHIFTS DIVISION_SHIFTS { get; set; }
    }
}
