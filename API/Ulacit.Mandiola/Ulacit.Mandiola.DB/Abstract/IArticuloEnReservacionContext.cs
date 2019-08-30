using System.Collections.Generic;
using Ulacit.Mandiola.Common.Abstract;
using Ulacit.Mandiola.Model;

namespace Ulacit.Mandiola.DB.Abstract
{
    /// <summary>Interface for Habitacion En reservacion context.</summary>
    public interface IArticuloEnReservacionContext : IBasicService
    {
        List<T> GetJoinArtcsEnResv<T>(string IDReservacion);
    }
}
