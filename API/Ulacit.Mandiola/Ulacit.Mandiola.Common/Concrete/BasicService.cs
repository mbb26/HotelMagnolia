using System.Collections.Generic;
using Ulacit.Mandiola.Common.Abstract;
using System.Web.Http.Cors;

namespace Ulacit.Mandiola.Common.Concrete
{
    /// <summary>A service for accessing basics information.</summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BasicService : IBasicService
    {
        /// <summary>The context.</summary>
        private readonly IBasicService _ctx;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Common.Concrete.BasicService class.</summary>
        /// <param name="ctx">The context.</param>
        public BasicService(IBasicService ctx)
        {
            _ctx = ctx;
        }

        /// <summary>Creates a new T.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>A T.</returns>
        public T Create<T>(T entity)
            => _ctx.Create(entity);

        /// <summary>Deletes the given entity.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>True if it succeeds, false if it fails.</returns>
        public bool Delete<T>(T entity)
            => _ctx.Delete(entity);

        /// <summary>Gets all.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <returns>all.</returns>
        public List<T> GetAll<T>()
            => _ctx.GetAll<T>();

        /// <summary>Gets by identifier.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        public T GetById<T>(int id)
            => _ctx.GetById<T>(id);

        /// <summary>Updates the given entity.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>A T.</returns>
        public T Update<T>(T entity)
        {
            return _ctx.Update(entity);
        }
    }
}