namespace DBAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Serializable]
    [Table("TeatarIzveduvach")]
    public partial class TeatarIzveduvach
    {
        
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeatarId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Izveduvach { get; set; }

        public virtual Teatar Teatar { get; set; }
    }
}
