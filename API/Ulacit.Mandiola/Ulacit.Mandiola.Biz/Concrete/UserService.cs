using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing users information.</summary>
    [Dependency(DependencyScope.Transient)]
    public class UserService : BasicService, IUserService
    {
        /// <summary>Context for the user.</summary>
        private readonly IUserContext _userContext;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.UserService class.</summary>
        /// <param name="userContext">Context for the user.</param>
        public UserService(IUserContext userContext) : base(userContext)
        {
            _userContext = userContext;
        }
    }
}