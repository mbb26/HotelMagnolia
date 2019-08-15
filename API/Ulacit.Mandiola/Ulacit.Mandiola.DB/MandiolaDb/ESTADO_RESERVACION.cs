namespace Ulacit.Mandiola.DB.MandiolaDb
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>An estado reservacion.</summary>
    public partial class ESTADO_RESERVACION
    {
        /// <summary>Gets or sets the identifier estado.</summary>
        /// <value>The identifier estado.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_ESTADO { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        /// <value>The nombre.</value>
        [Required]
        public string NOMBRE { get; set; }
    }
}