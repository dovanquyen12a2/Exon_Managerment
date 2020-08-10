namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTESTANTS_TESTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTESTANTS_TESTS()
        {
            ANSWERSHEETS = new HashSet<ANSWERSHEET>();
            CONTESTANTPAUSEs = new HashSet<CONTESTANTPAUSE>();
        }

        [Key]
        public int ContestantTestID { get; set; }

        public int Status { get; set; }

        public int ContestantShiftID { get; set; }

        public int TestID { get; set; }

        public int? SubmitTime { get; set; }

        public int? ContestantAddTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET> ANSWERSHEETS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTPAUSE> CONTESTANTPAUSEs { get; set; }

        public virtual TEST TEST { get; set; }
    }
}
