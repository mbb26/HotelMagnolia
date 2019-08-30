using System.Collections.Generic;
using Ulacit.Mandiola.Common.Abstract;
using Ulacit.Mandiola.DB.MandiolaDb;

namespace Ulacit.Mandiola.DB.Abstract
{
    /// <summary>Interface for room context.</summary>
    public interface IRoomContext : IBasicService
    {
        T GetById<T>(string id);
        List<T> GetAvailable<T>();
    }
}