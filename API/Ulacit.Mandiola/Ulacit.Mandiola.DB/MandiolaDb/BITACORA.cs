namespace Ulacit.Mandiola.DB.MandiolaDb
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>A bitacora.</summary>
    [Table("BITACORA")]
    public partial class BITACORA
    {
        /// <summary>Gets or sets the codigo.</summary>
        /// <value>The codigo.</value>
        [Required]
        [StringLength(100)]
        public string CODIGO { get; set; }

        /// <summary>Gets or sets the descripcion.</summary>
        /// <value>The descripcion.</value>
        [Required]
        public string Descripcion { get; set; }

        /// <summary>Gets or sets the Date/Time of the fecha.</summary>
        /// <value>The fecha.</value>
        [Column(TypeName = "smalldatetime")]
        public DateTime FECHA { get; set; }

        /// <summary>Gets or sets the identifier bitacora.</summary>
        /// <value>The identifier bitacora.</value>
        [Key]
        [StringLength(100)]
        public string ID_BITACORA { get; set; }

        /// <summary>Gets or sets the identifier usuario.</summary>
        /// <value>The identifier usuario.</value>
        [Required]
        [StringLength(100)]
        public string ID_USUARIO { get; set; }

        /// <summary>Gets or sets the registro en detalle.</summary>
        /// <value>The registro en detalle.</value>
        [Required]
        public string Registro_en_detalle { get; set; }

        /// <summary>Gets or sets the tipo.</summary>
        /// <value>The tipo.</value>
        public int TIPO { get; set; }
    }
}