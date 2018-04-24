namespace DBEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Match")]
    public partial class Match
    {
        public int ID { get; set; }

        public DateTime DateTIme { get; set; }

        public int ID_TeamHome { get; set; }

        public int ID_TeamAway { get; set; }

        public int ID_Score { get; set; }

        public virtual Score Score { get; set; }

        public virtual Team Team { get; set; }

        public virtual Team Team1 { get; set; }
    }
}
