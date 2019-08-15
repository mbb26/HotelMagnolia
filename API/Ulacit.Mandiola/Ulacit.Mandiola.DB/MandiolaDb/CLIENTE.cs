namespace Ulacit.Mandiola.DB.MandiolaDb
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>A cliente.</summary>
    [Table("CLIENTE")]
    public partial class CLIENTE
    {
        /// <summary>Gets or sets a value indicating whether the activo.</summary>
        /// <value>True if activo, false if not.</value>
        public bool ACTIVO { get; set; }

        /// <summary>Gets or sets the identifier cliente.</summary>
        /// <value>The identifier cliente.</value>
        [Key]
        public int ID_CLIENTE { get; set; }

        /// <summary>Gets or sets the identifier habitacion.</summary>
        /// <value>The identifier habitacion.</value>
        [StringLength(100)]
        public string ID_HABITACION { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        /// <value>The nombre.</value>
        public string NOMBRE { get; set; }
    }
}