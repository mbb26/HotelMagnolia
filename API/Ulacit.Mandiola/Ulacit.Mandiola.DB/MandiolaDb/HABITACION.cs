namespace Ulacit.Mandiola.DB.MandiolaDb
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>A habitacion.</summary>
    [Table("HABITACION")]
    public partial class HABITACION
    {
        /// <summary>Gets or sets the descripcion.</summary>
        /// <value>The descripcion.</value>
        [Required]
        public string DESCRIPCION { get; set; }

        /// <summary>Gets or sets the foto.</summary>
        /// <value>The foto.</value>
        [Required]
        public string FOTO { get; set; }

        /// <summary>Gets or sets the identifier habitacion.</summary>
        /// <value>The identifier habitacion.</value>
        [Key]
        [StringLength(100)]
        public string ID_HABITACION { get; set; }

        /// <summary>Gets or sets the identifier precio.</summary>
        /// <value>The identifier precio.</value>
        [Required]
        [StringLength(100)]
        public string ID_PRECIO { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        /// <value>The nombre.</value>
        [Required]
        public string NOMBRE { get; set; }

        /// <summary>Gets or sets the numero.</summary>
        /// <value>The numero.</value>
        public int NUMERO { get; set; }

        /// <summary>Gets or sets the tipo habitacion.</summary>
        /// <value>The tipo habitacion.</value>
        public int TIPO_HABITACION { get; set; }
    }
}