namespace Ulacit.Mandiola.DB.MandiolaDb
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>An actividad.</summary>
    [Table("ACTIVIDAD")]
    public partial class ACTIVIDAD
    {
        /// <summary>Gets or sets the descripcion.</summary>
        /// <value>The descripcion.</value>
        public string DESCRIPCION { get; set; }

        /// <summary>Gets or sets the identifier actividad.</summary>
        /// <value>The identifier actividad.</value>
        [Key]
        [StringLength(100)]
        public string ID_ACTIVIDAD { get; set; }

        /// <summary>Gets or sets the image.</summary>
        /// <value>The image.</value>
        public string IMG { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        /// <value>The nombre.</value>
        public string NOMBRE { get; set; }
    }
}