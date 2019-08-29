namespace Ulacit.Mandiola.DB.MandiolaDb
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("ArticuloEnReservacion")]
    public partial class ArticuloEnReservacion
    {
        /// <summary>Gets or sets the identifier ArticulosEnReservacion.</summary>
        /// <value>The identifier ID_ArtEnReserv.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_ArtEnReserv { get; set; }

        /// <summary>Gets or sets the Ientifier on the article.</summary>
        /// <value>The identifier ID_ARTICULO.</value>
        [Required]
        [StringLength(100)]
        public string ID_ARTICULO { get; set; }

        /// <summary>Gets or sets the identifier on the reservation.</summary>
        /// <value>The identifier ID_reservacion.</value>
        [Required]
        [StringLength(100)]
        public string ID_RESERVACION { get; set; }

    }
}
