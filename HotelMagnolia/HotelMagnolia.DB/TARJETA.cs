namespace HotelMagnolia.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TARJETA")]
    public partial class TARJETA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_TARJETA { get; set; }

        public int ID_USUARIO { get; set; }

        public int Tarjetahabiente { get; set; }

        public int Numero_Tarjeta { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Fecha_Expiracion { get; set; }

        public int CVV { get; set; }

        public int Usuario_Tarjeta { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
