using System.Collections.Generic;
using Ulacit.Mandiola.Common.Abstract;
using Ulacit.Mandiola.Model;

namespace Ulacit.Mandiola.DB.Abstract
{
    /// <summary>Interface for Habitacion En reservacion context.</summary>
    public interface IHabitacionesEnReservacionContext : IBasicService
    {
        List<T> GetJoinHabsEnResv<T>(string IDReservacion);
    }
}
