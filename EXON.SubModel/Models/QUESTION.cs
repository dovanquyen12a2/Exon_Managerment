namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUESTIONS")]
    public partial class QUESTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUESTION()
        {
            SUBQUESTIONS = new HashSet<SUBQUESTION>();
            TEST_DETAILS = new HashSet<TEST_DETAILS>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestionID { get; set; }

        public string QuestionContent { get; set; }

        public int QuestionFormat { get; set; }

        public int? Level { get; set; }

        public bool IsQuiz { get; set; }

        public bool IsSingleChoice { get; set; }

        public bool IsParagraph { get; set; }

        public bool IsQuestionContent { get; set; }

        public int NumberSubQuestion { get; set; }

        public int NumberAnswer { get; set; }

        public int? Type { get; set; }

        public byte[] Audio { get; set; }

        public int? HeightToDisplay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBQUESTION> SUBQUESTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEST_DETAILS> TEST_DETAILS { get; set; }
    }
}
