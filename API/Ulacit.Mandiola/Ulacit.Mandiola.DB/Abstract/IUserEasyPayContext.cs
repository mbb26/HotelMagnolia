using Ulacit.Mandiola.Common.Abstract;
using Ulacit.Mandiola.Model;

namespace Ulacit.Mandiola.DB.Abstract
{
    /// <summary>Interface for user context.</summary>
    public interface IUserEasyPayContext : IBasicService
    {
        User getByEmail(string id);
    }
}