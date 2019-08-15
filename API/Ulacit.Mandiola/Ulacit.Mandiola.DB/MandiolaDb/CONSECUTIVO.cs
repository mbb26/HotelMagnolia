namespace Ulacit.Mandiola.DB.MandiolaDb
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>A consecutivo.</summary>
    [Table("CONSECUTIVO")]
    public partial class CONSECUTIVO
    {
        /// <summary>Gets or sets the identifier consecutivos.</summary>
        /// <value>The identifier consecutivos.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_CONSECUTIVOS { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        /// <value>The nombre.</value>
        public string NOMBRE { get; set; }

        /// <summary>Gets or sets a value indicating whether the posee rango.</summary>
        /// <value>True if posee rango, false if not.</value>
        public bool POSEE_RANGO { get; set; }

        /// <summary>Gets or sets the prefijo.</summary>
        /// <value>The prefijo.</value>
        public string PREFIJO { get; set; }

        /// <summary>Gets or sets the rango final.</summary>
        /// <value>The rango final.</value>
        public int? RANGO_FINAL { get; set; }

        /// <summary>Gets or sets the rango inicial.</summary>
        /// <value>The rango inicial.</value>
        public int? RANGO_INICIAL { get; set; }

        /// <summary>Gets or sets a value indicating whether the tiene prefijo.</summary>
        /// <value>True if tiene prefijo, false if not.</value>
        public bool TIENE_PREFIJO { get; set; }

        /// <summary>Gets or sets the valor.</summary>
        /// <value>The valor.</value>
        public int VALOR { get; set; }
    }
}