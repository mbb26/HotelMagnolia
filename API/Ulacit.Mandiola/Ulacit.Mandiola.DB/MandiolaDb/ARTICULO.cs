namespace Ulacit.Mandiola.DB.MandiolaDb
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>An articulo.</summary>
    [Table("ARTICULO")]
    public partial class ARTICULO
    {
        /// <summary>Gets or sets the descripcion.</summary>
        /// <value>The descripcion.</value>
        [Required]
        public string DESCRIPCION_ { get; set; }

        /// <summary>Gets or sets the identifier articulo.</summary>
        /// <value>The identifier articulo.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_ARTICULO { get; set; }

        /// <summary>Gets or sets the identifier precio.</summary>
        /// <value>The identifier precio.</value>
        [Required]
        [StringLength(100)]
        public string ID_PRECIO { get; set; }

        /// <summary>Gets or sets the image.</summary>
        /// <value>The image.</value>
        public string IMG { get; set; }
    }
}