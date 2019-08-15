namespace Ulacit.Mandiola.DB.MandiolaDb
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>A precio.</summary>
    [Table("PRECIO")]
    public partial class PRECIO
    {
        /// <summary>Gets or sets the identifier precio.</summary>
        /// <value>The identifier precio.</value>
        [Key]
        [StringLength(100)]
        public string ID_PRECIO { get; set; }

        /// <summary>Gets or sets the precio 1.</summary>
        /// <value>The precio 1.</value>
        [Column("PRECIO")]
        public int PRECIO1 { get; set; }

        /// <summary>Gets or sets the tipo precio.</summary>
        /// <value>The tipo precio.</value>
        [Required]
        public string TIPO_PRECIO { get; set; }
    }
}