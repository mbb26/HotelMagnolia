namespace HotelMagnolia.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ARTICULO")]
    public partial class ARTICULO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_ARTICULO { get; set; }

        [Required]
        public string DESCRIPCION_ { get; set; }

        public int PRECIO { get; set; }

        public byte[] IMG { get; set; }

        public virtual CONSECUTIVO CONSECUTIVO { get; set; }
    }
}
