using System;

namespace Ulacit.Mandiola.API.Areas.HelpPage
{
    /// <summary>This represents an invalid sample on the help page. There's a display template named InvalidSample associated with this class.</summary>
    public class InvalidSample
    {
        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Areas.HelpPage.InvalidSample class.</summary>
        /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
        /// <param name="errorMessage">A message describing the error.</param>
        public InvalidSample(string errorMessage)
        {
            if (errorMessage == null)
            {
                throw new ArgumentNullException("errorMessage");
            }
            ErrorMessage = errorMessage;
        }

        /// <summary>Gets a message describing the error.</summary>
        /// <value>A message describing the error.</value>
        public string ErrorMessage { get; private set; }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            InvalidSample other = obj as InvalidSample;
            return other != null && ErrorMessage == other.ErrorMessage;
        }

        /// <summary>Serves as the default hash function.</summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return ErrorMessage.GetHashCode();
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}