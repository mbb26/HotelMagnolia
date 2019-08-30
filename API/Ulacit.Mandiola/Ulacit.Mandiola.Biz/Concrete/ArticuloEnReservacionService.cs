using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;
using System.Web.Http.Cors;
using Ulacit.Mandiola.Model;
using System.Collections.Generic;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing users information.</summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Dependency(DependencyScope.Transient)]
    public class ArticuloEnReservacionService :BasicService, IArticuloEnReservacionService
    {
        /// <summary>Context for the habitacion en Reservaciones.</summary>
        private readonly IArticuloEnReservacionContext _ArticuloEnReservacionContext;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.HabitacionesEnReservacionService class.</summary>
        /// <param name="ArticuloEnReservacionContext">Context for the user.</param>
        public ArticuloEnReservacionService(IArticuloEnReservacionContext ArticuloEnReservacionContext) : base(ArticuloEnReservacionContext)
        {
            _ArticuloEnReservacionContext = ArticuloEnReservacionContext;
        }

        public IArticuloEnReservacionContext ArticuloEnReservacionContext => _ArticuloEnReservacionContext;

        public List<T> GetJoinArtcsEnResv<T>(string IDReservacion)
        {
            return _ArticuloEnReservacionContext.GetJoinArtcsEnResv<T>(IDReservacion);
        }
    }
}
