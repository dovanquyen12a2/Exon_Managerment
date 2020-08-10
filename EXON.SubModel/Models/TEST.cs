namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TESTS")]
    public partial class TEST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TEST()
        {
            CONTESTANTS_TESTS = new HashSet<CONTESTANTS_TESTS>();
            TEST_DETAILS = new HashSet<TEST_DETAILS>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TestID { get; set; }

        public int Status { get; set; }

        public int BagOfTestID { get; set; }

        public int SubjectID { get; set; }

        public virtual BAGOFTEST BAGOFTEST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_TESTS> CONTESTANTS_TESTS { get; set; }

        public virtual SUBJECT SUBJECT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEST_DETAILS> TEST_DETAILS { get; set; }
    }
}
