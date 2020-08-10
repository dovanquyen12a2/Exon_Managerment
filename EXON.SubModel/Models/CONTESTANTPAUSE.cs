namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTESTANTPAUSE")]
    public partial class CONTESTANTPAUSE
    {
        public int ContestantPauseID { get; set; }

        public int? ContestantTestID { get; set; }

        public int? ContestantPauseClickTime { get; set; }

        public int? ContestantRealPauseTime { get; set; }

        public int? ContestantRestartTime { get; set; }

        public string Note { get; set; }

        public int? ContestantRealRestartTime { get; set; }

        public virtual CONTESTANTS_TESTS CONTESTANTS_TESTS { get; set; }
    }
}
