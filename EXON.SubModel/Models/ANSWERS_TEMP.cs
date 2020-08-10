namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ANSWERS_TEMP
    {
        public int AnswerID { get; set; }

        public string AnswerContent { get; set; }

        public bool IsCorrect { get; set; }

        public int SubQuestionID { get; set; }

        public int? SubQuestionTempID { get; set; }

        public int DivisionShiftID { get; set; }

        [Key]
        public int AnswerTempID { get; set; }
    }
}
