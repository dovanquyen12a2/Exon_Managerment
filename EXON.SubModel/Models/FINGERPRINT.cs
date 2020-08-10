namespace EXON.SubModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FINGERPRINTS")]
    public partial class FINGERPRINT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FingerprintID { get; set; }

        public byte[] FingerprintImage { get; set; }

        public string FilePath { get; set; }

        public int? TimeSaveFingerprint { get; set; }

        public int Status { get; set; }

        public int ContestantID { get; set; }

        public virtual CONTESTANT CONTESTANT { get; set; }
    }
}
