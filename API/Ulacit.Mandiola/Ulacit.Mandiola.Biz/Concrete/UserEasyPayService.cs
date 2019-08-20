using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing activities information.</summary>
    [Dependency(DependencyScope.Transient)]
    public class UserEasyPayService : BasicService, IUserEasyPayService
    {
        /// <summary>Context for the activity.</summary>
        private readonly IUserEasyPayContext _userEasyPayService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.UserEasyPayService class.</summary>
        /// <param name="activityContext">Context for the IUserEasyPayService.</param>
        public UserEasyPayService(IUserEasyPayContext userEasyPayService) : base(userEasyPayService)
        {
            _userEasyPayService = userEasyPayService;
        }
    }
}