namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STAFFS_POSITIONS
    {
        [Key]
        public int StaffPositionID { get; set; }

        public int StaffID { get; set; }

        public int PositionID { get; set; }

        public virtual POSITION POSITION { get; set; }

        public virtual STAFF STAFF { get; set; }
    }
}
