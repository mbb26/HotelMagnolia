using System;

namespace Ulacit.Mandiola.Model
{
    /// <summary>A reservacion.</summary>
    public partial class RESERVACION
    {
        /// <summary>Gets or sets the estado reservacion.</summary>
        /// <value>The estado reservacion.</value>
        public int ESTADO_RESERVACION { get; set; }

        /// <summary>Gets or sets the Date/Time of the fecha entrada.</summary>
        /// <value>The fecha entrada.</value>
        public DateTime FECHA_ENTRADA { get; set; }

        /// <summary>Gets or sets the Date/Time of the fecha salida.</summary>
        /// <value>The fecha salida.</value>
        public DateTime FECHA_SALIDA { get; set; }

        /// <summary>Gets or sets the identifier cliente.</summary>
        /// <value>The identifier cliente.</value>
        public int ID_CLIENTE { get; set; }

        /// <summary>Gets or sets the identifier reservacion.</summary>
        /// <value>The identifier reservacion.</value>
        public string ID_RESERVACION { get; set; }

        /// <summary>Gets or sets the tipo habitacion.</summary>
        /// <value>The tipo habitacion.</value>
        public int TIPO_HABITACION { get; set; }
    }
}