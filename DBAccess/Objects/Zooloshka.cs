namespace DBAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Serializable]
    [Table("Zooloshka")]
    public partial class Zooloshka
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NastanId { get; set; }

        public virtual Nastan Nastan { get; set; }
    }
}
