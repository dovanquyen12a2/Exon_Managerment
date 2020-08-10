namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SHIFTS")]
    public partial class SHIFT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SHIFT()
        {
            DIVISION_SHIFTS = new HashSet<DIVISION_SHIFTS>();
            SHIFTSPAUSEs = new HashSet<SHIFTSPAUSE>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShiftID { get; set; }

        [StringLength(100)]
        public string ShiftName { get; set; }

        public int ShiftDate { get; set; }

        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public int Status { get; set; }

        public int? ContestID { get; set; }

        public int? ShiftAddTime { get; set; }

        public virtual CONTEST CONTEST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIVISION_SHIFTS> DIVISION_SHIFTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHIFTSPAUSE> SHIFTSPAUSEs { get; set; }
    }
}
