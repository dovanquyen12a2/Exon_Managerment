namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STAFFS")]
    public partial class STAFF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STAFF()
        {
            ANSWERSHEETS = new HashSet<ANSWERSHEET>();
            EXAMINATIONCOUNCIL_STAFFS = new HashSet<EXAMINATIONCOUNCIL_STAFFS>();
            SPEAKING_TEACHER = new HashSet<SPEAKING_TEACHER>();
            STAFFS_POSITIONS = new HashSet<STAFFS_POSITIONS>();
            WRITING_TEACHER = new HashSet<WRITING_TEACHER>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StaffID { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        public int? DOB { get; set; }

        public int? Sex { get; set; }

        [StringLength(12)]
        public string IdentityCardNumber { get; set; }

        [StringLength(100)]
        public string AcademicRank { get; set; }

        [StringLength(100)]
        public string Degree { get; set; }

        public int Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET> ANSWERSHEETS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXAMINATIONCOUNCIL_STAFFS> EXAMINATIONCOUNCIL_STAFFS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPEAKING_TEACHER> SPEAKING_TEACHER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STAFFS_POSITIONS> STAFFS_POSITIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WRITING_TEACHER> WRITING_TEACHER { get; set; }
    }
}
