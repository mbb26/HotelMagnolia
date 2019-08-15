using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ulacit.Mandiola.API.Areas.HelpPage.ModelDescriptions
{
    /// <summary>Description of the enum type model.</summary>
    public class EnumTypeModelDescription : ModelDescription
    {
        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Areas.HelpPage.ModelDescriptions.EnumTypeModelDescription class.</summary>
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        /// <summary>Gets the values.</summary>
        /// <value>The values.</value>
        public Collection<EnumValueDescription> Values { get; private set; }
    }
}