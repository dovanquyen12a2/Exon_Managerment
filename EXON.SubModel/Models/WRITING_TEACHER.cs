namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WRITING_TEACHER
    {
        public int ID { get; set; }

        public int? AnswerSheetWritingID { get; set; }

        public int? TeacherID { get; set; }

        public int? Status { get; set; }

        public virtual ANSWERSHEET_WRITING ANSWERSHEET_WRITING { get; set; }

        public virtual STAFF STAFF { get; set; }
    }
}
