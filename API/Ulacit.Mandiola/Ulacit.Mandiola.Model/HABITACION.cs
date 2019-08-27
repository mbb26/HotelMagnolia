namespace Ulacit.Mandiola.Model
{
    /// <summary>A habitacion.</summary>
    public partial class HABITACION
    {
        /// <summary>Gets or sets the descripcion.</summary>
        /// <value>The descripcion.</value>
        public string DESCRIPCION { get; set; }

        /// <summary>Gets or sets the disponible.</summary>
        /// <value>True if disponible, false if not.</value>
        public bool DISPONIBLE { get; set; }

        /// <summary>Gets or sets the foto.</summary>
        /// <value>The foto.</value>
        public string FOTO { get; set; }

        /// <summary>Gets or sets the identifier habitacion.</summary>
        /// <value>The identifier habitacion.</value>
        public string ID_HABITACION { get; set; }

        /// <summary>Gets or sets the identifier precio.</summary>
        /// <value>The identifier precio.</value>
        public string ID_PRECIO { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        /// <value>The nombre.</value>
        public string NOMBRE { get; set; }

        /// <summary>Gets or sets the numero.</summary>
        /// <value>The numero.</value>
        public int NUMERO { get; set; }

        /// <summary>Gets or sets the tipo habitacion.</summary>
        /// <value>The tipo habitacion.</value>
        public int TIPO_HABITACION { get; set; }
    }
}