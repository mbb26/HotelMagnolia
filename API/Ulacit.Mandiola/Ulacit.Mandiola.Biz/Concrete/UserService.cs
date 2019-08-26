using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;
using System.Web.Http.Cors;
using Ulacit.Mandiola.Model;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing users information.</summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        public T Login<T>(T entity)
        {
            return _userContext.Login<T>(entity);
        }

        public bool IsUsernameAvailable(string username)
        {
            return _userContext.IsUsernameAvailable(username);
        }

        public USUARIO GetUserByEmail(string email)
        {
            return _userContext.GetUserByEmail(email);
        }
    }
}