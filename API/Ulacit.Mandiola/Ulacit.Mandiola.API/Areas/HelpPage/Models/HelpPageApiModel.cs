using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Web.Http.Description;
using Ulacit.Mandiola.API.Areas.HelpPage.ModelDescriptions;

namespace Ulacit.Mandiola.API.Areas.HelpPage.Models
{
    /// <summary>The model that represents an API displayed on the help page.</summary>
    public class HelpPageApiModel
    {
        /// <summary>Initializes a new instance of the <see cref="HelpPageApiModel"/> class.</summary>
        public HelpPageApiModel()
        {
            UriParameters = new Collection<ParameterDescription>();
            SampleRequests = new Dictionary<MediaTypeHeaderValue, object>();
            SampleResponses = new Dictionary<MediaTypeHeaderValue, object>();
            ErrorMessages = new Collection<string>();
        }

        /// <summary>Gets or sets the <see cref="ApiDescription"/> that describes the API.</summary>
        /// <value>Information describing the API.</value>
        public ApiDescription ApiDescription { get; set; }

        /// <summary>Gets the <see cref="ParameterDescription"/> collection that describes the URI parameters for the API.</summary>
        /// <value>Options that control the URI.</value>
        public Collection<ParameterDescription> UriParameters { get; private set; }

        /// <summary>Gets or sets the documentation for the request.</summary>
        /// <value>The request documentation.</value>
        public string RequestDocumentation { get; set; }

        /// <summary>Gets or sets the <see cref="ModelDescription"/> that describes the request body.</summary>
        /// <value>Information describing the request model.</value>
        public ModelDescription RequestModelDescription { get; set; }

        /// <summary>Gets the request body parameter descriptions.</summary>
        /// <value>Options that control the request body.</value>
        public IList<ParameterDescription> RequestBodyParameters
        {
            get
            {
                return GetParameterDescriptions(RequestModelDescription);
            }
        }

        /// <summary>Gets or sets the <see cref="ModelDescription"/> that describes the resource.</summary>
        /// <value>Information describing the resource.</value>
        public ModelDescription ResourceDescription { get; set; }

        /// <summary>Gets the resource property descriptions.</summary>
        /// <value>The resource properties.</value>
        public IList<ParameterDescription> ResourceProperties
        {
            get
            {
                return GetParameterDescriptions(ResourceDescription);
            }
        }

        /// <summary>Gets the sample requests associated with the API.</summary>
        /// <value>The sample requests.</value>
        public IDictionary<MediaTypeHeaderValue, object> SampleRequests { get; private set; }

        /// <summary>Gets the sample responses associated with the API.</summary>
        /// <value>The sample responses.</value>
        public IDictionary<MediaTypeHeaderValue, object> SampleResponses { get; private set; }

        /// <summary>Gets the error messages associated with this model.</summary>
        /// <value>The error messages.</value>
        public Collection<string> ErrorMessages { get; private set; }

        /// <summary>Gets parameter descriptions.</summary>
        /// <param name="modelDescription">Information describing the model.</param>
        /// <returns>The parameter descriptions.</returns>
        private static IList<ParameterDescription> GetParameterDescriptions(ModelDescription modelDescription)
        {
            ComplexTypeModelDescription complexTypeModelDescription = modelDescription as ComplexTypeModelDescription;
            if (complexTypeModelDescription != null)
            {
                return complexTypeModelDescription.Properties;
            }

            CollectionModelDescription collectionModelDescription = modelDescription as CollectionModelDescription;
            if (collectionModelDescription != null)
            {
                complexTypeModelDescription = collectionModelDescription.ElementDescription as ComplexTypeModelDescription;
                if (complexTypeModelDescription != null)
                {
                    return complexTypeModelDescription.Properties;
                }
            }

            return null;
        }
    }
}