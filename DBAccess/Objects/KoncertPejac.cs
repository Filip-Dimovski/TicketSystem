namespace DBAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Serializable]
    [Table("KoncertPejac")]
    public partial class KoncertPejac
    {
        public KoncertPejac()
        {

        }
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KoncertId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Pejach { get; set; }

        public virtual Koncert Koncert { get; set; }
    }
}
