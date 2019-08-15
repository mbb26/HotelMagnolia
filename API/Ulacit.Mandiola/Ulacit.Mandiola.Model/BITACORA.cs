using System;

namespace Ulacit.Mandiola.Model
{
    /// <summary>A bitacora.</summary>
    public partial class BITACORA
    {
        /// <summary>Gets or sets the codigo.</summary>
        /// <value>The codigo.</value>
        public string CODIGO { get; set; }

        /// <summary>Gets or sets the descripcion.</summary>
        /// <value>The descripcion.</value>
        public string Descripcion { get; set; }

        /// <summary>Gets or sets the Date/Time of the fecha.</summary>
        /// <value>The fecha.</value>
        public DateTime FECHA { get; set; }

        /// <summary>Gets or sets the identifier bitacora.</summary>
        /// <value>The identifier bitacora.</value>
        public string ID_BITACORA { get; set; }

        /// <summary>Gets or sets the identifier usuario.</summary>
        /// <value>The identifier usuario.</value>
        public string ID_USUARIO { get; set; }

        /// <summary>Gets or sets the registro en detalle.</summary>
        /// <value>The registro en detalle.</value>
        public string Registro_en_detalle { get; set; }

        /// <summary>Gets or sets the tipo.</summary>
        /// <value>The tipo.</value>
        public int TIPO { get; set; }
    }
}