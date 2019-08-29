namespace Ulacit.Mandiola.Model
{
    /// <summary>An articulo.</summary>
    public partial class ARTICULO
    {
        /// <summary>Gets or sets the descripcion.</summary>
        /// <value>The descripcion.</value>
        public string DESCRIPCION { get; set; }

        /// <summary>Gets or sets the identifier articulo.</summary>
        /// <value>The identifier articulo.</value>
        public int ID_ARTICULO { get; set; }

        /// <summary>Gets or sets the identifier precio.</summary>
        /// <value>The identifier precio.</value>
        public string ID_PRECIO { get; set; }

        /// <summary>Gets or sets the image.</summary>
        /// <value>The image.</value>
        public string IMG { get; set; }
    }
}