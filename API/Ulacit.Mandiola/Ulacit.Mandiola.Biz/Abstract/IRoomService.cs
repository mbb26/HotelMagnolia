using System.Collections.Generic;
using Ulacit.Mandiola.Common.Abstract;

namespace Ulacit.Mandiola.Biz.Abstract
{
    /// <summary>Interface for room service.</summary>
    public interface IRoomService : IBasicService
    {
        T GetById<T>(string id);
        List<T> GetAvailable<T>();
    }
}