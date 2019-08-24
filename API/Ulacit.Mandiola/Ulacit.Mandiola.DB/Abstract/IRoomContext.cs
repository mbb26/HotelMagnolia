using System.Collections.Generic;
using Ulacit.Mandiola.Common.Abstract;

namespace Ulacit.Mandiola.DB.Abstract
{
    /// <summary>Interface for room context.</summary>
    public interface IRoomContext : IBasicService
    {
        List<T> GetAvailable();
    }
}