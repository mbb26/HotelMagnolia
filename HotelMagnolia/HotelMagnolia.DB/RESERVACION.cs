namespace HotelMagnolia.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RESERVACION")]
    public partial class RESERVACION
    {
        public int? ID_CONSECUTIVOS { get; set; }

        public int? ID_USUARIO { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime FECHA_ENTRADA { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime FECHA_SALIDA { get; set; }

        [Key]
        [Column(Order = 2)]
        public string TIPO_HABITACION { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ESTADO_RESERVACION { get; set; }

        public virtual HABITACION HABITACION { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
