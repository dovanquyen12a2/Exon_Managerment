namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DIVISION_SHIFTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIVISION_SHIFTS()
        {
            BAGOFTESTS = new HashSet<BAGOFTEST>();
            CONTESTANTS_SHIFTS = new HashSet<CONTESTANTS_SHIFTS>();
            DIVISIONSHIFT_SUPERVISOR = new HashSet<DIVISIONSHIFT_SUPERVISOR>();
            DIVSIONSHIFT_PAUSE = new HashSet<DIVSIONSHIFT_PAUSE>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DivisionShiftID { get; set; }

        public int Status { get; set; }

        public int ShiftID { get; set; }

        public int RoomTestID { get; set; }

        [StringLength(20)]
        public string Key { get; set; }

        public int? CheckFinger { get; set; }

        public int? StartDate { get; set; }

        public int? StartTime { get; set; }

        public int? EndTime { get; set; }

        public int? DivisionShiftAddTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAGOFTEST> BAGOFTESTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_SHIFTS> CONTESTANTS_SHIFTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIVISIONSHIFT_SUPERVISOR> DIVISIONSHIFT_SUPERVISOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIVSIONSHIFT_PAUSE> DIVSIONSHIFT_PAUSE { get; set; }

        public virtual ROOMTEST ROOMTEST { get; set; }

        public virtual SHIFT SHIFT { get; set; }
    }
}
