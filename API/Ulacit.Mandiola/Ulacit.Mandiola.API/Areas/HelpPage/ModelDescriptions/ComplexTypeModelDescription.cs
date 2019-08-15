using System.Collections.ObjectModel;

namespace Ulacit.Mandiola.API.Areas.HelpPage.ModelDescriptions
{
    /// <summary>Description of the complex type model.</summary>
    public class ComplexTypeModelDescription : ModelDescription
    {
        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Areas.HelpPage.ModelDescriptions.ComplexTypeModelDescription class.</summary>
        public ComplexTypeModelDescription()
        {
            Properties = new Collection<ParameterDescription>();
        }

        /// <summary>Gets the properties.</summary>
        /// <value>The properties.</value>
        public Collection<ParameterDescription> Properties { get; private set; }
    }
}