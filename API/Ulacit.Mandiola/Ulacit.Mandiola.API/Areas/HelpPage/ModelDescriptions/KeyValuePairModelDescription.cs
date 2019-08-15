namespace Ulacit.Mandiola.API.Areas.HelpPage.ModelDescriptions
{
    /// <summary>Description of the key value pair model.</summary>
    public class KeyValuePairModelDescription : ModelDescription
    {
        /// <summary>Gets or sets information describing the key model.</summary>
        /// <value>Information describing the key model.</value>
        public ModelDescription KeyModelDescription { get; set; }

        /// <summary>Gets or sets information describing the value model.</summary>
        /// <value>Information describing the value model.</value>
        public ModelDescription ValueModelDescription { get; set; }
    }
}