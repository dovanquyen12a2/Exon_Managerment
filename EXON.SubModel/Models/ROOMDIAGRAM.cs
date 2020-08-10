namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROOMDIAGRAMS")]
    public partial class ROOMDIAGRAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROOMDIAGRAM()
        {
            CONTESTANTS_SHIFTS = new HashSet<CONTESTANTS_SHIFTS>();
        }

        public int RoomDiagramID { get; set; }

        [StringLength(50)]
        public string ComputerCode { get; set; }

        [Required]
        public string ComputerName { get; set; }

        [StringLength(25)]
        public string ClientIP { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public int? RoomTestID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_SHIFTS> CONTESTANTS_SHIFTS { get; set; }

        public virtual ROOMTEST ROOMTEST { get; set; }
    }
}
