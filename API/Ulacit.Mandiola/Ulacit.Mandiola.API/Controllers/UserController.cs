using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;
using System.Web.Http.Cors;
using System;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling users.</summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : BaseApiController
    {
        /// <summary>The user service.</summary>
        private readonly IUserService _userService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.UserController class.</summary>
        /// <param name="userService">The user service.</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;USUARIO&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;USUARIO&gt;</returns>
        [HttpPost]
        public ApiResultModel<USUARIO> Create([FromBody]USUARIO aux) => GetApiResultModel(() => _userService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]USUARIO aux) => GetApiResultModel(() => _userService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<USUARIO>> GetAll() => GetApiResultModel(() => _userService.GetAll<USUARIO>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<USUARIO> GetById([FromUri]int id) => GetApiResultModel(() => _userService.GetById<USUARIO>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;USUARIO&gt;</returns>
        [HttpPut]
        public ApiResultModel<USUARIO> Update([FromBody]USUARIO aux) => GetApiResultModel(() => _userService.Update(aux));

        /// <summary>Logs the user in</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;USUARIO&gt;</returns>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public ApiResultModel<USUARIO> Login([FromBody]USUARIO aux) => GetApiResultModel(() => _userService.Login(aux));

        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email">the email</param>
        /// <returns>the user</returns>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        public ApiResultModel<USUARIO> GetUserByEmail([FromUri]string email) => GetApiResultModel(() => _userService.GetUserByEmail(email));

        /// <summary>Returns is an username is available</summary>
        /// <param name="user_name">The username to be checked.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        public ApiResultModel<Boolean> IsUsernameAvailable([FromUri]string user_name) => GetApiResultModel(() => _userService.IsUsernameAvailable(user_name));
    }
}