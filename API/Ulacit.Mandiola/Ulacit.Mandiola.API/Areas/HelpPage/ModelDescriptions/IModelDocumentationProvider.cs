using System;
using System.Reflection;

namespace Ulacit.Mandiola.API.Areas.HelpPage.ModelDescriptions
{
    /// <summary>Interface for model documentation provider.</summary>
    public interface IModelDocumentationProvider
    {
        /// <summary>Gets a documentation.</summary>
        /// <param name="member">The member.</param>
        /// <returns>The documentation.</returns>
        string GetDocumentation(MemberInfo member);

        /// <summary>Gets a documentation.</summary>
        /// <param name="type">The type.</param>
        /// <returns>The documentation.</returns>
        string GetDocumentation(Type type);
    }
}