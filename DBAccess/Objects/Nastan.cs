namespace DBAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Serializable]
    [Table("Nastan")]
    public partial class Nastan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nastan()
        {
            NastanOdrzhuvanje = new HashSet<NastanOdrzhuvanje>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Ime { get; set; }

        [Required]
        [StringLength(700)]
        public string Slika { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Opis { get; set; }

        public double RegularnaCena { get; set; }

        public virtual Kino Kino { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NastanOdrzhuvanje> NastanOdrzhuvanje { get; set; }

        public virtual Sport Sport { get; set; }

        public virtual Teatar Teatar { get; set; }
        public virtual Koncert Koncert { get; set; }
        public virtual Zooloshka Zooloshka { get; set; }
    }
}
