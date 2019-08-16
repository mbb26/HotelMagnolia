using Ulacit.Mandiola.Common.Abstract;
using System.Web.Http.Cors;
using System;

namespace Ulacit.Mandiola.Biz.Abstract
{
    /// <summary>Interface for user service.</summary>
    public interface IUserService : IBasicService
    {
        /// <summary>Creates a new T.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>A T.</returns>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        T Login<T>(T entity);

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        bool IsUsernameAvailable(string username);
    }
}