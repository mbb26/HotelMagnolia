using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling users.</summary>
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
    }
}