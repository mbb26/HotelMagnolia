namespace Ulacit.Mandiola.Model
{
    /// <summary>A cliente.</summary>
    public partial class CLIENTE
    {
        /// <summary>Gets or sets a value indicating whether the activo.</summary>
        /// <value>True if activo, false if not.</value>
        public bool ACTIVO { get; set; }

        /// <summary>Gets or sets the identifier cliente.</summary>
        /// <value>The identifier cliente.</value>
        public int ID_CLIENTE { get; set; }

        /// <summary>Gets or sets the identifier habitacion.</summary>
        /// <value>The identifier habitacion.</value>
        public string ID_HABITACION { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        /// <value>The nombre.</value>
        public string NOMBRE { get; set; }
    }
}