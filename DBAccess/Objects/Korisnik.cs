namespace DBAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Serializable]
    [Table("Korisnik")]
    public partial class Korisnik
    {
        public Korisnik()
        {

        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Ime { get; set; }

        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(1)]
        public string Pol { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        public string Lozinka { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatumRagjanje { get; set; }

        [Required]
        [StringLength(50)]
        public string Drzhava { get; set; }

        public int? IdKreditnaKartichka { get; set; }

        public virtual KreditnaKartichka KreditnaKartichka { get; set; }
    }
}
