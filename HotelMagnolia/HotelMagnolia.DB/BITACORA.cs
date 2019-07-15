namespace HotelMagnolia.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BITACORA")]
    public partial class BITACORA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_BITACORA { get; set; }

        public int ID_USUARIO { get; set; }

        public int Usuario { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Fecha { get; set; }

        public int Codigo { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Registro_en_detalle { get; set; }

        public virtual USUARIO USUARIO1 { get; set; }
    }
}
