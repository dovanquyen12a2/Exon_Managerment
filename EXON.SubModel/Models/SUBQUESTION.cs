namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUBQUESTIONS")]
    public partial class SUBQUESTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUBQUESTION()
        {
            ANSWERS = new HashSet<ANSWER>();
            ANSWERSHEET_DETAILS = new HashSet<ANSWERSHEET_DETAILS>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubQuestionID { get; set; }

        public string SubQuestionContent { get; set; }

        public double? Score { get; set; }

        public int QuestionID { get; set; }

        public int? HeightToDisplay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWER> ANSWERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET_DETAILS> ANSWERSHEET_DETAILS { get; set; }

        public virtual QUESTION QUESTION { get; set; }
    }
}
