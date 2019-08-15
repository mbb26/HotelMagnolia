using System;

namespace Ulacit.Mandiola.IoC.Abstract
{
    /// <summary>Represents a dependency resolver.</summary>
    public interface IDependencyResolver
    {
        /// <summary>Gets an instance of the <typeparamref name="T"/> type.</summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>An instance of the <typeparamref name="T"/> type.</returns>
        T Get<T>();

        /// <summary>Gets an instance of the type indicated.</summary>
        /// <param name="type">.</param>
        /// <returns>An instance of the type.</returns>
        object Get(Type type);
    }
}