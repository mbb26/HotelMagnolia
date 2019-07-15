namespace HotelMagnolia.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRECIO")]
    public partial class PRECIO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_PRECIO { get; set; }

        [Required]
        public string TIPO_PRECIO { get; set; }

        [Column("PRECIO")]
        public int PRECIO1 { get; set; }

        public virtual CONSECUTIVO CONSECUTIVO { get; set; }
    }
}
