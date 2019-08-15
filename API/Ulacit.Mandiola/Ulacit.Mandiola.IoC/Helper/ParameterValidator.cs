using System;

namespace Ulacit.Mandiola.IoC.Helper
{
    /// <summary>A parameter validator.</summary>
    public static class ParameterValidator
    {
        /// <summary>Validates that parameters are not null. Throws an <see cref="ArgumentNullException"/> if one of the parameters is null.</summary>
        /// <exception cref="ArgumentNullException">      Thrown when one or more required arguments are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more arguments are outside the required range.</exception>
        /// <param name="parameters">{string,object} pairs of the parameters to validate.</param>
        public static void ValidateNotNullParameters(params object[] parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.Length % 2 != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(parameters), "The parameters must be in pairs of 2.");
            }

            for (var i = 0; i < parameters.Length; i += 2)
            {
                if (parameters[i + 1] == null)
                {
                    throw new ArgumentNullException(parameters[i].ToString());
                }
            }
        }
    }
}