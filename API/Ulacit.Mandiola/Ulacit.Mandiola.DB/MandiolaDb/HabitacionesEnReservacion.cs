namespace Ulacit.Mandiola.DB.MandiolaDb
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class HabitacionesEnReservacion
    {
        /// <summary>Gets or sets the identifier HabitacionesEnReservacion.</summary>
        /// <value>The identifier ID_ID_HabEnReserv.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_HabEnReserv { get; set; }

        /// <summary>Gets or sets the Ientifier on the room.</summary>
        /// <value>The identifier ID_habitacion.</value>
        [Required]
        [StringLength(100)]
        public string ID_HABITACION { get; set; }

        /// <summary>Gets or sets the identifier on the reservation.</summary>
        /// <value>The identifier ID_reservacion.</value>
        [Required]
        [StringLength(100)]
        public string ID_RESERVACION { get; set; }

    }
}
