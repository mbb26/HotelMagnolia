using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing reservations information.</summary>
    [Dependency(DependencyScope.Transient)]
    public class ReservationService : BasicService, IReservationService
    {
        /// <summary>Context for the reservation.</summary>
        private readonly IReservationContext _reservationContext;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.ReservationService class.</summary>
        /// <param name="reservationContext">Context for the reservation.</param>
        public ReservationService(IReservationContext reservationContext) : base(reservationContext)
        {
            _reservationContext = reservationContext;
        }
    }
}