using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;
using System.Web.Http.Cors;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling consecutives.</summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ConsecutiveController : BaseApiController
    {
        /// <summary>The consecutive service.</summary>
        private readonly IConsecutiveService _consecutiveService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.ConsecutiveController class.</summary>
        /// <param name="consecutiveService">The consecutive service.</param>
        public ConsecutiveController(IConsecutiveService consecutiveService)
        {
            _consecutiveService = consecutiveService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;CONSECUTIVO&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;CONSECUTIVO&gt;</returns>
        [HttpPost]
        public ApiResultModel<CONSECUTIVO> Create([FromBody]CONSECUTIVO aux) => GetApiResultModel(() => _consecutiveService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]CONSECUTIVO aux) => GetApiResultModel(() => _consecutiveService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<CONSECUTIVO>> GetAll() => GetApiResultModel(() => _consecutiveService.GetAll<CONSECUTIVO>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<CONSECUTIVO> GetById([FromUri]int id) => GetApiResultModel(() => _consecutiveService.GetById<CONSECUTIVO>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;CONSECUTIVO&gt;</returns>
        [HttpPut]
        public ApiResultModel<CONSECUTIVO> Update([FromBody]CONSECUTIVO aux) => GetApiResultModel(() => _consecutiveService.Update(aux));
    }
}