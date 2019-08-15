namespace Ulacit.Mandiola.DB.MandiolaDb
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>A tipo habitacion.</summary>
    public partial class TIPO_HABITACION
    {
        /// <summary>Gets or sets the identifier tipo habitacion.</summary>
        /// <value>The identifier tipo habitacion.</value>
        [Key]
        public int ID_TIPO_HABITACION { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        /// <value>The nombre.</value>
        [Required]
        [StringLength(100)]
        public string NOMBRE { get; set; }

        /// <summary>Gets or sets the descripcion.</summary>
        /// <value>The descripcion.</value>
        [Required]
        public string DESCRIPCION { get; set; }
    }
}