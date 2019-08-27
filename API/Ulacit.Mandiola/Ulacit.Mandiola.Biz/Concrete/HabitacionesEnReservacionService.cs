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
    public class HabitacionesEnReservacionService : BasicService, IHabitacionesEnReservacionService
    {

        /// <summary>Context for the habitacion en Reservaciones.</summary>
        private readonly IHabitacionesEnReservacionContext _HabitacionesEnReservacionContext;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.HabitacionesEnReservacionService class.</summary>
        /// <param name="HabitacionesEnReservacionContext">Context for the user.</param>
        public HabitacionesEnReservacionService(IHabitacionesEnReservacionContext HabitacionesEnReservacionContext) : base(HabitacionesEnReservacionContext)
        {
            _HabitacionesEnReservacionContext = HabitacionesEnReservacionContext;
        }

        public IHabitacionesEnReservacionContext HabitacionesEnReservacionContext => _HabitacionesEnReservacionContext;

        public List<T> GetJoinHabsEnResv<T>(string IDReservacion)
        {
            throw new System.NotImplementedException();
        }
    }
}
