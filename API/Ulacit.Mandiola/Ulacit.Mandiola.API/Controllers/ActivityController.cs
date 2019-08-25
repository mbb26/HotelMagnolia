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
    public class ActivityController : BaseApiController
    {
        /// <summary>The activity service.</summary>
        private readonly IActivityService _activityService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.ActivityController class.</summary>
        /// <param name="activityService">The activity service.</param>
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;ACTIVIDAD&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;ACTIVIDAD&gt;</returns>
        [HttpPost]
        public ApiResultModel<ACTIVIDAD> Create([FromBody]ACTIVIDAD aux) => GetApiResultModel(() => _activityService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]ACTIVIDAD aux) => GetApiResultModel(() => _activityService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<ACTIVIDAD>> GetAll() => GetApiResultModel(() => _activityService.GetAll<ACTIVIDAD>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<ACTIVIDAD> GetById([FromUri]int id) => GetApiResultModel(() => _activityService.GetById<ACTIVIDAD>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;ACTIVIDAD&gt;</returns>
        [HttpPut]
        public ApiResultModel<ACTIVIDAD> Update([FromBody]ACTIVIDAD aux) => GetApiResultModel(() => _activityService.Update(aux));
    }
}