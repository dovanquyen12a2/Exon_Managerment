namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOCATIONS")]
    public partial class LOCATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOCATION()
        {
            EXAMINATIONCOUNCIL_STAFFS = new HashSet<EXAMINATIONCOUNCIL_STAFFS>();
            ROOMTESTS = new HashSet<ROOMTEST>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationID { get; set; }

        public string LocationName { get; set; }

        public int Status { get; set; }

        public int ContestID { get; set; }

        public virtual CONTEST CONTEST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXAMINATIONCOUNCIL_STAFFS> EXAMINATIONCOUNCIL_STAFFS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROOMTEST> ROOMTESTS { get; set; }
    }
}
