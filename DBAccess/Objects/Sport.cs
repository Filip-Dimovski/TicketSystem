namespace DBAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Serializable]
    [Table("Sport")]
    public partial class Sport
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NastanId { get; set; }

        [Required]
        [StringLength(50)]
        public string Tip { get; set; }

        public int? DomashenTimId { get; set; }

        public int? GostinskiTimId { get; set; }

        public virtual Nastan Nastan { get; set; }

        public virtual Tim Tim { get; set; }

        public virtual Tim Tim1 { get; set; }
    }
}
