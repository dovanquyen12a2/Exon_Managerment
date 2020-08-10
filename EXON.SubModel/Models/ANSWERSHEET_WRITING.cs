namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ANSWERSHEET_WRITING
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ANSWERSHEET_WRITING()
        {
            WRITING_TEACHER = new HashSet<WRITING_TEACHER>();
        }

        [Key]
        public int AnswerSheetWritingID { get; set; }

        public int? AnswerSheetID { get; set; }

        public double? WritingScore { get; set; }

        public double? WritingScore2 { get; set; }

        public int? Status { get; set; }

        public virtual ANSWERSHEET ANSWERSHEET { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WRITING_TEACHER> WRITING_TEACHER { get; set; }
    }
}
