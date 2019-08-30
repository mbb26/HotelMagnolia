using Ulacit.Mandiola.Common.Abstract;
using Ulacit.Mandiola.Model;

namespace Ulacit.Mandiola.Biz.Abstract
{
    /// <summary>Interface for IUserEasyPayService service.</summary>
    public interface IUserEasyPayService : IBasicService
    {
        User GetByEmail(string id);
    }
}