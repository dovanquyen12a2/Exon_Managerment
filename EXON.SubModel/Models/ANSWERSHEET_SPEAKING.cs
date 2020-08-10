namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ANSWERSHEET_SPEAKING
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ANSWERSHEET_SPEAKING()
        {
            SPEAKING_TEACHER = new HashSet<SPEAKING_TEACHER>();
        }

        [Key]
        public int AnswerSheetSpeakingID { get; set; }

        public int? AnswerSheetID { get; set; }

        public double? SpeakingScore { get; set; }

        public double? SpeakingScore2 { get; set; }

        public int? Status { get; set; }

        public virtual ANSWERSHEET ANSWERSHEET { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPEAKING_TEACHER> SPEAKING_TEACHER { get; set; }
    }
}
