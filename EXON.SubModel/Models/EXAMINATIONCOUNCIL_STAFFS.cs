namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EXAMINATIONCOUNCIL_STAFFS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EXAMINATIONCOUNCIL_STAFFS()
        {
            DIVISIONSHIFT_SUPERVISOR = new HashSet<DIVISIONSHIFT_SUPERVISOR>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExaminationCouncil_StaffID { get; set; }

        public int? StaffID { get; set; }

        public int? ExaminationCouncil_PositionID { get; set; }

        public int? LocationID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Status { get; set; }

        public int? ContestID { get; set; }

        public virtual CONTEST CONTEST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIVISIONSHIFT_SUPERVISOR> DIVISIONSHIFT_SUPERVISOR { get; set; }

        public virtual EXAMINATIONCOUNCIL_POSITIONS EXAMINATIONCOUNCIL_POSITIONS { get; set; }

        public virtual LOCATION LOCATION { get; set; }

        public virtual STAFF STAFF { get; set; }
    }
}
