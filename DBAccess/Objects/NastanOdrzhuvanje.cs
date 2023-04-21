namespace DBAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Serializable]
    [Table("NastanOdrzhuvanje")]
    public partial class NastanOdrzhuvanje
    {
        public NastanOdrzhuvanje()
        {

        }
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NastanId { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime VremeOdrzhuvanje { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(500)]
        public string Lokacija { get; set; }

        public int SlobodniMesta { get; set; }

        public double Cena { get; set; }
        public virtual Nastan Nastan { get; set; }
    }
}
