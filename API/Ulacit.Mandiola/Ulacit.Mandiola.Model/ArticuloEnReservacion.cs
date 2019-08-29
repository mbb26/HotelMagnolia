using System;
using System.Collections.Generic;

namespace Ulacit.Mandiola.Model
{
    public partial class ArticuloEnReservacion
    {
        /// <summary>Gets or sets the identifier for the rooms in the reservation .</summary>
        /// <value>The Identifier.</value>
        public int ID_ArtEnReserv { get; set; }

        /// <summary>Gets or sets the identifier on the room.</summary>
        /// <value>The identifier for the room.</value>
        public string ID_ARTICULO { get; set; }

        /// <summary>Gets or sets the identifier on the Reservation.</summary>
        /// <value>The identifier for the reservation.</value>
        public string ID_RESERVACION { get; set; }
    }
}
