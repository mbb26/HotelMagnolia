using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;
using System.Web.Http.Cors;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling activities.</summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserEasyPayController : BaseApiController
    {
        /// <summary>The activity service.</summary>
        private readonly IUserEasyPayService _userEasyPayService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.ActivityController class.</summary>
        /// <param name="userEasyPayService">The activity service.</param>
        public UserEasyPayController(IUserEasyPayService userEasyPayService)
        {
            _userEasyPayService = userEasyPayService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;ACTIVIDAD&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;ACTIVIDAD&gt;</returns>
        [HttpPost]
        public ApiResultModel<User> Create([FromBody]User aux) => GetApiResultModel(() => _userEasyPayService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]User aux) => GetApiResultModel(() => _userEasyPayService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<User>> GetAll() => GetApiResultModel(() => _userEasyPayService.GetAll<User>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<User> GetById([FromUri]int id) => GetApiResultModel(() => _userEasyPayService.GetById<User>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;ACTIVIDAD&gt;</returns>
        [HttpPut]
        public ApiResultModel<User> Update([FromBody]User aux) => GetApiResultModel(() => _userEasyPayService.Update(aux));
    }
}