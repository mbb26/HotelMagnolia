using System.Collections.Generic;
using Ulacit.Mandiola.Common.Abstract;

namespace Ulacit.Mandiola.Biz.Abstract
{
    /// <summary>Interface for Habitaciones in reservationservice.</summary>
    public interface IHabitacionesEnReservacionService : IBasicService
    {
        List<T> GetJoinHabsEnResv<T>(string IDReservacion);
    }
}
