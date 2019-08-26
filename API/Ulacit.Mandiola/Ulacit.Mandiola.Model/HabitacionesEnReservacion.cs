using System;
using System.Collections.Generic;
namespace Ulacit.Mandiola.Model
{
    /// <summary>An actividad.</summary>
    public partial class HabitacionesEnReservacion
    {
        /// <summary>Gets or sets the identifier for the rooms in the reservation .</summary>
        /// <value>The Identifier.</value>
        public int ID_HabEnReserv { get; set; }

        /// <summary>Gets or sets the identifier on the room.</summary>
        /// <value>The identifier for the room.</value>
        public string ID_HABITACION { get; set; }

        /// <summary>Gets or sets the identifier on the Reservation.</summary>
        /// <value>The identifier for the reservation.</value>
        public string ID_RESERVACION { get; set; }

    }
}
