using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling binnacles.</summary>
    public class BinnacleController : BaseApiController
    {
        /// <summary>The binnacle service.</summary>
        private readonly IBinnacleService _binnacleService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.BinnacleController class.</summary>
        /// <param name="binnacleService">The binnacle service.</param>
        public BinnacleController(IBinnacleService binnacleService)
        {
            _binnacleService = binnacleService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;BITACORA&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;BITACORA&gt;</returns>
        [HttpPost]
        public ApiResultModel<BITACORA> Create([FromBody]BITACORA aux) => GetApiResultModel(() => _binnacleService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]BITACORA aux) => GetApiResultModel(() => _binnacleService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<BITACORA>> GetAll() => GetApiResultModel(() => _binnacleService.GetAll<BITACORA>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<BITACORA> GetById([FromUri]int id) => GetApiResultModel(() => _binnacleService.GetById<BITACORA>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;BITACORA&gt;</returns>
        [HttpPut]
        public ApiResultModel<BITACORA> Update([FromBody]BITACORA aux) => GetApiResultModel(() => _binnacleService.Update(aux));
    }
}