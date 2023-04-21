namespace DBAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Serializable]
    [Table("Poseta")]
    public partial class Poseta
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KorisnikId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NastanId { get; set; }

        public DateTime VremeOdrzhuvanje { get; set; }
        public string Lokacija { get; set; }

        public DateTime DatumRezervacija { get; set; }
    }
}
