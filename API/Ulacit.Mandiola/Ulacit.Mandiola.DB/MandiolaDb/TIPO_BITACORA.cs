namespace Ulacit.Mandiola.DB.MandiolaDb
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>A tipo bitacora.</summary>
    public partial class TIPO_BITACORA
    {
        /// <summary>Gets or sets the identifier tipo bitacora.</summary>
        /// <value>The identifier tipo bitacora.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_TIPO_BITACORA { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        /// <value>The nombre.</value>
        [Required]
        [StringLength(100)]
        public string NOMBRE { get; set; }
    }
}