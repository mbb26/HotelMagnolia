using System.Collections.Generic;
using Ulacit.Mandiola.Common.Abstract;

namespace Ulacit.Mandiola.Biz.Abstract
{
    /// <summary>Interface for Articulos in reservationservice.</summary>
    public interface IArticuloEnReservacionService : IBasicService
    {
        List<T> GetJoinArtcsEnResv<T>(string IDReservacion);
    }
}
