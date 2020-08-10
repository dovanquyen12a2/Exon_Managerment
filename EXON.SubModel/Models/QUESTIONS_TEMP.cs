namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QUESTIONS_TEMP
    {
        public int QuestionID { get; set; }

        public string QuestionContent { get; set; }

        public int? QuestionFormat { get; set; }

        public int? Level { get; set; }

        public bool? IsQuiz { get; set; }

        public bool? IsSingleChoice { get; set; }

        public bool? IsParagarph { get; set; }

        public bool? IsQuestionContent { get; set; }

        public int? NumberSubQuestion { get; set; }

        public int? NumberAnswer { get; set; }

        public int? DivisionShiftID { get; set; }

        [Key]
        public int QuestionTempID { get; set; }

        public int? Type { get; set; }

        public byte[] Audio { get; set; }
    }
}
