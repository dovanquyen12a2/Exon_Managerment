namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TEST_DETAILS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TestDetailID { get; set; }

        public string RandomAnswer { get; set; }

        public int NumberIndex { get; set; }

        public double Score { get; set; }

        public int Status { get; set; }

        public int TestID { get; set; }

        public int QuestionID { get; set; }

        public virtual QUESTION QUESTION { get; set; }

        public virtual TEST TEST { get; set; }
    }
}
