namespace Ulacit.Mandiola.DB.MandiolaDb
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>A reservacion.</summary>
    [Table("RESERVACION")]
    public partial class RESERVACION
    {
        /// <summary>Gets or sets the estado reservacion.</summary>
        /// <value>The estado reservacion.</value>
        public int ESTADO_RESERVACION { get; set; }

        /// <summary>Gets or sets the Date/Time of the fecha entrada.</summary>
        /// <value>The fecha entrada.</value>
        [Column(TypeName = "date")]
        public DateTime FECHA_ENTRADA { get; set; }

        /// <summary>Gets or sets the Date/Time of the fecha salida.</summary>
        /// <value>The fecha salida.</value>
        [Column(TypeName = "date")]
        public DateTime FECHA_SALIDA { get; set; }

        /// <summary>Gets or sets the identifier cliente.</summary>
        /// <value>The identifier cliente.</value>
        public string ID_CLIENTE { get; set; }

        /// <summary>Gets or sets the identifier reservacion.</summary>
        /// <value>The identifier reservacion.</value>
        [Key]
        [StringLength(100)]
        public string ID_RESERVACION { get; set; }

        /// <summary>Gets or sets the tipo habitacion.</summary>
        /// <value>The tipo habitacion.</value>
        public int TIPO_HABITACION { get; set; }
    }
}