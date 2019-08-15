namespace Ulacit.Mandiola.Model
{
    /// <summary>An usuario.</summary>
    public partial class USUARIO
    {
        /// <summary>Gets or sets the apellido 1.</summary>
        /// <value>The apellido 1.</value>
        public string APELLIDO1 { get; set; }

        /// <summary>Gets or sets the apellido 2.</summary>
        /// <value>The apellido 2.</value>
        public string APELLIDO2 { get; set; }

        /// <summary>Gets or sets the correo.</summary>
        /// <value>The correo.</value>
        public string CORREO { get; set; }

        /// <summary>Gets or sets the identifier rol.</summary>
        /// <value>The identifier rol.</value>
        public int? ID_ROL { get; set; }

        /// <summary>Gets or sets the identifier usuario.</summary>
        /// <value>The identifier usuario.</value>
        public string ID_USUARIO { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        /// <value>The nombre.</value>
        public string NOMBRE { get; set; }

        /// <summary>Gets or sets the password.</summary>
        /// <value>The password.</value>
        public string PASSWORD { get; set; }

        /// <summary>Gets or sets the telefono.</summary>
        /// <value>The telefono.</value>
        public int TELEFONO { get; set; }

        /// <summary>Gets or sets the name of the user.</summary>
        /// <value>The name of the user.</value>
        public string USER_NAME { get; set; }
    }
}