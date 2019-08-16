using System;
using Ulacit.Mandiola.Common.Abstract;

namespace Ulacit.Mandiola.DB.Abstract
{
    /// <summary>Interface for user context.</summary>
    public interface IUserContext : IBasicService
    {
        T Login<T>(T entity);
        bool IsUsernameAvailable(string username);
    }
}