using System.Collections.Generic;
using Ulacit.Mandiola.Common.Abstract;

namespace Ulacit.Mandiola.Biz.Abstract
{
    /// <summary>Interface for room service.</summary>
    public interface IRoomService : IBasicService
    {
        /// <summary>Creates gets a list of Availabe rooms.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>A List.</returns>
        List<T> GetAvailable<T>();
    }
}