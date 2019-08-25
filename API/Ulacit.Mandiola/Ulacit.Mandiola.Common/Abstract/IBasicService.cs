using System.Collections.Generic;

namespace Ulacit.Mandiola.Common.Abstract
{
    /// <summary>Interface for basic service.</summary>
    public interface IBasicService
    {
        /// <summary>Creates a new T.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>A T.</returns>
        T Create<T>(T entity);

        /// <summary>Deletes the given entity.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>True if it succeeds, false if it fails.</returns>
        bool Delete<T>(T entity);

        /// <summary>Gets all.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <returns>all.</returns>
        List<T> GetAll<T>();

        /// <summary>Gets by identifier.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        T GetById<T>(int id);

        /// <summary>Updates the given entity.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>A T.</returns>
        T Update<T>(T entity);
    }
}