namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROOMTESTS")]
    public partial class ROOMTEST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROOMTEST()
        {
            DIVISION_SHIFTS = new HashSet<DIVISION_SHIFTS>();
            ROOMDIAGRAMS = new HashSet<ROOMDIAGRAM>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomTestID { get; set; }

        [StringLength(100)]
        public string RoomTestName { get; set; }

        public int MaxSeatMount { get; set; }

        public int? MaxSupervisor { get; set; }

        public int Status { get; set; }

        public int LocationID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIVISION_SHIFTS> DIVISION_SHIFTS { get; set; }

        public virtual LOCATION LOCATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROOMDIAGRAM> ROOMDIAGRAMS { get; set; }
    }
}
