namespace DBAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Serializable]
    [Table("KinoAkter")]
    public partial class KinoAkter
    {
        public KinoAkter()
        {

        }
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KinoId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Akter { get; set; }

        public virtual Kino Kino { get; set; }
    }
}
